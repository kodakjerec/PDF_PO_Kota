using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Reflection;

namespace PDF_PO_Kota
{
    /// <summary>
    /// v1.0 從Jason那邊將產出pdf更改成人工產生
    /// v1.1 增加碼頭類型,調整成與關貿相同
    /// v1.2 PO單增加單尾的備註內容
    ///      版面設定做成OO化,將尾頁和簽收函數化
    ///      (關閉)PO單增設可自訂 頁首/頁尾/單頭 的功能
    /// v1.3 PO單增加IP_Barcode
    /// v1.4 程式改為Devexpress產出, 內容增加remark, remark2
    /// </summary>
    public partial class Form1 : Form
    {
        //此表單的LoaderFormInfo
        XSC.LoaderFormInfo fFormInfo;

        //此LoginUserId所使用的sqlClientAccess
        XSC.ClientAccess.sqlClientAccess sca;

        SqlDataAdapter sda = new SqlDataAdapter();
        BindingSource BS = new BindingSource();
        DataTable dt_POList = new DataTable();

        string filepath = "";  //檔案輸出路徑

        public Form1()
        {
            InitializeComponent();
            btn_CrtPDF.GotFocus += new EventHandler(button_CrfPDF_GotFocus);
            btn_CrtPDF.LostFocus += new EventHandler(button_CrfPDF_LostFocus);
            txb_POID.TextChanged += new EventHandler(textBox_POID_TextChanged);
            ResizeForm.ResizeForm.WSC_Resize(this, 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "PO,RJ 產生PDF v" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion.ToString();

            //取得此表單的LoaderFormInfo
            fFormInfo = XSC.ClientLoader.FormInfo(this);
            //透過LoginUserId取得sqlClientAccess
            sca = XSC.ClientAccess.UserAccess.sqlUserAccess(fFormInfo.LoginUserId);
            label_Host.Text = fFormInfo.UserId;//fFormInfo.UserId;
            IPAddress[] iplist = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            bool ismatch;
            foreach (IPAddress ip in iplist)
            {
                ismatch = Regex.IsMatch(ip.ToString(), ("^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$"));
                if (ismatch == true)
                {
                    label_IP.Text = ip.ToString() + "\n";
                    break;
                }
            }

            //設定預設值
            cmb_DockMode.SelectedIndex = 0;
            txb_POID.Text = "P" + DateTime.Today.AddDays(-2).ToString("yyyyMMdd").Substring(2, 4);
            rdb_SelectPO.ForeColor = Color.Red;

            SetStatusString(0);
            label3.Text = "長度：" + txb_POID.Text.Length.ToString() + " (Max 13)";
            label5.Text = "長度：" + txb_SupID.Text.Length.ToString() + " (Max 4)";

            dtp_BDate.Value = DateTime.Today.AddDays(-3);
            dtp_EDate.Value = DateTime.Today.AddDays(3);

            //測試時使用
            //textBox_POID.Text = "5714010100080";
            //dateTimePicker1.Value = DateTime.Today.AddDays(-20);

            radioButton1_CheckedChanged(rdb_SelectPO, e);
        }

        #region Form_view
        //POID字串長度變更
        void textBox_POID_TextChanged(object sender, EventArgs e)
        {
            label3.Text = "長度：" + txb_POID.Text.Length.ToString() + " (Max 13)";
        }
        //SupID字串長度變更
        private void textBox_supID_TextChanged(object sender, EventArgs e)
        {
            label5.Text = "長度：" + txb_SupID.Text.Length.ToString() + " (Max 4)";
        }
        //離開目標
        void button_CrfPDF_LostFocus(object sender, EventArgs e)
        {
            btn_CrtPDF.ForeColor = Color.Black;
        }
        //進入目標
        void button_CrfPDF_GotFocus(object sender, EventArgs e)
        {
            btn_CrtPDF.ForeColor = Color.Brown;
        }
        //PO單號
        private void textBox_POID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_CrtPDF.Select();
        }
        //離開主選單跳出視窗
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            this.DialogResult = MessageBox.Show("確定離開 " + this.Text + " ??", "離開確認", MessageBoxButtons.YesNo);
            if (this.DialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        //FORM按下離開
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        //更改提示視窗字串
        string[] StatusString = {"請輸入搜尋條件並按下【搜尋】按鈕\n【Alt+F】 搜尋\n【Alt+C】 產生PDF\n",
                                 "搜尋完畢:)\n單擊【選取】可全部單據 全選/不選\n",
                                 "無資料被選取\n",
                                 "PDF產生中‧‧‧請等待儲存視窗跳出\n",
                                 "搜尋中，請稍後\n"};
        private void SetStatusString(int Para)
        {
            txb_Status.Text = StatusString[Para];
            txb_Status.Refresh();
        }
        #endregion

        #region Form_Control
        //搜尋按鈕
        private void btn_Search_Click(object sender, EventArgs e)
        {
            SetStatusString(4);
            Cursor = Cursors.WaitCursor;
            string Search_String = "";    //變動類型的查詢字串
            string sqlcommand = "";

            try
            {
                object[] scaParam = {"@supid","NVarChar",txb_SupID.Text,
                                   "@Bdate","NVarChar",dtp_BDate.Text,
                                   "@Edate","NVarChar",dtp_EDate.Text,
                                   "@POID" ,"NVarChar",txb_POID.Text+'%',
                                   "@site_no","NVarChar",txb_SiteNo.Text};  //傳遞變數

                if (rdb_SelectPO.Checked)
                {
                    #region 變動類型的查詢字串
                    //碼頭
                    switch (cmb_DockMode.SelectedIndex)
                    {
                        case 1: Search_String += " and Dock_Mode='A' "; break;
                        case 2: Search_String += " and Dock_Mode='M' "; break;
                        default: break;
                    }
                    //供應商
                    if (txb_SupID.Text != "")
                    {
                        Search_String += " and vendor_no = @supid";
                    }
                    //倉別
                    if (txb_SiteNo.Text.Length > 2)
                    {
                        Search_String += " and site_no =@site_no ";
                    }
                    #endregion

                    sqlcommand =
                    @"select 
                    Arrive_date
                    ,Site_no
                    ,po_no
                    ,vendor_no
                    ,Dock_Mode_Descr
                    ,Check1=0
                    ,[rows]=count(1)
                    from v_T_PO
                    where 1=1
                    and Arrive_Date Between @Bdate and @Edate
                    and po_no like @POID "
                    + Search_String
                    + @" group by Arrive_date,site_no,po_no,vendor_no,Dock_MODE_Descr
                       order by site_no,po_no";

                    dt_POList = sca.GetDataTable("EDI_DC", sqlcommand, scaParam, 0);
                    gridControl2.DataSource = dt_POList;
                    SetStatusString(1);
                }
                else if (rdb_SelectRJ.Checked)
                {
                    #region 變動類型的查詢字串
                    //供應商
                    if (txb_SupID.Text != "")
                    {
                        Search_String += " and vendor_no = @supid";
                    }
                    //倉別
                    if (txb_SiteNo.Text.Length > 2)
                    {
                        Search_String += " and site_no =@site_no ";
                    }
                    #endregion

                    sqlcommand =
                    @"select 
                    Arrive_date
                    ,Site_no
                    ,RJ_NO as po_no
                    ,vendor_no
                    ,'' as Dock_Mode_Descr
                    ,0 as Check1 
                    ,[rows]=count(1)
                    from V_EDI_BACK_R02_T 
                    where 1=1 
                    and Arrive_Date Between @Bdate and @Edate 
                    and rj_no like @POID "
                    + Search_String
                    + @" group by Arrive_date,site_no,rj_no,vendor_no 
                         order by site_no,rj_no";

                    dt_POList = sca.GetDataTable("EDI_DC", sqlcommand, scaParam, 0);
                    gridControl2.DataSource = dt_POList;
                    SetStatusString(1);
                }
                else if (rdb_SelectLOG.Checked)
                {
                    #region 變動類型的查詢字串
                    //PO單號
                    if (txb_POID.Text != "")
                    {
                        Search_String += " and (b.ID like @POID or c.RJ_NO like @POID)";
                    }
                    //供應商編號
                    if (txb_SupID.Text != "")
                    {
                        Search_String += " and (substring(b.SELLER_STR_ID,1,4)=@supid or substring(c.VENDOR_NO,1,4)=@supid)";
                    }
                    //倉別
                    if (txb_SiteNo.Text.Length > 2)
                    {
                        Search_String += " and (b.BUYER_STR_ID=@site_no or c.SITE_NO=@site_no ";
                    }
                    #endregion

                    sqlcommand =
                    @"Select a.JobCmd, a.JobDate
                    FROM (
                    select JobCmd,JobDate
                    ,PONO=CASE SUBSTRING(JobCmd,17,1) 
							WHEN 'P' THEN SUBSTRING(JobCmd,CHARINDEX('P',JobCmd,10),13)
							WHEN '5' THEN SUBSTRING(JobCmd,CHARINDEX('5',JobCmd,10),13)
						END
                    from RunLog
                    where JobType='手動產生PDF'
	                    and Crt_Date BETWEEN @Bdate and @Edate) a
                    left join 
						edi.dbo.EDI_CRP_PO_HEADER b
                    on 
						a.PONO=b.ID
					left JOIN
						edi.dbo.V_EDI_BACK_R02_T c
					ON
						a.PONO=c.RJ_NO
                    where 1=1 "
                    + Search_String
                    + " order by a.JobDate desc";
                    dt_POList = sca.GetDataTable("LGDC", sqlcommand, scaParam, 0);

                    //XSC使用者名單
                    DataTable XSCUserList = sca.GetDataTable("EEPDC", "select XSC_UserID, HECName from xsc_menu_userlist where XSC_UserID!='' ", scaParam, 0);
                    //加入primaryKey
                    DataColumn[] keys_XSCUserList = new DataColumn[1];
                    keys_XSCUserList[0] = XSCUserList.Columns["XSC_UserID"];
                    XSCUserList.PrimaryKey = keys_XSCUserList;

                    DataTable dtLogResult = new DataTable();
                    dtLogResult.Columns.Add("Logcol_PONO", typeof(String));
                    dtLogResult.Columns.Add("Logcol_CrtDate", typeof(String));
                    dtLogResult.Columns.Add("Logcol_XSCUserID", typeof(String));
                    dtLogResult.Columns.Add("Logcol_IP", typeof(String));
                    dtLogResult.Columns.Add("Logcol_UserName", typeof(String));

                    foreach (DataRow dr in dt_POList.Rows)
                    {
                        string[] strlist = dr["JobCmd"].ToString().Split(',');
                        DataRow dr1 = dtLogResult.NewRow();
                        //PONO
                        dr1[0] = strlist[0].Replace("PDF_PO_Kota.exe ", "");
                        //CrtDate
                        dr1[1] = dr["JobDate"].ToString();
                        //XSCUserID
                        dr1[2] = strlist[2];
                        //IP
                        dr1[3] = strlist[3];
                        //UserName
                        string UserName = "";
                        DataRow[] dr_UserName = XSCUserList.Select("XSC_UserID='" + strlist[2].ToString() + "'");
                        if (dr_UserName.Length > 0)
                        {
                            UserName = dr_UserName[0][1].ToString();
                        }
                        dr1[4] = UserName;
                        dtLogResult.Rows.Add(dr1);
                    }
                    gridControl1.DataSource = dtLogResult;
                    SetStatusString(1);
                }

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        //產生PDF
        private void btn_CrtPDF_Click(object sender, EventArgs e)
        {
            btn_CrtPDF.Enabled = false;

            #region 產生Log
            if (rdb_SelectLOG.Checked)
            {
                DataTable FinalTable = gridControl1.DataSource as DataTable;
                if (FinalTable == null)
                {
                    SetStatusString(2);
                    goto btn_CrtPDF_END;
                }
                if (FinalTable.Rows.Count <= 0)
                {
                    SetStatusString(2);
                    goto btn_CrtPDF_END;
                }

                if (filepath == "")
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    fbd.ShowDialog();
                    filepath = fbd.SelectedPath;
                }
                string Final_filepath = filepath + "\\PDF_PO_Log_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";
                gridControl1.ExportToPdf(Final_filepath);
                txb_Status.Text += "PDF產生完成  " + Final_filepath + "\n";
            }
            #endregion

            #region 產生PO/RJ
            if (rdb_SelectPO.Checked || rdb_SelectRJ.Checked)
            {
                DataTable FinalTable = gridControl2.DataSource as DataTable;
                if (FinalTable == null)
                {
                    SetStatusString(2);
                    goto btn_CrtPDF_END;
                }

                if (FinalTable.Rows.Count <= 0)
                {
                    SetStatusString(2);
                    goto btn_CrtPDF_END;
                }
                SetStatusString(3);

                string GettingString = "";
                int dr_count = 0;
                Boolean ContinueExecution = true;
                txb_Status.Text = "";

                if (dt_POList != null)
                {
                    //統計選取筆數
                    foreach (DataRow dr in dt_POList.Rows)
                    {
                        if (dr["Check1"].ToString() == "1")
                        {
                            dr_count++;
                        }
                    }
                    //詢問使用者是否繼續產生
                    if (dr_count > 30)
                    {
                        DialogResult = MessageBox.Show("總產出筆數:" + dr_count.ToString()
                                                     + "\n產出筆數超出30筆，是否繼續作業？",
                                                     "產生筆數過多",
                                                     MessageBoxButtons.OKCancel);
                        if (DialogResult == DialogResult.Cancel)
                            ContinueExecution = false;
                    }
                    //開始產生
                    if (ContinueExecution)
                    {
                        dr_count = 0;
                        foreach (DataRow dr in dt_POList.Rows)
                        {
                            if (dr["Check1"].ToString() == "1")
                            {
                                if (filepath == "")
                                {
                                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                                    fbd.ShowDialog();
                                    filepath = fbd.SelectedPath;
                                }
                                GettingString = "";
                                if (rdb_SelectPO.Checked)
                                {
                                    GettingString = PDF_PO_v2.CreatPdf_Prod(sca, dr["po_no"].ToString(), dr["site_no"].ToString(), label_Host.Text, label_IP.Text, filepath);
                                }
                                else if (rdb_SelectRJ.Checked)
                                {
                                    GettingString = PDF_RJ_v2.CreatPdf_Prod(sca, dr["po_no"].ToString(), dr["site_no"].ToString(), label_Host.Text, label_IP.Text, filepath);
                                }
                                txb_Status.Text += dr_count.ToString("00") + ": " + GettingString + "\n";
                                dr_count++;
                            }
                        }
                        if (dr_count == 0)
                        {
                            SetStatusString(2);
                        }
                    }
                }
            }
            #endregion

            btn_CrtPDF_END:
            btn_CrtPDF.Enabled = true;
        }
        //PO,RJ切換
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_SelectPO.Checked)
            {
                txb_POID.Text = "P" + DateTime.Today.AddDays(-2).ToString("yyyyMMdd").Substring(2, 4);
                rdb_SelectPO.ForeColor = Color.Red;
                rdb_SelectRJ.ForeColor = Color.Black;
                rdb_SelectLOG.ForeColor = Color.Black;
            }
            else if (rdb_SelectRJ.Checked)
            {
                txb_POID.Text = "57" + DateTime.Today.AddDays(-2).ToString("yyyyMMdd").Substring(2, 4);
                rdb_SelectPO.ForeColor = Color.Black;
                rdb_SelectRJ.ForeColor = Color.Red;
                rdb_SelectLOG.ForeColor = Color.Black;
            }
            else if (rdb_SelectLOG.Checked)
            {
                txb_POID.Text = "";
                rdb_SelectPO.ForeColor = Color.Black;
                rdb_SelectRJ.ForeColor = Color.Black;
                rdb_SelectLOG.ForeColor = Color.Red;
            }
            dt_POList.Clear();
            SetStatusString(0);
            ShowHideObjects();
        }

        //切換時要顯示的欄位
        private void ShowHideObjects()
        {
            lbl_DockMode.Visible = rdb_SelectPO.Checked;
            cmb_DockMode.Visible = rdb_SelectPO.Checked;

            if (rdb_SelectLOG.Checked)
                tabControl1.SelectedIndex = 1;
            else
                tabControl1.SelectedIndex = 0;
        }

        #endregion

        private void btn_ICantPrint_Click(object sender, EventArgs e)
        {

            Form2_Download frm = new Form2_Download();
            frm.ShowDialog();
        }
    }
}
