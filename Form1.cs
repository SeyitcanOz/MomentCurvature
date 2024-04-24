using System;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using MomentCurvature.User_Control;

namespace MomentCurvature
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            PrepareUI();

            SubscribeToEvents();
        }

        #region Properties
        #endregion

        #region Private Methods

        private void PrepareUI()
        {

            gridControl.DataSource = ucLongitudinalBar1.LongitudinalBarList;

            gridView1.Columns[0].Caption = "Depth";
            gridView1.Columns[1].Caption = "n";
            gridView1.Columns[2].Caption = "Φ";
            gridView1.Columns[3].Caption = "Area";
            gridView1.Columns[4].Caption = "fy";
            gridView1.Columns[5].Caption = "fu";
            gridView1.Columns[6].Caption = "εsy";
            gridView1.Columns[7].Caption = "εsu";
            gridView1.Columns[8].Caption = "E";


            gridView1.OptionsView.ShowGroupPanel = false;

            gridControl.MainView.ViewCaption = "Longitudinal Bars";
            foreach (GridColumn column in gridView1.Columns)
            {
                column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }

            

        }

        private void SubscribeToEvents()
        {
        }

        private void UnsubscribeToEvents()
        {
        }

        

        #endregion

        #region Events
        private void ChckUseStirrups_CheckedChanged(object sender, EventArgs e)
        {
            UnsubscribeToEvents();
            
            
            SubscribeToEvents();
        }


        #endregion

        
    }

}
