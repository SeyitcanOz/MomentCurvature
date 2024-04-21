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
    public partial class ucConcrete : UserControl
    {
        #region CTOR
        public ucConcrete()
        {
            InitializeComponent();
            _Concrete = new Concrete();
            FillTextBoxes ();
            SubscribeToEvents ();
        }

        
        #endregion

        #region Private Fields
        private Concrete _Concrete;

        #endregion

        #region Properties
        public Concrete Concrete { get => _Concrete; set => _Concrete = value; }

        #endregion

        #region Private Methods
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
            txtClearCover.Text = _Concrete.ClearCover.ToString();
            txtWidth.Text = _Concrete.Width.ToString();
            txtHeight.Text = _Concrete.Height.ToString();
            txtCompressiveStrength.Text = _Concrete.CompressiveStrength.ToString();
        }


        #endregion

        #region Events
        private void BtnSave_Click(object sender, EventArgs e)
        {
            UnsubscribeToEvents ();

            _Concrete = new Concrete()
            {
                ClearCover = Convert.ToDouble(txtClearCover.Text),
                Width = Convert.ToDouble(txtWidth.Text),
                Height = Convert.ToDouble(txtHeight.Text),
                CompressiveStrength = Convert.ToDouble(txtCompressiveStrength.Text)
            };

            SubscribeToEvents ();
        }
        #endregion
    }
}
