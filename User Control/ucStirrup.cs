using MomentCurvature.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MomentCurvature.User_Control
{
    public partial class ucStirrup : UserControl
    {
        #region CTOR
        public ucStirrup()
        {
            InitializeComponent();
            PrepareUI ();
            SubscribeToEvents(); 
        }
        #endregion

        #region Private Fields
        private Stirrup _Stirrup;
        #endregion

        #region Properties
        public Stirrup Stirrup { get => _Stirrup; set => _Stirrup = value; }
        #endregion

        #region Private Methods

        private void SubscribeToEvents()
        {
            btnSave.Click += BtnSave_Click;
            chckUseStirrup.CheckedChanged += ChckUseStirrup_CheckedChanged;
        }

        

        private void UnSubscribeToEvents()
        {
            btnSave.Click -= BtnSave_Click;
            chckUseStirrup.CheckedChanged -= ChckUseStirrup_CheckedChanged;
        }

        
        private void PrepareUI()
        {
            UnSubscribeToEvents ();
            CheckBoxChanged ();
            SubscribeToEvents();
        }

        private void CheckBoxChanged()
        {

            if (chckUseStirrup.Checked == false)
            {
                txtSpacing.Enabled = false;
                txtDiameter.Enabled = false;
                txtNumLegX.Enabled = false;
                txtNumLegY.Enabled = false;
                txtYieldingStrength.Enabled = false;
                txtUltimateStrength.Enabled = false;
                txtUltimateStrain.Enabled = false;

                txtDiameter.Text = "0";
                txtNumLegX.Text = "0";
                txtNumLegY.Text = "0";
                txtSpacing.Text = "0";
                txtUltimateStrength.Text = "0";
                txtUltimateStrain.Text = "0";
                txtYieldingStrength.Text = "0";

            }
            else
            {
                txtSpacing.Enabled = true;
                txtDiameter.Enabled = true;
                txtNumLegX.Enabled = false;
                txtNumLegY.Enabled = false;
                txtYieldingStrength.Enabled = true;
                txtUltimateStrength.Enabled = true;
                txtUltimateStrain.Enabled = true;

                txtNumLegX.Text = "2";
                txtNumLegY.Text = "2";
            }

        }

        #endregion

        #region Events
        private void BtnSave_Click(object sender, EventArgs e)
        {
            UnSubscribeToEvents();
            if (chckUseStirrup.Checked==true)
            {
                _Stirrup= new Stirrup();
                _Stirrup.UseStirrup = true;
                _Stirrup.Spacing = Convert.ToDouble(txtSpacing.Text);
                _Stirrup.Diameter = Convert.ToDouble(txtDiameter.Text);
                _Stirrup.NumberOfLegX = Convert.ToInt32(txtNumLegX.Text);
                _Stirrup.NumberOfLegY = Convert.ToInt32(txtNumLegX.Text);
                _Stirrup.YieldingStrength = Convert.ToDouble(txtYieldingStrength.Text);
                _Stirrup.UltimateStrength = Convert.ToDouble(txtUltimateStrength.Text);
                _Stirrup.UltimateStrain = Convert.ToDouble(txtUltimateStrain.Text);

            }
            else
            {
                _Stirrup = new Stirrup();
                _Stirrup.UseStirrup = false;
                _Stirrup.Spacing = 0;
                _Stirrup.Diameter = 0;
                _Stirrup.NumberOfLegX = 0;
                _Stirrup.NumberOfLegY = 0;
                _Stirrup.YieldingStrength = 0;
                _Stirrup.UltimateStrength = 0;
                _Stirrup.UltimateStrain = 0;

            }


            SubscribeToEvents();
        }
        private void ChckUseStirrup_CheckedChanged(object sender, EventArgs e)
        {
            UnSubscribeToEvents();
            CheckBoxChanged();
            SubscribeToEvents();
        }
        #endregion

    }
}
