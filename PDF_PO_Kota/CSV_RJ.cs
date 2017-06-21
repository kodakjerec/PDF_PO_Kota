using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace PDF_PO_Kota
{
    class CSV_RJ
    {
        static public DataTable CreatCSV_Prod(string PO, string siteno, string Host_string, string IP_string)
        {
            DataTable dt = new DataTable();

            //尋找RJ單
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.Conn_String))
            {
                SqlCommand cmd = new SqlCommand(
                "select "
                + "rj_no,site_no,vendor_no,ship_location_no,receive_place_addr,ship_location_addr,order_date,print_po_date,arrive_date,close_date,reject_type,ship_type,rcv_type,rjt_qty,line_rows,item_seq_no,item_no,ea_barcode,cs_barcode,vendor_item_no,packing_no,packing_memo,qty,ea_unit,inner_qty,cs_unit,name,site_no_descr,vendor_name,arrive_start_time,arrive_end_time"
                + " from V_EDI_BACK_R02_T where RJ_NO=@po_no and site_no=@siteno", conn);
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
