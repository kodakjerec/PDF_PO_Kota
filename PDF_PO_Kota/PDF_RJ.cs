using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Data;
using System;
using System.IO;
using System.Data.SqlClient;

namespace PDF_PO_Kota
{
    public partial class PDF_RJ
    {
        static public string CreatPdf_Prod(XSC.ClientAccess.sqlClientAccess sca, string RJ, string siteno, string Host_string, string IP_string, string Mainfilepath)
        {
            string returnstring = "";
            Document doc = new Document();
            string filepath = Mainfilepath;
            string path;    //檔案路徑
            string FileKey; //PO單號
            DataTable dt = new DataTable();

            //產生字型檔,圖檔,然後刪除
            if (File.Exists(Environment.CurrentDirectory + "\\WMSADJ\\logo.jpg") == false)
            {
                return "無logo.jpg，請嘗試重開程式";
            }
            if (File.Exists(Environment.CurrentDirectory + "\\WMSADJ\\IDAutomationHC39M_FREE.otf") == false)
            {
                return "無otf，請嘗試重開程式";
            }
            if (File.Exists(Environment.CurrentDirectory + "\\WMSADJ\\kaiu.ttf") == false)
            {
                return "無ttf，請嘗試重開程式";
            }

            #region 初使參數設定
            // 定義字型
            BaseFont bfChinese =
                BaseFont.CreateFont(Environment.CurrentDirectory + "\\WMSADJ\\kaiu.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);//中文字型標楷體
            BaseFont bfCode =
                //BaseFont.CreateFont(@"C:\WINDOWS\Fonts\3of9.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                BaseFont.CreateFont(Environment.CurrentDirectory + "\\WMSADJ\\IDAutomationHC39M_FREE.otf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            //標題
            Paragraph h = new Paragraph();
            h.Alignment = Element.ALIGN_CENTER;
            h.Font = new Font(bfChinese, 32, Font.BOLD + Font.NORMAL, BaseColor.BLACK);
            h.SetLeading(0.0f, 0.9f);

            // 內容
            Paragraph h_title = new Paragraph();
            h_title.Alignment = Element.ALIGN_CENTER;
            h_title.Font = new Font(bfChinese, 20, Font.BOLD + Font.NORMAL, BaseColor.BLACK);
            h_title.SetLeading(2.0f, 0.9f);

            // 條碼
            Paragraph h_Code = new Paragraph();
            h_Code.Alignment = Element.ALIGN_CENTER;
            h_Code.Font = new Font(bfCode, 32);//, Font.NORMAL,, BaseColor.BLACK);
            h_Code.SetLeading(0.0f, 0.9f);


            // 空白行
            Paragraph h_newline = new Paragraph();
            h_newline.Alignment = Element.ALIGN_CENTER;
            h_newline.Font = new Font(bfChinese, 10, Font.BOLD + Font.NORMAL, BaseColor.BLUE);
            h_newline.SetLeading(0.0f, 0.9f);
            h_newline.Add("　");

            // 空白行(大)
            Paragraph h_newline_L = new Paragraph();
            h_newline_L.Alignment = Element.ALIGN_CENTER;
            h_newline_L.Font = new Font(bfChinese, 72, Font.BOLD + Font.NORMAL, BaseColor.BLUE);
            h_newline_L.SetLeading(0.0f, 0.9f);
            h_newline_L.Add("　");

            #endregion

            try
            {


                #region 尋找RJ單
                string sqlcommand = "select * from V_EDI_BACK_R02_T where RJ_NO=@po_no and site_no=@site_no";
                object[] scaParam = {"@po_no" ,"NVarChar",RJ,
                                         "@site_no","NVarChar",siteno };
                dt = sca.GetDataTable("EDI_DC", sqlcommand, scaParam, 0);
                if (dt.Rows.Count == 0)
                {
                    returnstring += "找不到資料，請確認RJ單號存在";
                    return returnstring;
                }
                #endregion

                #region 記錄log
                sqlcommand = "insert into LGDC.dbo.RunLog (JobID,JobType,JobDate,JobCmd,Crt_date) "
                        + " values('',"         //JobID
                        + "'手動產生PDF"        //JobType
                        + "',CONVERT(CHAR(10),GETDATE(),112)"   //JobDate
                        + ",'PDF_PO_Kota.exe " + RJ
                            + "," + System.Security.Principal.WindowsIdentity.GetCurrent().Name
                            + "," + Host_string
                            + "," + IP_string//JobCmd
                        + "',GETDATE()) ";    //Crt_date
                sca.Update("LGDC", sqlcommand, scaParam, 0);
                #endregion

                DataRow dr = dt.Rows[0];


                FileKey = dr["RJ_NO"].ToString();
                string FileKey_ = "";

                PdfPCell pCell_tmp;
                PdfPTable p;
                int Border_type = Rectangle.BOTTOM_BORDER;
                int Border_type_H = Rectangle.NO_BORDER;
                int Font_Size = 10;
                int Font_Size_8 = 9;
                int Font_Size_7 = 7;

                #region 預計實作功能 圖片及條碼

                // string Img_url = @"C:\Fpxmart\logo.jpg";//  公司Logo

                string Img_url = Environment.CurrentDirectory + "\\WMSADJ\\logo.jpg";
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(new Uri(Img_url));

                jpg.ScalePercent(60);

                PdfPCell jpgcell = new PdfPCell(jpg);
                jpgcell.Border = 0;
                jpgcell.Colspan = 1;
                jpgcell.Column.Alignment = Element.ALIGN_CENTER;
                jpgcell.VerticalAlignment = Element.ALIGN_CENTER;
                #endregion

                int INNER_QTY = 0;
                int QTY = 0;

                // 分頁
                int row_page = 16; //每頁幾筆
                int row_Count_PDFNow = 0; //pdf第幾頁
                int row_Count_Now = 0;    //第幾筆
                int Page = 0; //總頁碼
                int pageEnd = 0; //結束頁


                p = new PdfPTable(3);
                foreach (DataRow drt in dt.Rows)
                {
                    FileKey = drt["RJ_NO"].ToString();

                    #region 單據不同則產生單據
                    if (FileKey_ != FileKey)
                    {
                        if (FileKey_ != "")
                        {
                            doc.Add(p);
                            doc.Add(h_newline);

                            //尾頁
                            p = PageEnd(bfChinese, doc, h_newline, p, Font_Size);
                            //簽收
                            PageEndSign(bfChinese, row_Count_Now, row_page, pageEnd, Font_Size, p, Page, doc);

                        }
                        //頁碼重新計算
                        row_Count_PDFNow = 0;
                        row_Count_Now = 0;
                        Page = 0;
                        pageEnd = 0;

                        DataRow[] PageRows;
                        string expression;
                        expression = "RJ_NO = '" + FileKey + "'";
                        PageRows = dt.Select(expression);
                        int row_Count = PageRows.Length;  //單號-總筆數

                        if (row_Count % row_page > 0)
                        {
                            Page = row_Count / row_page + 1;
                        }
                        else
                        {
                            Page = row_Count / row_page;
                        }
                        FileKey_ = FileKey;
                        if (FileKey_ != "")
                        {
                            doc.Close();
                        }

                        doc = new Document(PageSize.A4, 20, 15, 15, 15);

                        path = filepath + "\\RJ" + FileKey.Trim() + "_" + drt["SITE_NO"].ToString().Trim() + ".pdf";
                        if (path != "")
                        {
                            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
                            returnstring += "PDF產生完成  " + path;
                        }
                        else
                        {
                            returnstring += FileKey.Trim() + "  路徑有誤，請重新產生";
                            return returnstring;
                        }
                        doc.Open();
                        row_Count_Now = 0;
                    }
                    #endregion

                    row_Count_Now++;
                    row_Count_PDFNow++;

                    if ((row_Count_Now % row_page) == 1)
                    {
                        if (row_Count_Now > row_page)
                        {
                            doc.Add(p);
                            doc.Add(h_newline);
                            p = new PdfPTable(1);
                            p.WidthPercentage = 100;
                            pCell_tmp = new PdfPCell();
                            pCell_tmp = setTable_Cell(bfChinese, string.Format(@"{0} / {1} ", row_Count_PDFNow / row_page, Page)
                                , 0, Font_Size, Element.ALIGN_RIGHT, 1, 1);
                            p.AddCell(pCell_tmp);
                            doc.Add(p);
                            doc.NewPage();
                        }

                        #region 表頭
                        p = new PdfPTable(3);
                        p.WidthPercentage = 110;

                        pCell_tmp = setTable_Cell(bfChinese, "退貨通知單", 0, Font_Size + 4, Element.ALIGN_CENTER, 1, 1);
                        pCell_tmp.Colspan = 3;
                        pCell_tmp.PaddingTop = 7f;
                        p.AddCell(pCell_tmp);

                        //圖案
                        p.AddCell(jpgcell);

                        p.AddCell(setTable_Cell(bfChinese, string.Format("{0}越庫中心", drt["SITE_NO_DESCR"].ToString()), 0, Font_Size, Element.ALIGN_CENTER, 1, 1));

                        //條碼
                        h_Code.Clear();
                        h_Code.Alignment = Element.ALIGN_RIGHT;
                        h_Code.Font = new Font(bfCode, 11);//, Font.NORMAL,, BaseColor.BLACK);
                        h_Code.Add(string.Format("{0}", "*" + drt["RJ_NO"].ToString().Trim() + "*"));
                        pCell_tmp = new PdfPCell(h_Code);

                        pCell_tmp.Column.Alignment = Element.ALIGN_CENTER;
                        pCell_tmp.VerticalAlignment = Element.ALIGN_CENTER;
                        pCell_tmp.Colspan = 1;
                        pCell_tmp.Border = 0;
                        p.AddCell(pCell_tmp);

                        string strSD = DateTime.Parse(drt["ARRIVE_DATE"].ToString().Substring(0, 9)).ToString("yyyy/MM/dd");
                        string strED = DateTime.Parse(drt["CLOSE_DATE"].ToString().Substring(0, 9)).ToString("yyyy/MM/dd");

                        p.AddCell(setTable_Cell(bfChinese, string.Format("　　　　廠商：{0}", drt["VENDOR_NO"].ToString() + drt["VENDOR_NAME"].ToString()), Border_type_H, Font_Size, Element.ALIGN_LEFT, 1, 1, 7f));
                        p.AddCell(setTable_Cell(bfChinese, string.Format("　　通知日期：{0}", strSD), Border_type_H, Font_Size, Element.ALIGN_LEFT, 1, 1, 7f));
                        p.AddCell(setTable_Cell(bfChinese, string.Format("　　　　單號：{0}", drt["RJ_NO"]), Border_type_H, Font_Size, Element.ALIGN_LEFT, 1, 1, 7f));

                        p.AddCell(setTable_Cell(bfChinese, string.Format("　　列印時間：{0}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")), Border_type_H, Font_Size_8, Element.ALIGN_LEFT, 1, 1, 7f));
                        p.AddCell(setTable_Cell(bfChinese, string.Format("預計退貨日起迄：{0}", strSD + "~" + strED + "(" + drt["ARRIVE_START_TIME"].ToString().Trim() + "-" + drt["ARRIVE_END_TIME"].ToString().Trim() + ")"), Border_type_H, Font_Size_7, Element.ALIGN_LEFT, 1, 1, 7f));
                        p.AddCell(setTable_Cell(bfChinese, "　　　　客服電話:(886)0800335888", Border_type_H, Font_Size_8, Element.ALIGN_LEFT, 1, 1, 7f));

                        doc.Add(p);
                        doc.Add(h_newline);
                        #endregion

                        #region 表身的頭
                        p = new PdfPTable(7);
                        p.WidthPercentage = 100;

                        // int[] widths = {5, 20, 25, 10, 10,10,20 };
                        float[] widths = { 0.5f, 1.5f, 2.5f, 1.5f, 0.8f, 1.2f, 1.2f };
                        p.SetWidths(widths);

                        p.AddCell(setTable_Cell_Bottom(bfChinese, " ", Border_type, Font_Size, Element.ALIGN_CENTER, 1, 1));
                        p.AddCell(setTable_Cell_Bottom(bfChinese, "貨號／條碼", Border_type, Font_Size, Element.ALIGN_CENTER, 1, 1));
                        p.AddCell(setTable_Cell_Bottom(bfChinese, "貨品名稱／規格", Border_type, Font_Size, Element.ALIGN_CENTER, 1, 1));
                        p.AddCell(setTable_Cell_Bottom(bfChinese, "退貨量(pcs)", Border_type, Font_Size, Element.ALIGN_RIGHT, 1, 1));
                        p.AddCell(setTable_Cell_Bottom(bfChinese, "實退量", Border_type, Font_Size, Element.ALIGN_RIGHT, 1, 1));
                        p.AddCell(setTable_Cell_Bottom(bfChinese, "單位", Border_type, Font_Size, Element.ALIGN_CENTER, 1, 1));
                        p.AddCell(setTable_Cell_Bottom(bfChinese, "備註", Border_type, Font_Size, Element.ALIGN_CENTER, 1, 1));
                        #endregion
                    }
                    INNER_QTY = Convert.ToInt32(drt["INNER_QTY"].ToString());
                    QTY = Convert.ToInt32(drt["QTY"].ToString());

                    #region 表身明細
                    //序號 Table
                    p.AddCell(setTable_Cell(bfChinese, "", Border_type_H, Font_Size, Element.ALIGN_CENTER, 1, 1));//序號
                    p.AddCell(setTable_Cell(bfChinese, string.Format("{0}", drt["ITEM_NO"]), Border_type_H, Font_Size, Element.ALIGN_LEFT, 1, 1));//貨號
                    p.AddCell(setTable_Cell_Bottom(bfChinese, string.Format("{0}", drt["NAME"]), Border_type_H, Font_Size, Element.ALIGN_LEFT, 1, 2));//貨品名稱/規格
                    //p.AddCell(setTable_Cell_Bottom(string.Format("{0}", drt["RJT_QTY"]), Border_type_H, Font_Size, Element.ALIGN_RIGHT, 1, 2));//退貨量
                    p.AddCell(setTable_Cell_Bottom(bfChinese, string.Format("{0}", drt["QTY"]), Border_type_H, Font_Size, Element.ALIGN_RIGHT, 1, 2));//退貨量
                    p.AddCell(setTable_Cell_Bottom(bfChinese, string.Format("{0}", ""), Border_type_H, Font_Size, Element.ALIGN_CENTER, 1, 2));//實退量
                    p.AddCell(setTable_Cell_Bottom(bfChinese, string.Format("{0}", drt["EA_UNIT"]), Border_type_H, Font_Size, Element.ALIGN_CENTER, 1, 2));//單位
                    p.AddCell(setTable_Cell_Bottom(bfChinese, string.Format("{0}", ""), Border_type_H, Font_Size, Element.ALIGN_CENTER, 1, 2));//備註
                    p.AddCell(setTable_Cell_Bottom(bfChinese, string.Format("{0}", drt["ITEM_SEQ_NO"]), Border_type_H, Font_Size, Element.ALIGN_CENTER, 1, 1));//序號
                    p.AddCell(setTable_Cell_Bottom(bfChinese, string.Format("{0}", drt["EA_BARCODE"]), Border_type_H, Font_Size, Element.ALIGN_LEFT, 1, 1));
                    #endregion
                }
                doc.Add(p);
                doc.Add(h_newline);

                //尾頁
                p = PageEnd(bfChinese, doc, h_newline, p, Font_Size);
                //簽收
                PageEndSign(bfChinese, row_Count_Now, row_page, pageEnd, Font_Size, p, Page, doc);

            }
            catch (Exception err)
            {
                returnstring += "發生錯誤\n";
                throw new Exception(err.Message);
            }
            finally
            {
                doc.Close();
            }

            return returnstring;
        }

        //尾頁
        static private PdfPTable PageEnd(BaseFont bfChinese, Document doc, Paragraph h_newline, PdfPTable p, int Font_Size)
        {
            doc.Add(h_newline);
            p = new PdfPTable(7);
            p.WidthPercentage = 100;


            p.AddCell(setTable_Cell(bfChinese, "車號:", 0, Font_Size, Element.ALIGN_CENTER, 1, 1));
            p.AddCell(setTable_Cell(bfChinese, " ", 0, Font_Size, Element.ALIGN_CENTER, 1, 1));

            p.AddCell(setTable_Cell(bfChinese, "司機:", 0, Font_Size, Element.ALIGN_CENTER, 1, 1));
            p.AddCell(setTable_Cell(bfChinese, " ", 0, Font_Size, Element.ALIGN_CENTER, 1, 1));
            p.AddCell(setTable_Cell(bfChinese, "司機手機:", 0, Font_Size, Element.ALIGN_CENTER, 1, 1));
            p.AddCell(setTable_Cell(bfChinese, " ", 0, Font_Size, Element.ALIGN_CENTER, 1, 1));
            return p;
        }
        //簽收
        static private void PageEndSign(BaseFont bfChinese, int row_Count_PDFNow, int row_page, int pageEnd, int Font_Size, PdfPTable p, int Page, Document doc)
        {

            PdfPCell pCell_tmp = new PdfPCell();
            //int pageEnd;
            if (row_Count_PDFNow % row_page > 0)
            {
                pageEnd = row_Count_PDFNow / row_page + 1;
            }
            else
            {
                pageEnd = row_Count_PDFNow / row_page;
            }
            pCell_tmp = setTable_Cell(bfChinese, string.Format(@"{0} / {1} ", pageEnd, Page) //row_Count_PDFNow / row_page, row_Count / row_page
                , 0, Font_Size, Element.ALIGN_RIGHT, 3, 1);
            p.AddCell(pCell_tmp);
            p.AddCell(setTable_Cell(bfChinese, "物流簽收:", 0, Font_Size, Element.ALIGN_CENTER, 1, 1));
            p.AddCell(setTable_Cell(bfChinese, " ", 0, Font_Size, Element.ALIGN_CENTER, 1, 1));
            p.AddCell(setTable_Cell(bfChinese, " ", 0, Font_Size, Element.ALIGN_CENTER, 1, 1));
            p.AddCell(setTable_Cell(bfChinese, " ", 0, Font_Size, Element.ALIGN_CENTER, 1, 1));
            p.AddCell(setTable_Cell(bfChinese, " ", 0, Font_Size, Element.ALIGN_CENTER, 1, 1));
            p.AddCell(setTable_Cell(bfChinese, " ", 0, Font_Size, Element.ALIGN_CENTER, 1, 1));
            p.AddCell(setTable_Cell(bfChinese, " ", 0, Font_Size, Element.ALIGN_CENTER, 1, 1));
            doc.Add(p);

            //#region 單尾
            //int RowSpace = row_Count_PDFNow % row_page;
            //if (RowSpace > 0)
            //    RowSpace = (row_page - RowSpace) * 3;

            //PdfPTable p1 = new PdfPTable(4);
            //p1.WidthPercentage = 100;
            //for (int i = 0; i <= RowSpace; i++)
            //{
            //    p1.AddCell(setTable_Cell(bfChinese, " ", 0, Font_Size, Element.ALIGN_CENTER, 4, 1));
            //}
            //p1.AddCell(setTable_Cell(bfChinese, "    借用弘達物流堆高機卸貨__________板", 0, (int)(Font_Size * 1.5), Element.ALIGN_LEFT, 3, 1));
            //p1.AddCell(setTable_Cell(bfChinese, "司機簽名：", 0, (int)(Font_Size * 1.5), Element.ALIGN_LEFT, 1, 1));
            //doc.Add(p1);
            //#endregion

        }
        //Cell
        static private PdfPCell setTable_Cell(BaseFont bfChinese, string strText, int Border, int Size, int setAlignment, int Merage_Column, int Merage_Row)
        {
            Paragraph pg = new Paragraph();
            pg.Alignment = setAlignment;
            pg.Font = new Font(bfChinese, Size, Font.NORMAL + Font.NORMAL, BaseColor.BLACK);

            pg.SetLeading(2.0f, 0.9f);
            pg.Add(strText);

            PdfPCell pc = new PdfPCell(pg);
            pc.Colspan = Merage_Column;
            pc.Rowspan = Merage_Row;
            pc.Border = Border;
            pc.Column.Alignment = setAlignment;
            pc.HorizontalAlignment = setAlignment;
            pc.PaddingBottom = 7f;

            return pc;
        }
        //Cell_可指定與下行間距
        static private PdfPCell setTable_Cell(BaseFont bfChinese, string strText, int Border, int Size, int setAlignment, int Merage_Column, int Merage_Row, float PaddingBottom)
        {
            Paragraph pg = new Paragraph();
            pg.Alignment = setAlignment;
            pg.Font = new Font(bfChinese, Size, Font.NORMAL + Font.NORMAL, BaseColor.BLACK);

            pg.SetLeading(2.0f, 0.9f);
            pg.Add(strText);

            PdfPCell pc = new PdfPCell(pg);
            pc.Colspan = Merage_Column;
            pc.Rowspan = Merage_Row;
            pc.Border = Border;
            pc.Column.Alignment = setAlignment;
            pc.HorizontalAlignment = setAlignment;
            pc.PaddingBottom = PaddingBottom;

            return pc;
        }
        //有加底線的Cell
        static private PdfPCell setTable_Cell_Bottom(BaseFont bfChinese, string strText, int Border, int Size, int setAlignment, int Merage_Column, int Merage_Row)
        {
            Paragraph pg = new Paragraph();
            //pg.Alignment = Element.ALIGN_CENTER;
            pg.Alignment = setAlignment;
            pg.Font = new Font(bfChinese, Size, Font.NORMAL + Font.NORMAL, BaseColor.BLACK);
            pg.SetLeading(2.0f, 0.9f);
            pg.Add(strText);

            PdfPCell pc = new PdfPCell(pg);
            pc.Colspan = Merage_Column;
            pc.Rowspan = Merage_Row;
            pc.Border = Border;
            pc.Column.Alignment = setAlignment;
            pc.BorderWidthBottom = 1f;
            pc.HorizontalAlignment = setAlignment;
            pc.PaddingBottom = 7f;

            return pc;

        }
    }
}