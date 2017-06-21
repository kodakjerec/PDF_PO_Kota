using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace PDF_PO_Kota
{
    public partial class CSV_PO
    {
        static public DataTable CreatCSV_Prod(string PO, string siteno, string Host_string, string IP_string)
        {
            DataTable dt = new DataTable();

            //尋找PO單
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.Conn_String))
            {
                SqlCommand cmd = new SqlCommand(
                "select "
                +"PO_NO,SITE_NO,VENDOR_NO,SHIP_LOCATION_NO,SHIP_LOCATION_ADDR,RECEIVE_PLACE_ADDR,ORDER_DATE,PRINT_PO_DATE,ARRIVE_DATE,CLOSE_DATE,DOCK_MODE,SHIP_TYPE,RCV_TYPE,ARRIVE_START_TIME,ARRIVE_END_TIME,LINE_ROWS,ITEM_SEQ_NO,ITEM_NO,EA_BARCODE,CS_BARCODE,VENDOR_ITEM_NO,LOT_NO,PACKING_NO,PACKING_MEMO,TI,HI,QTY,ADD_QTY,EA_UNIT,INNER_QTY,CS_UNIT,IS_IRREGULAR,IS_VALUABLES,ITEM_GP_TYPE,ALLOW_RECEIPT_DAY,MATURITIES_DAYS,MANUFACTURING_DAYS,DOCK_MODE_Descr,SHIP_TYPE_DESCR,NAME,SITE_NO_Descr,VENDOR_NAME,CARTON_QTY,SHIP_LOCATION_DESCR,TotalCase,Create_Date"
                +" from v_T_PO where PO_NO=@po_no and site_no=@siteno", conn);
                cmd.Parameters.AddWithValue("@po_no", PO);
                cmd.Parameters.AddWithValue("@siteno", siteno);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                //記錄log
                using (SqlConnection conn1 = new SqlConnection(Properties.Settings.Default.Conn_String))
                {
                    SqlCommand cmd1 = new SqlCommand(
                        "insert into LGDC.dbo.RunLog (JobID,JobType,JobDate,JobCmd,Crt_date) "
                        + " values('',"         //JobID
                        + "'手動產生CSV"        //JobType
                        + "',CONVERT(CHAR(10),GETDATE(),112)"   //JobDate
                        + ",'PDF_PO_Kota.exe " + PO
                            + "," + System.Security.Principal.WindowsIdentity.GetCurrent().Name
                            + "," + Host_string
                            + "," + IP_string//JobCmd
                        + "',GETDATE()) "    //Crt_date
                        , conn1);
                    cmd1.Connection.Open();
                    int OKcount = cmd1.ExecuteNonQuery();
                    cmd1.Connection.Close();
                }
            }
            return dt;
        }
    }
}
