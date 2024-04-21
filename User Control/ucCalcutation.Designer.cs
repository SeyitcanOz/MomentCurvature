namespace MomentCurvature.User_Control
{
    partial class ucCalcutation
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtAxialLoad = new DevExpress.XtraEditors.TextEdit();
            this.txtBalanceError = new DevExpress.XtraEditors.TextEdit();
            this.txtNumberOfLayers = new DevExpress.XtraEditors.TextEdit();
            this.txtStrainIncrement = new DevExpress.XtraEditors.TextEdit();
            this.btnDrawMC = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAxialLoad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalanceError.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberOfLayers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrainIncrement.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtAxialLoad);
            this.layoutControl1.Controls.Add(this.txtBalanceError);
            this.layoutControl1.Controls.Add(this.txtNumberOfLayers);
            this.layoutControl1.Controls.Add(this.txtStrainIncrement);
            this.layoutControl1.Controls.Add(this.btnDrawMC);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(725, 98, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(388, 140);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtAxialLoad
            // 
            this.txtAxialLoad.Location = new System.Drawing.Point(123, 45);
            this.txtAxialLoad.Name = "txtAxialLoad";
            this.txtAxialLoad.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtAxialLoad.Properties.MaskSettings.Set("mask", "f");
            this.txtAxialLoad.Size = new System.Drawing.Size(50, 20);
            this.txtAxialLoad.StyleController = this.layoutControl1;
            this.txtAxialLoad.TabIndex = 4;
            // 
            // txtBalanceError
            // 
            this.txtBalanceError.Location = new System.Drawing.Point(123, 69);
            this.txtBalanceError.Name = "txtBalanceError";
            this.txtBalanceError.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtBalanceError.Properties.MaskSettings.Set("mask", "f");
            this.txtBalanceError.Size = new System.Drawing.Size(50, 20);
            this.txtBalanceError.StyleController = this.layoutControl1;
            this.txtBalanceError.TabIndex = 5;
            // 
            // txtNumberOfLayers
            // 
            this.txtNumberOfLayers.Location = new System.Drawing.Point(300, 45);
            this.txtNumberOfLayers.Name = "txtNumberOfLayers";
            this.txtNumberOfLayers.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtNumberOfLayers.Properties.MaskSettings.Set("mask", "d");
            this.txtNumberOfLayers.Size = new System.Drawing.Size(64, 20);
            this.txtNumberOfLayers.StyleController = this.layoutControl1;
            this.txtNumberOfLayers.TabIndex = 6;
            // 
            // txtStrainIncrement
            // 
            this.txtStrainIncrement.Location = new System.Drawing.Point(300, 69);
            this.txtStrainIncrement.Name = "txtStrainIncrement";
            this.txtStrainIncrement.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtStrainIncrement.Properties.MaskSettings.Set("mask", "0.0000");
            this.txtStrainIncrement.Size = new System.Drawing.Size(64, 20);
            this.txtStrainIncrement.StyleController = this.layoutControl1;
            this.txtStrainIncrement.TabIndex = 7;
            // 
            // btnDrawMC
            // 
            this.btnDrawMC.Location = new System.Drawing.Point(12, 105);
            this.btnDrawMC.Name = "btnDrawMC";
            this.btnDrawMC.Size = new System.Drawing.Size(364, 22);
            this.btnDrawMC.StyleController = this.layoutControl1;
            this.btnDrawMC.TabIndex = 8;
            this.btnDrawMC.Text = "Draw Moment - Curvature Diagram";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1,
            this.layoutControlItem5,
            this.layoutControlGroup2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(388, 140);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(177, 93);
            this.layoutControlGroup1.Text = "Loading Properties";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtBalanceError;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(153, 24);
            this.layoutControlItem2.Text = "Balance Error (kN)";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtAxialLoad;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(153, 24);
            this.layoutControlItem1.Text = "Axial Load (kN)";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnDrawMC;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 93);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(368, 27);
            this.layoutControlItem5.Text = "Draw M&C";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(177, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(191, 93);
            this.layoutControlGroup2.Text = "Numeric Properties";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtNumberOfLayers;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(167, 24);
            this.layoutControlItem3.Text = "Number of Layers";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtStrainIncrement;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(167, 24);
            this.layoutControlItem4.Text = "Strain Increment";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(87, 13);
            // 
            // ucCalcutation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ucCalcutation";
            this.Size = new System.Drawing.Size(388, 140);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAxialLoad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalanceError.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberOfLayers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrainIncrement.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txtAxialLoad;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit txtBalanceError;
        private DevExpress.XtraEditors.TextEdit txtNumberOfLayers;
        private DevExpress.XtraEditors.TextEdit txtStrainIncrement;
        private DevExpress.XtraEditors.SimpleButton btnDrawMC;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}
