using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomentCurvature.Data
{
    public class Concrete
    {
        #region CTOR
        public Concrete()
        {
            ClearCover = 40;
            Width = 500;
            Height = 500;
            CompressiveStrength = 30;
        }
        #endregion

        #region Private Fields

        private double _ClearCover;
        private double _Width;
        private double _Height;
        private double _CompressiveStrength;

        private double _ESec;
        private double _R;

        #endregion

        #region Properties

        public double ClearCover { get => _ClearCover; set => _ClearCover = value; }
        public double Width { get => _Width; set => _Width = value; }
        public double Height { get => _Height; set => _Height = value; }
        public double CompressiveStrength { get => _CompressiveStrength; set => _CompressiveStrength = value; }
        public double Ec { get => 5000 * Math.Sqrt(CompressiveStrength); }
        
        public double ESec { get => _ESec; set => _ESec = value; } // TODO unnecesary
        public double R { get => _R; set => _R = value; }


        #endregion


    }
}
