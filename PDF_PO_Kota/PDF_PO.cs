using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Data;
using System;
using System.IO;
using System.Data.SqlClient;

namespace PDF_PO_Kota
{
    public partial class PDF_PO
    {

        static public string CreatPdf_Prod(XSC.ClientAccess.sqlClientAccess sca, string PO, string siteno, string Host_string, string IP_string, string Mainfilepath)
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
                #region 尋找PO單
                string sqlcommand =
                @"
                select 
                SITE_NO_Descr=SITE_NO_Descr+'['+DOCK_MODE_Descr+']',
                PO_NO,
                VENDOR_NO=VENDOR_NO+VENDOR_Name,
                ARRIVE_DATE,
                ARRIVE_START_TIME=ARRIVE_START_TIME+'-'+ARRIVE_END_TIME,
                RECEIVE_PLACE_ADDR,
                remark,
                remark2,
                SITE_NO,
                ITEM_SEQ_NO,
                ITEM_NO=ITEM_NO+CASE WHEN WARM_LAYER!='' THEN '('+WARM_LAYER+')' ELSE '' END,
                NAME,
                QTY,
                IP_QTY,
                WARM_LAYER,

                EA_Barcode,
                INNER_QTY,
                MANUFACTURING_DAYS=CASE WHEN MANUFACTURING_DAYS=MATURITIES_DAYS THEN '無保存期限' ELSE Replace(MATURITIES_DAYS,'/','')+'後生產' END,
                MATURITIES_DAYS=CASE WHEN MANUFACTURING_DAYS=MATURITIES_DAYS THEN '' ELSE Replace(MATURITIES_DAYS,'/','')+'後到期' END,
                IP_Barcode,

                CS_Barcode,
                Packing_memo,
                Carton_QTY=convert(varchar,Carton_QTY)+CS_UNIT,
                VENDOR_ITEM_NO,
                TI=convert(varchar,TI)+'底/'+convert(varchar,HI)+'高',
                TotalCase
                from v_T_PO 
                where PO_NO=@po_no 
                and site_no=@site_no";
                object[] scaParam = {"@po_no" ,"NVarChar",PO,
                                         "@site_no","NVarChar",siteno };
                dt = sca.GetDataTable("EDI_DC", sqlcommand, scaParam, 0);
                dt.TableName = "v_T_PO";
                if (dt.Rows.Count == 0)
                {
                    returnstring += "找不到資料，請確認PO單號存在";
                    return returnstring;
                }
                #endregion

                #region 記錄log
                sqlcommand = "insert into RunLog (JobID,JobType,JobDate,JobCmd,Crt_date) "
                        + " values('',"         //JobID
                        + "'手動產生PDF"        //JobType
                        + "',CONVERT(CHAR(10),GETDATE(),112)"   //JobDate
                        + ",'PDF_PO_Kota.exe " + PO
                            + "," + System.Security.Principal.WindowsIdentity.GetCurrent().Name
                            + "," + Host_string
                            + "," + IP_string//JobCmd
                        + "',GETDATE()) ";    //Crt_date
                sca.Update("LGDC", sqlcommand, scaParam, 0);
                #endregion

                DataRow dr = dt.Rows[0];

                FileKey = dr["PO_NO"].ToString();
                string FileKey_ = "";

                PdfPCell pCell_tmp;
                PdfPTable p;
                int Font_Size = 10;

                #region Logo

                //  公司Logo
                string Img_url = Environment.CurrentDirectory + "\\WMSADJ\\logo.jpg";
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(new Uri(Img_url));

                jpg.ScalePercent(60);

                PdfPCell jpgcell = new PdfPCell(jpg);
                jpgcell.Border = 0;
                jpgcell.Colspan = 2;
                jpgcell.Column.Alignment = Element.ALIGN_CENTER;
                jpgcell.VerticalAlignment = Element.ALIGN_CENTER;
                #endregion

                int INNER_QTY = 0;
                int QTY = 0;
                int QTY_div_INNER_QTY = 0;

                // 分頁
                int row_page = 13; //每頁幾筆
                int row_Count_PDFNow = 0; //pdf第幾頁
                int row_Count_Now = 0;    //第幾筆
                int Page = 0; //總頁碼
                int pageEnd = 0; //結束頁

                p = new PdfPTable(3);
                string strTotalCase = "";
                foreach (DataRow drt in dt.Rows)
                {
                    FileKey = drt["PO_NO"].ToString();

                    #region 允收日期    2014/01/07
                    string RecDateS = "", RecDateE = "";
                    if (drt["MANUFACTURING_DAYS"].ToString() == drt["MATURITIES_DAYS"].ToString())
                    {
                        RecDateS = "無保存期限";
                        RecDateE = "";
                    }
                    else
                    {
                        RecDateS = string.Format("{0:yyyy/MM/dd}", drt["MANUFACTURING_DAYS"]).Replace("/", "") + "後生產";
                        RecDateE = string.Format("{0:yyyy/MM/dd}", drt["MATURITIES_DAYS"]).Replace("/", "") + "後到期";
                    }
                    #endregion

                    #region 溫層 2014/01/07
                    string WarmLayer = "";
                    if (drt["WARM_LAYER"].ToString() != "")
                    {
                        WarmLayer = "(" + drt["WARM_LAYER"].ToString() + ")";
                    }
                    #endregion

                    #region 單據不同則產生單據
                    if (FileKey_ != FileKey)
                    {

                        if (FileKey_ != "")
                        {
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
                        expression = "PO_NO = '" + FileKey + "'";
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

                        doc = new Document(PageSize.A4, 20, 15, 15, 15);

                        path = filepath + "\\" + FileKey.Trim() + "_" + drt["SITE_NO"].ToString().Trim() + ".pdf";
                        if (path != "")
                        {
                            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
                            writer.PageEvent = new PDFFooter();

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

                    #region 換頁時重印單頭
                    if ((row_Count_Now % row_page) == 1)
                    {
                        if (row_Count_Now > row_page)
                        {
                            doc.Add(p);
                            doc.Add(h_newline);
                            p = new PdfPTable(1);
                            p.WidthPercentage = 100;
                            pCell_tmp = new PdfPCell();


                            pCell_tmp = setTable_Cell(bfChinese, string.Format(@"{0} / {1} ", row_Count_PDFNow / row_page, Page)//row_Count / row_page
                                , 0, Font_Size, Element.ALIGN_RIGHT, 3, 1);
                            p.AddCell(pCell_tmp);
                            doc.Add(p);

                            doc.NewPage();
                        }

                        #region 表頭
                        p = new PdfPTable(5);
                        p.WidthPercentage = 110;

                        //送貨通知單
                        pCell_tmp = setTable_Cell(bfChinese, "送貨通知單", 0, Font_Size + 4, Element.ALIGN_CENTER, 1, 1);
                        pCell_tmp.Colspan = 5;
                        pCell_tmp.PaddingTop = 7f;
                        p.AddCell(pCell_tmp);

                        //Logo
                        p.AddCell(jpgcell);

                        //ex:觀音物流中心[越庫馬頭]
                        p.AddCell(setTable_Cell(bfChinese, string.Format("{0}", drt["SITE_NO_Descr"]), 0, Font_Size, Element.ALIGN_CENTER, 1, 1, 7f));//SITE_NO,SITE_NO_Descr,DOCK_MODE_Descr

                        // 條碼
                        h_Code.Clear();
                        h_Code.Alignment = Element.ALIGN_RIGHT;
                        h_Code.Font = new Font(bfCode, 12);//, Font.NORMAL,, BaseColor.BLACK);
                        h_Code.Add(string.Format("{0}", "*" + drt["PO_NO"] + "*"));
                        pCell_tmp = new PdfPCell(h_Code);
                        pCell_tmp.Border = 0;
                        pCell_tmp.Colspan = 2;
                        pCell_tmp.Column.Alignment = Element.ALIGN_CENTER;
                        pCell_tmp.VerticalAlignment = Element.ALIGN_CENTER;
                        p.AddCell(pCell_tmp);

                        //  p.AddCell(setTable_Cell(string.Format("單號:{0}", drt["PO_NO"]), 0, Font_Size, Element.ALIGN_CENTER, 2, 1));
                        p.AddCell(setTable_Cell(bfChinese, string.Format("　　　　廠商:{0}", drt["VENDOR_NO"]), 0, Font_Size, Element.ALIGN_LEFT, 2, 1, 7f));
                        p.AddCell(setTable_Cell(bfChinese, string.Format("　　到貨日期:{0}", drt["ARRIVE_DATE"].ToString().Substring(0, 10)), 0, Font_Size, Element.ALIGN_LEFT, 1, 1, 7f));
                        p.AddCell(setTable_Cell(bfChinese, string.Format("　　　　　　　　單號:{0}", drt["PO_NO"]), 0, Font_Size, Element.ALIGN_LEFT, 2, 1, 7f));


                        p.AddCell(setTable_Cell(bfChinese, string.Format("　　列印時間:{0}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")), 0, Font_Size, Element.ALIGN_LEFT, 2, 1, 7f));
                        p.AddCell(setTable_Cell(bfChinese, string.Format("預計進廠起迄:{0}", drt["ARRIVE_START_TIME"]), 0, Font_Size, Element.ALIGN_LEFT, 1, 1, 7f));
                        p.AddCell(setTable_Cell(bfChinese, "　　　　　　客服電話:(886)0800335888", 0, Font_Size, Element.ALIGN_LEFT, 2, 1, 7f));

                        p.AddCell(setTable_Cell(bfChinese, string.Format("　　到貨地址:{0}", drt["RECEIVE_PLACE_ADDR"].ToString().Trim()), 0, Font_Size, Element.ALIGN_LEFT, 2, 1, 7f));
                        p.AddCell(setTable_Cell(bfChinese, string.Format("{0}", drt["remark"]), 0, Font_Size, Element.ALIGN_LEFT, 3, 1, 7f));

                        p.AddCell(setTable_Cell(bfChinese, string.Format("{0}", drt["remark2"]), 0, Font_Size, Element.ALIGN_CENTER, 5, 1, 7f));


                        //// 空行
                        p.AddCell(pCell_tmp);

                        doc.Add(p);

                        #endregion

                        #region 表身的頭
                        float[] widths = { 0.5f, 1.5f, 2f, 1.4f, 0.6f, 1.5f, 1.2f };
                        p = new PdfPTable(widths);//7
                        p.WidthPercentage = 100;

                        p.AddCell(setTable_Cell_Bottom(bfChinese, " ", 0, Font_Size - 1, Element.ALIGN_CENTER, 1, 3));
                        p.AddCell(setTable_Cell_Bottom(bfChinese, "貨號/條碼/外箱條碼", 0, Font_Size - 1, Element.ALIGN_CENTER, 1, 3));
                        p.AddCell(setTable_Cell_Bottom(bfChinese, "貨品名稱/規格/包裝組別", 0, Font_Size - 1, Element.ALIGN_CENTER, 1, 3));
                        p.AddCell(setTable_Cell_Bottom(bfChinese, "訂購量/入數/箱數", 0, Font_Size - 1, Element.ALIGN_CENTER, 1, 3));
                        p.AddCell(setTable_Cell_Bottom(bfChinese, "實收量", 0, Font_Size - 1, Element.ALIGN_CENTER, 1, 3));
                        p.AddCell(setTable_Cell_Bottom(bfChinese, "允收日期/廠商貨號", 0, Font_Size - 1, Element.ALIGN_CENTER, 1, 3));
                        p.AddCell(setTable_Cell_Bottom(bfChinese, "小包裝/棧板堆疊", 0, Font_Size - 1, Element.ALIGN_CENTER, 1, 3));
                        #endregion
                    }
                    #endregion

                    INNER_QTY = Convert.ToInt32(drt["INNER_QTY"].ToString());
                    QTY = Convert.ToInt32(drt["QTY"].ToString());

                    #region 表身明細
                    //序號 Table
                    //
                    p.AddCell(setTable_Cell_Bottom(bfChinese, string.Format("{0}", drt["ITEM_SEQ_NO"]), 0, Font_Size, Element.ALIGN_CENTER, 1, 3));//ITEM_SEQ_NO
                    //貨號
                    p.AddCell(setTable_Cell(bfChinese, string.Format("{0}", drt["ITEM_NO"]) + WarmLayer, 0, Font_Size, Element.ALIGN_LEFT, 1, 1));
                    //貨品名稱
                    p.AddCell(setTable_Cell(bfChinese, string.Format("{0}", drt["NAME"]), 0, Font_Size - 1, Element.ALIGN_MIDDLE, 1, 2));
                    //訂購量
                    p.AddCell(setTable_Cell(bfChinese, string.Format("{0}", QTY), 0, Font_Size, Element.ALIGN_RIGHT, 1, 1));
                    //實收量
                    p.AddCell(setTable_Cell_Bottom(bfChinese, string.Format("{0}", ""), 0, Font_Size, Element.ALIGN_CENTER, 1, 3));
                    //允收日期1
                    p.AddCell(setTable_Cell(bfChinese, RecDateS, 0, Font_Size - 1, Element.ALIGN_CENTER, 1, 1));
                    //小包裝
                    //0 和 null 都要顯示 ""
                    Object IP_qty;
                    switch (drt["IP_QTY"].ToString())
                    {
                        case "0": IP_qty = ""; break;
                        default: IP_qty = drt["IP_QTY"]; break;
                    }
                    p.AddCell(setTable_Cell(bfChinese, string.Format("{0}", IP_qty), 0, Font_Size, Element.ALIGN_RIGHT, 1, 1));

                    //資料列 第2排----------------------------------------------------------------------------------------------------------
                    //條碼
                    p.AddCell(setTable_Cell(bfChinese, string.Format("{0}", drt["EA_BARCODE"]), 0, Font_Size, Element.ALIGN_LEFT, 1, 1));
                    //入數
                    p.AddCell(setTable_Cell(bfChinese, string.Format("{0}", INNER_QTY), 0, Font_Size, Element.ALIGN_RIGHT, 1, 1));
                    //允收日期2
                    p.AddCell(setTable_Cell(bfChinese, RecDateE, 0, Font_Size - 1, Element.ALIGN_CENTER, 1, 1));
                    //棧板堆疊-底
                    p.AddCell(setTable_Cell(bfChinese, string.Format("{0}", drt["IP_Barcode"]), 0, Font_Size, Element.ALIGN_RIGHT, 1, 1));

                    //資料列 第3排-------------------------------------------------------------------------------------------------------------------------------------
                    //外箱條碼
                    p.AddCell(setTable_Cell_Bottom(bfChinese, string.Format("{0}", drt["CS_BARCODE"]), 0, Font_Size, Element.ALIGN_LEFT, 1, 1));
                    //贈品
                    p.AddCell(setTable_Cell_Bottom(bfChinese, string.Format("{0}", drt["Packing_memo"]), 0, Font_Size, Element.ALIGN_CENTER, 1, 1));
                    if (INNER_QTY != 0) QTY_div_INNER_QTY = QTY / INNER_QTY; else QTY_div_INNER_QTY = 0;
                    //箱數
                    p.AddCell(setTable_Cell_Bottom(bfChinese, string.Format("{0}", drt["Carton_QTY"]), 0, Font_Size, Element.ALIGN_RIGHT, 1, 1));
                    //廠商貨號
                    p.AddCell(setTable_Cell_Bottom(bfChinese, string.Format("{0}", drt["VENDOR_ITEM_NO"]), 0, Font_Size, Element.ALIGN_CENTER, 1, 1));
                    //棧板堆疊-高
                    p.AddCell(setTable_Cell_Bottom(bfChinese, string.Format("{0}", drt["TI"]), 0, Font_Size, Element.ALIGN_RIGHT, 1, 1));

                    strTotalCase = drt["TotalCase"].ToString();

                    #endregion
                }
                doc.Add(p);
                doc.Add(h_newline);
                //總箱量
                setTable_Boxes(bfChinese, p, Font_Size, strTotalCase, doc);


                //尾頁
                p = PageEnd(bfChinese, doc, h_newline, p, Font_Size);
                //簽收
                PageEndSign(bfChinese, row_Count_Now, row_page, pageEnd, Font_Size, p, Page, doc);

            }
            catch (Exception err)
            {
                returnstring += "發生錯誤\n" + err.Message + "\n";
                //throw new Exception(err.Message);
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

            #region 單尾
            int RowSpace = row_Count_PDFNow % row_page;
            if (RowSpace > 0)
                RowSpace = (row_page - RowSpace) * 3;

            PdfPTable p1 = new PdfPTable(4);
            p1.WidthPercentage = 100;
            for (int i = 0; i <= RowSpace; i++)
            {
                p1.AddCell(setTable_Cell(bfChinese, " ", 0, Font_Size, Element.ALIGN_CENTER, 4, 1));
            }
            p1.AddCell(setTable_Cell(bfChinese, "    借用弘達物流堆高機卸貨__________板", 0, (int)(Font_Size * 1.5), Element.ALIGN_LEFT, 3, 1));
            p1.AddCell(setTable_Cell(bfChinese, "司機簽名：", 0, (int)(Font_Size * 1.5), Element.ALIGN_LEFT, 1, 1));
            doc.Add(p1);
            #endregion

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
            pc.PaddingBottom = 1f;

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
        //總箱量顯示
        static private void setTable_Boxes(BaseFont bfChinese, PdfPTable p, int Font_Size, string strTotalCase, Document doc)
        {
            p = new PdfPTable(7);
            p.AddCell(setTable_Cell(bfChinese, "", 0, Font_Size, Element.ALIGN_CENTER, 2, 1));
            p.AddCell(setTable_Cell(bfChinese, string.Format("總箱量:{0}箱", strTotalCase), 0, Font_Size + 4, Element.ALIGN_RIGHT, 2, 1));
            p.AddCell(setTable_Cell(bfChinese, "", 0, Font_Size, Element.ALIGN_CENTER, 3, 1));
            doc.Add(p);
        }
    }

    //單首 頁首 頁尾
    public class PDFFooter : PdfPageEventHelper
    {
        #region 單首
        // write on top of document
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            base.OnOpenDocument(writer, document);
            //PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            //tabFot.SpacingAfter = 10F;
            //PdfPCell cell;
            //tabFot.TotalWidth = 300F;
            //cell = new PdfPCell(new Phrase("Header"));
            //tabFot.AddCell(cell);
            //tabFot.WriteSelectedRows(0, -1, 150, document.Top, writer.DirectContent);
        }
        #endregion

        #region 頁首
        // write on start of each page
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
            //PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            //tabFot.SpacingAfter = 10F;
            //PdfPCell cell;
            //tabFot.TotalWidth = 300F;
            //cell = new PdfPCell(new Phrase("Start"));
            //tabFot.AddCell(cell);
            //tabFot.WriteSelectedRows(0, -1, 150, document.Top, writer.DirectContent);
        }
        #endregion

        #region 頁尾
        // write on end of each page
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            //PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            //PdfPCell cell;
            //tabFot.TotalWidth = 300F;
            //cell = new PdfPCell(new Phrase("Footer"));
            //tabFot.AddCell(cell);
            //tabFot.WriteSelectedRows(0, -1, 150, document.Bottom, writer.DirectContent);
        }


        //write on close of document
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
        }
        #endregion

        //單尾請搜尋"單尾"
    }
}