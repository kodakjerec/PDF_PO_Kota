using System.Data;
using System;

namespace PDF_PO_Kota
{
    public partial class PDF_PO_v2
    {

        static public string CreatPdf_Prod(XSC.ClientAccess.sqlClientAccess sca, string PO, string siteno, string Host_string, string IP_string, string Mainfilepath)
        {
            string returnstring = "";
            string filepath = Mainfilepath;
            string path;    //檔案路徑
            DataTable dt = new DataTable();

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
                MANUFACTURING_DAYS=CASE WHEN MANUFACTURING_DAYS=MATURITIES_DAYS THEN '無保存期限' ELSE Replace(MATURITIES_DAYS,'/','') END,
                MATURITIES_DAYS=CASE WHEN MANUFACTURING_DAYS=MATURITIES_DAYS THEN '' ELSE Replace(MATURITIES_DAYS,'/','') END,
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

                XtraReport_PO xReport1 = new XtraReport_PO();
                xReport1.DataSource = dt;
                xReport1.DataMember = dt.TableName;

                path = filepath + "\\" + PO + "_" + siteno + ".pdf";
                if (path != "")
                {
                    xReport1.ExportToPdf(path);

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

                    returnstring += "PDF產生完成  " + path;
                }
                else
                {
                    returnstring += PO + "  路徑有誤，請重新產生";
                }
            }
            catch (Exception err)
            {
                returnstring += "發生錯誤\n" + err.Message + "\n";
                //throw new Exception(err.Message);
            }
            finally
            {
            }
            return returnstring;
        }
    }
}