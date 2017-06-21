using System.Data;
using System;

namespace PDF_PO_Kota
{
    public partial class PDF_RJ_v2
    {

        static public string CreatPdf_Prod(XSC.ClientAccess.sqlClientAccess sca, string RJ, string siteno, string Host_string, string IP_string, string Mainfilepath)
        {
            string returnstring = "";
            string filepath = Mainfilepath;
            string path;    //檔案路徑
            DataTable dt = new DataTable();

            try
            {
                #region 尋找PO單
                string sqlcommand =
                @"select 
                SITE_NO_DESCR
                ,RJ_NO
                ,VENDOR_NO=VENDOR_NO+VENDOR_NAME
                ,ARRIVE_DATE=convert(varchar,ARRIVE_DATE,111)
                ,ARRIVE_START_DATE=convert(varchar,ARRIVE_DATE,111)+'~'+ convert(varchar,CLOSE_DATE,111)
                ,ARRIVE_START_TIME='('+ARRIVE_START_TIME+'-'+ARRIVE_END_TIME+')'
                ,ITEM_SEQ_NO
                ,ITEM_NO
                ,EA_BARCODE
                ,NAME
                ,QTY
                ,EA_UNIT
                from V_EDI_BACK_R02_T 
                where RJ_NO=@po_no and site_no=@site_no";
                object[] scaParam = {"@po_no" ,"NVarChar",RJ,
                                         "@site_no","NVarChar",siteno };
                dt = sca.GetDataTable("EDI_DC", sqlcommand, scaParam, 0);
                dt.TableName = "V_EDI_BACK_R02_T";
                if (dt.Rows.Count == 0)
                {
                    returnstring += "找不到資料，請確認RJ單號存在";
                    return returnstring;
                }
                #endregion

                XtraReport_RJ xReport1 = new XtraReport_RJ();
                xReport1.DataSource = dt;
                xReport1.DataMember = dt.TableName;

                path = filepath + "\\" + "RJ" + RJ + "_" + siteno + ".pdf";
                if (path != "")
                {
                    xReport1.ExportToPdf(path);

                    #region 記錄log
                    sqlcommand = "insert into RunLog (JobID,JobType,JobDate,JobCmd,Crt_date) "
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

                    returnstring += "PDF產生完成  " + path;
                }
                else
                {
                    returnstring += RJ + "  路徑有誤，請重新產生";
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