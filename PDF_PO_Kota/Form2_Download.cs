using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDF_PO_Kota
{
    public partial class Form2_Download : Form
    {
        public Form2_Download()
        {
            InitializeComponent();
        }

        private void Form2_Download_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "按下按鈕會自動執行：\n"
            + "1.\n"
            + "切換到 C:\\pxmart\\uclient\\ \n"
            + "執行   ClientSetup.exe 192.168.122.41 AUTO DevXtraReports\n"
            + "此動作是要下載XtraReports.zip到C:\\Program Files\n"
            + "2.\n"
            + "解壓縮到 C:\\Program Files\\DevExpress 2011.1\\Components\\Sources\\DevExpress.DLL\n"
            + "3.\n"
            + "以最高權限執行 C:\\Program Files\\DevExpress 2011.1\\Components\\Sources\\DevExpress.DLL\\InstallXtraReports.bat\n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //調用ClientSetup.exe下載組件,並解壓縮到XSC_CLIENTSETUP指定目錄
            System.Diagnostics.Process objDownload = new System.Diagnostics.Process();
            objDownload.StartInfo.WorkingDirectory = "C:\\pxmart\\uclient";
            objDownload.StartInfo.FileName = "ClientAdmin.exe";
            objDownload.StartInfo.Arguments = " \"ClientSetup.exe 192.168.122.41 AUTO DevXtraReports\"";
            objDownload.Start();
            objDownload.WaitForExit();

            Application.DoEvents();

            //執行SetupBat,進行組件安裝
            System.Diagnostics.Process objSetup = new System.Diagnostics.Process();
            objSetup.StartInfo.WorkingDirectory = "C:\\pxmart\\uclient";
            objSetup.StartInfo.FileName = "ClientAdmin.exe";
            objSetup.StartInfo.Arguments = "\"" + @"C:\Program Files\DevExpress 2011.1\Components\Sources\DevExpress.DLL\InstallXtraReports.bat" + "\"";
            objSetup.Start();
            objSetup.WaitForExit();

            MessageBox.Show("完成，請重開測試");
            Application.Exit();
        }
    }
}
