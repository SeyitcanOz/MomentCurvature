using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomentCurvature.Data
{
    public class Stirrup
    {
        #region CTOR
        public Stirrup()
        {
            _UseStirrup = false;

            Spacing = 0;
            Diameter = 0;
            NumberOfLegX = 0;
            NumberOfLegY = 0;
            
            YieldingStrength = 0;
            UltimateStrength = 0;
            UltimateStrain = 0;

        }
        #endregion

        #region Private Fields
        private bool _UseStirrup;

        private double _Spacing;
        private double _Diameter;
        private int _NumberOfLegX;
        private int _NumberOfLegY;

        private double _YieldingStrength;
        private double _UltimateStrength;
        private double _UltimateStrain;

        #endregion

        #region Properties
        public bool UseStirrup { get => _UseStirrup; set => _UseStirrup = value; }

        public double Spacing { get => _Spacing; set => _Spacing = value; }
        public double Diameter { get => _Diameter; set => _Diameter = value; }
        public int NumberOfLegX { get => _NumberOfLegX; set => _NumberOfLegX = value; }
        public int NumberOfLegY { get => _NumberOfLegY; set => _NumberOfLegY = value; }


        public double YieldingStrength { get => _YieldingStrength; set => _YieldingStrength = value; }
        public double UltimateStrength { get => _UltimateStrength; set => _UltimateStrength = value; }
        public double UltimateStrain { get => _UltimateStrain; set => _UltimateStrain = value; }

        public double Asx { get => (Math.PI * Math.Pow(Diameter, 2) / 4 * NumberOfLegX); }
        public double Asy { get => (Math.PI * Math.Pow(Diameter, 2) / 4 * NumberOfLegY); }



        #endregion
    }
}
