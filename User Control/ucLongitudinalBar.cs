using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;
using MomentCurvature.Data;

namespace MomentCurvature.User_Control
{
    public partial class ucLongitudinalBar : UserControl
    {
        #region CTOR
        public ucLongitudinalBar()
        {
            InitializeComponent();
            PrepareUI();
            SubscribeToEvents();
        }
        #endregion

        #region Private Fields

        private BindingList<LongitudinalBar> _LongitudinalBarList = new BindingList<LongitudinalBar>();

        #endregion

        #region Properties

        public BindingList<LongitudinalBar> LongitudinalBarList { get => _LongitudinalBarList; }

        #endregion


        #region Private Methods
        private void PrepareUI()
        {
            FillTextBoxes();
        }

        private void SubscribeToEvents()
        {
            btnSave.Click += BtnSave_Click;
        }

        private void UnsubscribeToEvents()
        {
            btnSave.Click -= BtnSave_Click;
        }

        private void FillTextBoxes()
        {
            txtCountTop.Text = "2";
            txtDiameterTop.Text = "20";
            txtYieldStrengthTop.Text = "420";
            txtUltimateStrengthTop.Text = "530";
            txtUltimateStrainTop.Text = "0,08";

            txtCountBot.Text = "2";
            txtDiameterBot.Text = "20";
            txtYieldStrengthBot.Text = "420";
            txtUltimateStrengthBot.Text = "530";
            txtUltimateStrainBot.Text = "0,08";
        }

        private void AddLongitudinalBar()
        {
            //var concrete = Parent.Controls.Find("ucConcrete1", true).FirstOrDefault() as ucConcrete;
            var concrete = (Parent.Parent.Controls.Find("ucConcrete1", true).FirstOrDefault() as ucConcrete).Concrete;
            var stirrup = (Parent.Parent.Controls.Find("ucStirrup1", true).FirstOrDefault() as ucStirrup).Stirrup;


            // Top Bar
            var count = Convert.ToDouble(txtCountTop.Text);
            var diameter = Convert.ToDouble(txtDiameterTop.Text);
            var yieldStrength = Convert.ToDouble(txtYieldStrengthTop.Text);
            var ultimateStrength = Convert.ToDouble(txtUltimateStrengthTop.Text);
            var ultimateStrain = Convert.ToDouble(txtUltimateStrainTop.Text);
            var depth = concrete.ClearCover + stirrup.Diameter + diameter / 2;

            var longSteelTop = new LongitudinalBar(depth, count, diameter, yieldStrength, ultimateStrength, ultimateStrain);
            LongitudinalBarList.Add(longSteelTop);

            // Bottom Bar
            count = Convert.ToDouble(txtCountBot.Text);
            diameter = Convert.ToDouble(txtDiameterBot.Text);
            yieldStrength = Convert.ToDouble(txtYieldStrengthBot.Text);
            ultimateStrength = Convert.ToDouble(txtUltimateStrengthBot.Text);
            ultimateStrain = Convert.ToDouble(txtUltimateStrainBot.Text);
            depth = concrete.Height - concrete.ClearCover - stirrup.Diameter - diameter / 2;

            var longSteelBot = new LongitudinalBar(depth, count, diameter, yieldStrength, ultimateStrength, ultimateStrain);
            LongitudinalBarList.Add(longSteelBot);


        }


        #endregion

        #region Events
        private void BtnSave_Click(object sender, EventArgs e)
        {
            UnsubscribeToEvents();

            LongitudinalBarList.Clear();

            if (string.IsNullOrEmpty(txtCountTop.Text) ||
                string.IsNullOrEmpty(txtDiameterTop.Text) || string.IsNullOrEmpty(txtYieldStrengthTop.Text) ||
                string.IsNullOrEmpty(txtUltimateStrengthTop.Text) || string.IsNullOrEmpty(txtUltimateStrainTop.Text))
            {

                MessageBox.Show("Please fill in all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SubscribeToEvents();
                return;
            }


            AddLongitudinalBar();

            SubscribeToEvents();
        }

        #endregion


    }


}
