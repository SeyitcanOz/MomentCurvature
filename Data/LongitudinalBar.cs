using DevExpress.XtraRichEdit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomentCurvature.Data
{
    public class LongitudinalBar
    {
        #region CTOR

        public LongitudinalBar()
        {
           
        }

        public LongitudinalBar(double depth,double count,double diameter,double yieldStrength,double ultimateStrength,double ultimateStrain):this()
        {
            Depth= depth;
            Count= count;
            Diameter= diameter;

            YieldStrength = yieldStrength;
            UltimateStrength = ultimateStrength;
            UltimateStrain = ultimateStrain;
                
        }
        
        #endregion

        #region Private Fields

        private double _Depth;
        private double _Count;
        private double _Diameter;

        private double _YieldStrength;
        private double _UltimateStrength;
        private double _UltimateStrain;


        #endregion

        #region Properties

        public double Depth { get => _Depth; set => _Depth = value; }
        public double Count { get => _Count; set => _Count = value; }
        public double Diameter { get => _Diameter; set => _Diameter = value; }
        public double Area { get => _Count * (Math.PI * Math.Pow(_Diameter, 2) / 4); }
        public double YieldStrength { get => _YieldStrength; set => _YieldStrength = value; }
        public double UltimateStrength { get => _UltimateStrength; set => _UltimateStrength = value; }
        public double YieldStrain { get => _YieldStrength / 200000; }
        public double UltimateStrain { get => _UltimateStrain; set => _UltimateStrain = value; }
        public double ElasticModulus { get => 200000; }

        #endregion

    }
}
