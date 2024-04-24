namespace MomentCurvature
{
    partial class frmMain
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
            MomentCurvature.Data.Concrete concrete3 = new MomentCurvature.Data.Concrete();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlMainProperties = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.ucConcrete1 = new MomentCurvature.User_Control.ucConcrete();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.ucStirrup1 = new MomentCurvature.User_Control.ucStirrup();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ucLongitudinalBar1 = new MomentCurvature.User_Control.ucLongitudinalBar();
            this.pnlChart = new DevExpress.XtraEditors.PanelControl();
            this.chartControl = new DevExpress.XtraCharts.ChartControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.pnlCalculationProperties = new DevExpress.XtraEditors.PanelControl();
            this.ucCalcutation1 = new MomentCurvature.User_Control.ucCalcutation();
            this.pnlMemoEdit = new DevExpress.XtraEditors.PanelControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMainProperties)).BeginInit();
            this.pnlMainProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlChart)).BeginInit();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCalculationProperties)).BeginInit();
            this.pnlCalculationProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMemoEdit)).BeginInit();
            this.pnlMemoEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMainProperties
            // 
            this.pnlMainProperties.Controls.Add(this.xtraTabControl1);
            this.pnlMainProperties.Location = new System.Drawing.Point(12, 12);
            this.pnlMainProperties.Name = "pnlMainProperties";
            this.pnlMainProperties.Size = new System.Drawing.Size(488, 752);
            this.pnlMainProperties.TabIndex = 0;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(5, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(481, 765);
            this.xtraTabControl1.TabIndex = 2;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage3,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.ucConcrete1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(479, 727);
            this.xtraTabPage1.Text = "Concrete Properties";
            // 
            // ucConcrete1
            // 
            concrete3.ClearCover = 0D;
            concrete3.CompressiveStrength = 0D;
            concrete3.Height = 0D;
            concrete3.Width = 0D;
            this.ucConcrete1.Concrete = concrete3;
            this.ucConcrete1.Location = new System.Drawing.Point(0, 0);
            this.ucConcrete1.Name = "ucConcrete1";
            this.ucConcrete1.Size = new System.Drawing.Size(479, 233);
            this.ucConcrete1.TabIndex = 0;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.ucStirrup1);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(479, 740);
            this.xtraTabPage3.Text = "Stirrup Properties";
            // 
            // ucStirrup1
            // 
            this.ucStirrup1.Location = new System.Drawing.Point(0, 0);
            this.ucStirrup1.Name = "ucStirrup1";
            this.ucStirrup1.Size = new System.Drawing.Size(479, 383);
            this.ucStirrup1.Stirrup = null;
            this.ucStirrup1.TabIndex = 0;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gridControl);
            this.xtraTabPage2.Controls.Add(this.ucLongitudinalBar1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(479, 740);
            this.xtraTabPage2.Text = "Longitudinal Steel Properties";
            // 
            // gridControl
            // 
            this.gridControl.Location = new System.Drawing.Point(0, 622);
            this.gridControl.MainView = this.gridView1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(476, 106);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ActiveFilterEnabled = false;
            this.gridView1.Appearance.FixedLine.Options.UseTextOptions = true;
            this.gridView1.Appearance.FixedLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.GridControl = this.gridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowGroupExpandAnimation = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowColumnResizing = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowMergedGrouping = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsDragDrop.AllowDataReordering = false;
            this.gridView1.OptionsDragDrop.AllowSortedDataDragDrop = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsFilter.AllowMRUFilterList = false;
            this.gridView1.OptionsFind.AllowFindPanel = false;
            this.gridView1.OptionsFind.AllowMruItems = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsPrint.AllowCancelPrintExport = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            // 
            // ucLongitudinalBar1
            // 
            this.ucLongitudinalBar1.Location = new System.Drawing.Point(0, 0);
            this.ucLongitudinalBar1.Name = "ucLongitudinalBar1";
            this.ucLongitudinalBar1.Size = new System.Drawing.Size(476, 616);
            this.ucLongitudinalBar1.TabIndex = 0;
            // 
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.chartControl);
            this.pnlChart.Location = new System.Drawing.Point(506, 168);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(852, 596);
            this.pnlChart.TabIndex = 3;
            // 
            // chartControl
            // 
            this.chartControl.BorderOptions.Thickness = 2;
            this.chartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl.Legend.LegendID = -1;
            this.chartControl.Location = new System.Drawing.Point(2, 2);
            this.chartControl.Name = "chartControl";
            this.chartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControl.Size = new System.Drawing.Size(848, 592);
            this.chartControl.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(12, 36);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(133, 22);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "simpleButton1";
            // 
            // pnlCalculationProperties
            // 
            this.pnlCalculationProperties.Controls.Add(this.ucCalcutation1);
            this.pnlCalculationProperties.Location = new System.Drawing.Point(934, 16);
            this.pnlCalculationProperties.Name = "pnlCalculationProperties";
            this.pnlCalculationProperties.Size = new System.Drawing.Size(422, 148);
            this.pnlCalculationProperties.TabIndex = 5;
            // 
            // ucCalcutation1
            // 
            this.ucCalcutation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCalcutation1.Location = new System.Drawing.Point(2, 2);
            this.ucCalcutation1.Name = "ucCalcutation1";
            this.ucCalcutation1.Size = new System.Drawing.Size(418, 144);
            this.ucCalcutation1.TabIndex = 0;
            // 
            // pnlMemoEdit
            // 
            this.pnlMemoEdit.Controls.Add(this.memoEdit1);
            this.pnlMemoEdit.Location = new System.Drawing.Point(508, 16);
            this.pnlMemoEdit.Name = "pnlMemoEdit";
            this.pnlMemoEdit.Size = new System.Drawing.Size(422, 148);
            this.pnlMemoEdit.TabIndex = 6;
            // 
            // memoEdit1
            // 
            this.memoEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit1.EditValue = resources.GetString("memoEdit1.EditValue");
            this.memoEdit1.Location = new System.Drawing.Point(2, 2);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.ReadOnly = true;
            this.memoEdit1.Size = new System.Drawing.Size(418, 144);
            this.memoEdit1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 772);
            this.Controls.Add(this.pnlMemoEdit);
            this.Controls.Add(this.pnlCalculationProperties);
            this.Controls.Add(this.pnlChart);
            this.Controls.Add(this.pnlMainProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.Text = "Moment Curvature - Created by Seyitcan Oz";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMainProperties)).EndInit();
            this.pnlMainProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlChart)).EndInit();
            this.pnlChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCalculationProperties)).EndInit();
            this.pnlCalculationProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMemoEdit)).EndInit();
            this.pnlMemoEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlMainProperties;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private User_Control.ucConcrete ucConcrete1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private User_Control.ucLongitudinalBar ucLongitudinalBar1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private User_Control.ucStirrup ucStirrup1;
        private DevExpress.XtraEditors.PanelControl pnlChart;
        private DevExpress.XtraCharts.ChartControl chartControl;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PanelControl pnlCalculationProperties;
        private DevExpress.XtraEditors.PanelControl pnlMemoEdit;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private User_Control.ucCalcutation ucCalcutation1;
    }
}

