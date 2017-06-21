namespace PDF_PO_Kota
{
    partial class XtraReport_RJ
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReport_RJ));
            DevExpress.XtraPrinting.BarCode.Code39Generator code39Generator1 = new DevExpress.XtraPrinting.BarCode.Code39Generator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarCode1 = new DevExpress.XtraReports.UI.XRBarCode();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.ediDataSet_PDF_PO_Kota1 = new PDF_PO_Kota.EDIDataSet_PDF_PO_Kota();
            this.v_T_POTableAdapter = new PDF_PO_Kota.EDIDataSet_PDF_PO_KotaTableAdapters.v_T_POTableAdapter();
            this.v_EDI_BACK_R02_TTableAdapter = new PDF_PO_Kota.EDIDataSet_PDF_PO_KotaTableAdapters.V_EDI_BACK_R02_TTableAdapter();
            this.ARRIVE_START_DATE = new DevExpress.XtraReports.UI.CalculatedField();
            ((System.ComponentModel.ISupportInitialize)(this.ediDataSet_PDF_PO_Kota1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2,
            this.xrLabel14,
            this.xrLabel15,
            this.xrLabel16,
            this.xrLabel18,
            this.xrLabel13,
            this.xrLabel12});
            this.Detail.HeightF = 66F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine2
            // 
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0.0001589457F, 60.00004F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(789.9998F, 3.750008F);
            // 
            // xrLabel14
            // 
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "V_EDI_BACK_R02_T.NAME", "{0}")});
            this.xrLabel14.Font = new System.Drawing.Font("新細明體", 9.75F);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(173.3334F, 0F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(178.75F, 60.00004F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UsePadding = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "xrLabel14";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "V_EDI_BACK_R02_T.QTY", "{0}")});
            this.xrLabel15.Font = new System.Drawing.Font("新細明體", 9.75F);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(352.0833F, 0F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(72.29166F, 20.00001F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UsePadding = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "xrLabel15";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel15.WordWrap = false;
            // 
            // xrLabel16
            // 
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "V_EDI_BACK_R02_T.EA_UNIT", "{0}")});
            this.xrLabel16.Font = new System.Drawing.Font("新細明體", 9.75F);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(552.0833F, 0F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(60.00171F, 20F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UsePadding = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "xrLabel16";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel16.WordWrap = false;
            // 
            // xrLabel18
            // 
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "V_EDI_BACK_R02_T.EA_BARCODE", "{0}")});
            this.xrLabel18.Font = new System.Drawing.Font("新細明體", 9.75F);
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(27.08334F, 20.00001F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(132.5F, 20F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UsePadding = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "xrLabel18";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel18.WordWrap = false;
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "V_EDI_BACK_R02_T.ITEM_NO", "{0}")});
            this.xrLabel13.Font = new System.Drawing.Font("新細明體", 9.75F);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(27.08334F, 0F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(132.5F, 20F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UsePadding = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "xrLabel13";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel13.WordWrap = false;
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "V_EDI_BACK_R02_T.ITEM_SEQ_NO")});
            this.xrLabel12.Font = new System.Drawing.Font("新細明體", 9.75F);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(2.083341F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(18.33324F, 22.99999F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "xrLabel12";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel12.WordWrap = false;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 30F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2});
            this.BottomMargin.HeightF = 30F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Top;
            this.xrPageInfo2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(689.9999F, 0F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.StylePriority.UseTextAlignment = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.xrLine1,
            this.xrLabel11,
            this.xrLabel9,
            this.xrLabel7,
            this.xrLabel5,
            this.xrPictureBox1,
            this.xrLabel32,
            this.xrLabel31,
            this.xrLabel2,
            this.xrPageInfo1,
            this.xrLabel1,
            this.xrBarCode1,
            this.xrLabel6,
            this.xrLabel4});
            this.PageHeader.HeightF = 171F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "V_EDI_BACK_R02_T.ARRIVE_START_TIME", "{0}")});
            this.xrLabel3.Font = new System.Drawing.Font("標楷體", 9.75F);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(397F, 103.75F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(157.9133F, 20.00002F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "xrLabel7";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel3.WordWrap = false;
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0.0001430511F, 161F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(789.9998F, 10F);
            // 
            // xrLabel11
            // 
            this.xrLabel11.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom;
            this.xrLabel11.CanGrow = false;
            this.xrLabel11.Font = new System.Drawing.Font("標楷體", 9.75F);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(0F, 138F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(789.9999F, 22.99998F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "   貨號/條碼             貨品名稱/規格             退貨量(pcs)           實退量      單位          " +
                "       備註";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel11.WordWrap = false;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Font = new System.Drawing.Font("標楷體", 9.75F);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(611.2499F, 82.99996F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(178.75F, 23F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "客服電話：(886)0800335888";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel9.WordWrap = false;
            // 
            // xrLabel7
            // 
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "V_EDI_BACK_R02_T.ARRIVE_START_DATE", "預計退貨日起迄：{0}")});
            this.xrLabel7.Font = new System.Drawing.Font("標楷體", 9.75F);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(289F, 83.75F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(255.83F, 20F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "xrLabel7";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel7.WordWrap = false;
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "V_EDI_BACK_R02_T.RJ_NO", "    單號：{0}")});
            this.xrLabel5.Font = new System.Drawing.Font("標楷體", 9.75F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(611.2501F, 59.99997F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(178.7499F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "xrLabel5";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel5.WordWrap = false;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(14.58333F, 31.25F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(54.5F, 27.41664F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // xrLabel32
            // 
            this.xrLabel32.Font = new System.Drawing.Font("新細明體", 12F);
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(77.08334F, 31.25F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(203.1284F, 23F);
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            this.xrLabel32.Text = "全聯實業股份有限公司";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel31
            // 
            this.xrLabel31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "V_EDI_BACK_R02_T.RJ_NO", "*{0}*")});
            this.xrLabel31.Font = new System.Drawing.Font("標楷體", 9.75F);
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(517.2917F, 45.41664F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(272.7083F, 14.58333F);
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.StylePriority.UseTextAlignment = false;
            this.xrLabel31.Text = "xrLabel31";
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel31.WordWrap = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "V_EDI_BACK_R02_T.ARRIVE_DATE", "    通知日期：{0}")});
            this.xrLabel2.Font = new System.Drawing.Font("標楷體", 9.75F);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(302.0833F, 63.75001F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(208.5413F, 20F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel2.WordWrap = false;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("標楷體", 9.75F);
            this.xrPageInfo1.Format = "列印時間：{0:yyyy/MM/dd HH:mm:ss}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(2.083333F, 83.75002F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(282.92F, 20F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrPageInfo1.WordWrap = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "V_EDI_BACK_R02_T.VENDOR_NO", "    廠商：{0}")});
            this.xrLabel1.Font = new System.Drawing.Font("標楷體", 9.75F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(2.083341F, 63.75001F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(282.92F, 20F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel1.WordWrap = false;
            // 
            // xrBarCode1
            // 
            this.xrBarCode1.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrBarCode1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "V_EDI_BACK_R02_T.RJ_NO", "{0}")});
            this.xrBarCode1.LocationFloat = new DevExpress.Utils.PointFloat(517.2916F, 0F);
            this.xrBarCode1.Module = 1F;
            this.xrBarCode1.Name = "xrBarCode1";
            this.xrBarCode1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrBarCode1.ShowText = false;
            this.xrBarCode1.SizeF = new System.Drawing.SizeF(272.7083F, 45.41664F);
            this.xrBarCode1.StylePriority.UseFont = false;
            this.xrBarCode1.StylePriority.UsePadding = false;
            this.xrBarCode1.StylePriority.UseTextAlignment = false;
            code39Generator1.CalcCheckSum = false;
            code39Generator1.WideNarrowRatio = 3F;
            this.xrBarCode1.Symbology = code39Generator1;
            this.xrBarCode1.Text = "xrBarCode1";
            this.xrBarCode1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "V_EDI_BACK_R02_T.SITE_NO_DESCR", "{0}[越庫中心]")});
            this.xrLabel6.Font = new System.Drawing.Font("標楷體", 9.75F);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(310.417F, 43.75F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(191.6663F, 20F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "xrLabel6";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel6.WordWrap = false;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("標楷體", 14.25F);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(339.5833F, 18.75F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(117.71F, 25F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UsePadding = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "退貨通知單";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel27,
            this.xrLabel28});
            this.ReportFooter.HeightF = 161F;
            this.ReportFooter.KeepTogether = true;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel27
            // 
            this.xrLabel27.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Top;
            this.xrLabel27.CanGrow = false;
            this.xrLabel27.Font = new System.Drawing.Font("標楷體", 9.75F);
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(0F, 31F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(789.9999F, 22.99999F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "   車號：                         司機：                              司機手機：";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel27.WordWrap = false;
            // 
            // xrLabel28
            // 
            this.xrLabel28.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Top;
            this.xrLabel28.CanGrow = false;
            this.xrLabel28.Font = new System.Drawing.Font("標楷體", 9.75F);
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(0F, 66F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(789.9999F, 22.99998F);
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            this.xrLabel28.Text = "   物流簽收：";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel28.WordWrap = false;
            // 
            // ediDataSet_PDF_PO_Kota1
            // 
            this.ediDataSet_PDF_PO_Kota1.DataSetName = "EDIDataSet_PDF_PO_Kota";
            this.ediDataSet_PDF_PO_Kota1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // v_T_POTableAdapter
            // 
            this.v_T_POTableAdapter.ClearBeforeFill = true;
            // 
            // v_EDI_BACK_R02_TTableAdapter
            // 
            this.v_EDI_BACK_R02_TTableAdapter.ClearBeforeFill = true;
            // 
            // ARRIVE_START_DATE
            // 
            this.ARRIVE_START_DATE.DataMember = "V_EDI_BACK_R02_T";
            this.ARRIVE_START_DATE.DataSource = this.ediDataSet_PDF_PO_Kota1;
            this.ARRIVE_START_DATE.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.ARRIVE_START_DATE.Name = "ARRIVE_START_DATE";
            // 
            // XtraReport_RJ
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.ReportFooter});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.ARRIVE_START_DATE});
            this.DataAdapter = this.v_EDI_BACK_R02_TTableAdapter;
            this.DataMember = "V_EDI_BACK_R02_T";
            this.DataSource = this.ediDataSet_PDF_PO_Kota1;
            this.Margins = new System.Drawing.Printing.Margins(30, 30, 30, 30);
            this.Version = "11.1";
            ((System.ComponentModel.ISupportInitialize)(this.ediDataSet_PDF_PO_Kota1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel32;
        private DevExpress.XtraReports.UI.XRLabel xrLabel31;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCode1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel27;
        private DevExpress.XtraReports.UI.XRLabel xrLabel28;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private EDIDataSet_PDF_PO_Kota ediDataSet_PDF_PO_Kota1;
        private PDF_PO_Kota.EDIDataSet_PDF_PO_KotaTableAdapters.v_T_POTableAdapter v_T_POTableAdapter;
        private PDF_PO_Kota.EDIDataSet_PDF_PO_KotaTableAdapters.V_EDI_BACK_R02_TTableAdapter v_EDI_BACK_R02_TTableAdapter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.CalculatedField ARRIVE_START_DATE;
    }
}
