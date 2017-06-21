namespace PDF_PO_Kota
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txb_POID = new System.Windows.Forms.TextBox();
            this.btn_CrtPDF = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label_Host = new System.Windows.Forms.Label();
            this.label_IP = new System.Windows.Forms.Label();
            this.txb_SupID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp_BDate = new System.Windows.Forms.DateTimePicker();
            this.dtp_EDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.txb_Status = new System.Windows.Forms.RichTextBox();
            this.rdb_SelectPO = new System.Windows.Forms.RadioButton();
            this.rdb_SelectRJ = new System.Windows.Forms.RadioButton();
            this.txb_SiteNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_DockMode = new System.Windows.Forms.ComboBox();
            this.lbl_DockMode = new System.Windows.Forms.Label();
            this.rdb_SelectLOG = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_ICantPrint = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "單號";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txb_POID
            // 
            this.txb_POID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_POID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txb_POID.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txb_POID.Location = new System.Drawing.Point(91, 115);
            this.txb_POID.MaxLength = 13;
            this.txb_POID.Name = "txb_POID";
            this.txb_POID.Size = new System.Drawing.Size(103, 20);
            this.txb_POID.TabIndex = 4;
            this.txb_POID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_POID_KeyDown);
            // 
            // btn_CrtPDF
            // 
            this.btn_CrtPDF.Location = new System.Drawing.Point(378, 168);
            this.btn_CrtPDF.Name = "btn_CrtPDF";
            this.btn_CrtPDF.Size = new System.Drawing.Size(75, 23);
            this.btn_CrtPDF.TabIndex = 6;
            this.btn_CrtPDF.Text = "產生PDF(&C)";
            this.btn_CrtPDF.UseVisualStyleBackColor = true;
            this.btn_CrtPDF.Click += new System.EventHandler(this.btn_CrtPDF_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Brown;
            this.label3.Location = new System.Drawing.Point(200, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "長度：0 (Max 13)";
            // 
            // label_Host
            // 
            this.label_Host.AutoSize = true;
            this.label_Host.ForeColor = System.Drawing.Color.Brown;
            this.label_Host.Location = new System.Drawing.Point(300, 441);
            this.label_Host.Name = "label_Host";
            this.label_Host.Size = new System.Drawing.Size(26, 12);
            this.label_Host.TabIndex = 13;
            this.label_Host.Text = "Host";
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.ForeColor = System.Drawing.Color.Brown;
            this.label_IP.Location = new System.Drawing.Point(403, 441);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(15, 12);
            this.label_IP.TabIndex = 14;
            this.label_IP.Text = "IP";
            // 
            // txb_SupID
            // 
            this.txb_SupID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_SupID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txb_SupID.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txb_SupID.Location = new System.Drawing.Point(91, 54);
            this.txb_SupID.MaxLength = 4;
            this.txb_SupID.Name = "txb_SupID";
            this.txb_SupID.Size = new System.Drawing.Size(50, 20);
            this.txb_SupID.TabIndex = 0;
            this.txb_SupID.TextChanged += new System.EventHandler(this.textBox_supID_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "供應商編號";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Brown;
            this.label5.Location = new System.Drawing.Point(147, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "長度：0 (Max 4)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "到貨日期";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtp_BDate
            // 
            this.dtp_BDate.CustomFormat = "yyyy/MM/dd";
            this.dtp_BDate.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtp_BDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_BDate.Location = new System.Drawing.Point(91, 82);
            this.dtp_BDate.Name = "dtp_BDate";
            this.dtp_BDate.Size = new System.Drawing.Size(103, 27);
            this.dtp_BDate.TabIndex = 2;
            this.dtp_BDate.Value = new System.DateTime(2013, 3, 26, 0, 0, 0, 0);
            // 
            // dtp_EDate
            // 
            this.dtp_EDate.CustomFormat = "yyyy/MM/dd";
            this.dtp_EDate.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtp_EDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_EDate.Location = new System.Drawing.Point(223, 82);
            this.dtp_EDate.Name = "dtp_EDate";
            this.dtp_EDate.Size = new System.Drawing.Size(103, 27);
            this.dtp_EDate.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(200, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "至";
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(378, 139);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 5;
            this.btn_Search.Text = "搜尋(&F)";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // txb_Status
            // 
            this.txb_Status.BackColor = System.Drawing.SystemColors.Window;
            this.txb_Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_Status.Location = new System.Drawing.Point(30, 368);
            this.txb_Status.Name = "txb_Status";
            this.txb_Status.Size = new System.Drawing.Size(423, 65);
            this.txb_Status.TabIndex = 12;
            this.txb_Status.Text = "";
            // 
            // rdb_SelectPO
            // 
            this.rdb_SelectPO.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdb_SelectPO.Checked = true;
            this.rdb_SelectPO.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdb_SelectPO.Location = new System.Drawing.Point(60, 11);
            this.rdb_SelectPO.Name = "rdb_SelectPO";
            this.rdb_SelectPO.Size = new System.Drawing.Size(100, 31);
            this.rdb_SelectPO.TabIndex = 13;
            this.rdb_SelectPO.TabStop = true;
            this.rdb_SelectPO.Text = "PO";
            this.rdb_SelectPO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdb_SelectPO.UseVisualStyleBackColor = true;
            this.rdb_SelectPO.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdb_SelectRJ
            // 
            this.rdb_SelectRJ.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdb_SelectRJ.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdb_SelectRJ.Location = new System.Drawing.Point(170, 12);
            this.rdb_SelectRJ.Name = "rdb_SelectRJ";
            this.rdb_SelectRJ.Size = new System.Drawing.Size(100, 30);
            this.rdb_SelectRJ.TabIndex = 14;
            this.rdb_SelectRJ.Text = "RJ";
            this.rdb_SelectRJ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdb_SelectRJ.UseVisualStyleBackColor = true;
            this.rdb_SelectRJ.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // txb_SiteNo
            // 
            this.txb_SiteNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_SiteNo.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txb_SiteNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txb_SiteNo.Location = new System.Drawing.Point(276, 54);
            this.txb_SiteNo.MaxLength = 3;
            this.txb_SiteNo.Name = "txb_SiteNo";
            this.txb_SiteNo.Size = new System.Drawing.Size(50, 20);
            this.txb_SiteNo.TabIndex = 1;
            this.txb_SiteNo.Text = "DC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "倉別";
            // 
            // cmb_DockMode
            // 
            this.cmb_DockMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DockMode.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmb_DockMode.FormattingEnabled = true;
            this.cmb_DockMode.Items.AddRange(new object[] {
            "不限",
            "越庫",
            "寄庫"});
            this.cmb_DockMode.Location = new System.Drawing.Point(391, 54);
            this.cmb_DockMode.Name = "cmb_DockMode";
            this.cmb_DockMode.Size = new System.Drawing.Size(62, 24);
            this.cmb_DockMode.TabIndex = 16;
            // 
            // lbl_DockMode
            // 
            this.lbl_DockMode.AutoSize = true;
            this.lbl_DockMode.Location = new System.Drawing.Point(332, 57);
            this.lbl_DockMode.Name = "lbl_DockMode";
            this.lbl_DockMode.Size = new System.Drawing.Size(53, 12);
            this.lbl_DockMode.TabIndex = 22;
            this.lbl_DockMode.Text = "碼頭類型";
            // 
            // rdb_SelectLOG
            // 
            this.rdb_SelectLOG.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdb_SelectLOG.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdb_SelectLOG.Location = new System.Drawing.Point(280, 12);
            this.rdb_SelectLOG.Name = "rdb_SelectLOG";
            this.rdb_SelectLOG.Size = new System.Drawing.Size(100, 30);
            this.rdb_SelectLOG.TabIndex = 15;
            this.rdb_SelectLOG.Text = "Log";
            this.rdb_SelectLOG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdb_SelectLOG.UseVisualStyleBackColor = true;
            this.rdb_SelectLOG.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(22, 197);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(435, 167);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gridControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(427, 158);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl2.Size = new System.Drawing.Size(427, 158);
            this.gridControl2.TabIndex = 26;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsPrint.UsePrintStyles = true;
            this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "選取";
            this.gridColumn6.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn6.FieldName = "Check1";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ValueChecked = 1;
            this.repositoryItemCheckEdit1.ValueUnchecked = 0;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "到貨日期";
            this.gridColumn7.FieldName = "Arrive_date";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "倉別";
            this.gridColumn8.FieldName = "Site_no";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 2;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "單號";
            this.gridColumn9.FieldName = "po_no";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 3;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "供應商編號";
            this.gridColumn10.FieldName = "vendor_no";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "碼頭類型";
            this.gridColumn11.FieldName = "Dock_Mode_Descr";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 5;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "明細筆數";
            this.gridColumn12.FieldName = "rows";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gridControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(427, 158);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(427, 158);
            this.gridControl1.TabIndex = 25;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.AppearancePrint.EvenRow.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.AppearancePrint.EvenRow.Options.UseFont = true;
            this.gridView1.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.AppearancePrint.FilterPanel.Options.UseFont = true;
            this.gridView1.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.AppearancePrint.FooterPanel.Options.UseFont = true;
            this.gridView1.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.AppearancePrint.GroupFooter.Options.UseFont = true;
            this.gridView1.AppearancePrint.GroupRow.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.AppearancePrint.GroupRow.Options.UseFont = true;
            this.gridView1.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gridView1.AppearancePrint.Lines.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.AppearancePrint.Lines.Options.UseFont = true;
            this.gridView1.AppearancePrint.OddRow.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.AppearancePrint.OddRow.Options.UseFont = true;
            this.gridView1.AppearancePrint.Preview.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.AppearancePrint.Preview.Options.UseFont = true;
            this.gridView1.AppearancePrint.Row.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.AppearancePrint.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsPrint.UsePrintStyles = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "單號";
            this.gridColumn1.FieldName = "Logcol_PONO";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "查詢時間";
            this.gridColumn2.FieldName = "Logcol_CrtDate";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "帳號";
            this.gridColumn3.FieldName = "Logcol_XSCUserID";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "IP";
            this.gridColumn4.FieldName = "Logcol_IP";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "使用者名稱";
            this.gridColumn5.FieldName = "Logcol_UserName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // btn_ICantPrint
            // 
            this.btn_ICantPrint.Location = new System.Drawing.Point(391, 11);
            this.btn_ICantPrint.Name = "btn_ICantPrint";
            this.btn_ICantPrint.Size = new System.Drawing.Size(75, 23);
            this.btn_ICantPrint.TabIndex = 25;
            this.btn_ICantPrint.Text = "無法列印點我";
            this.btn_ICantPrint.UseVisualStyleBackColor = true;
            this.btn_ICantPrint.Click += new System.EventHandler(this.btn_ICantPrint_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 456);
            this.Controls.Add(this.btn_ICantPrint);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.rdb_SelectLOG);
            this.Controls.Add(this.lbl_DockMode);
            this.Controls.Add(this.cmb_DockMode);
            this.Controls.Add(this.txb_SiteNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdb_SelectRJ);
            this.Controls.Add(this.rdb_SelectPO);
            this.Controls.Add(this.txb_Status);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtp_EDate);
            this.Controls.Add(this.dtp_BDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txb_SupID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_IP);
            this.Controls.Add(this.label_Host);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_CrtPDF);
            this.Controls.Add(this.txb_POID);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PO,RJ 產生PDF v1.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_POID;
        private System.Windows.Forms.Button btn_CrtPDF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_Host;
        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.TextBox txb_SupID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp_BDate;
        private System.Windows.Forms.DateTimePicker dtp_EDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.RichTextBox txb_Status;
        private System.Windows.Forms.RadioButton rdb_SelectPO;
        private System.Windows.Forms.RadioButton rdb_SelectRJ;
        private System.Windows.Forms.TextBox txb_SiteNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_DockMode;
        private System.Windows.Forms.Label lbl_DockMode;
        private System.Windows.Forms.RadioButton rdb_SelectLOG;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private System.Windows.Forms.Button btn_ICantPrint;
    }
}