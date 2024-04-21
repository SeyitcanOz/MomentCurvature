using DevExpress.XtraCharts;
using MomentCurvature.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MomentCurvature.User_Control
{
    public partial class ucCalcutation : UserControl
    {
        #region CTOR
        public ucCalcutation()
        {
            InitializeComponent();

            SubscribeToEvents();
        }
        #endregion

        #region Private Fields
        private Concrete _Concrete;
        private Stirrup _Stirrup;
        private BindingList<LongitudinalBar> _LongitudinalBarList;
        // deneme123

        private List<double> _ConfinedAreaList = new List<double>();
        private List<double> _UnconfinedAreaList = new List<double>();
        private List<double> _MidLayerList = new List<double>();

        private List<double> _CurvatureList = new List<double>();
        private List<double> _MomentList = new List<double>();
        #endregion

        #region Properties

        #endregion

        #region Private Methods
        private void SubscribeToEvents()
        {
            btnDrawMC.Click += BtnDrawMC_Click;
        }



        private void UnsubscribeToEvents()
        {
            btnDrawMC.Click -= BtnDrawMC_Click;
        }


        // Algorithms
        private void GetConcreteStirrupAndBars(out Concrete concrete, out Stirrup stirrup, out BindingList<LongitudinalBar> longitudinalBarList)
        {
            concrete = (Parent.Parent.Controls.Find("ucConcrete1", true).FirstOrDefault() as ucConcrete)?.Concrete;
            stirrup = (Parent.Parent.Controls.Find("ucStirrup1", true).FirstOrDefault() as ucStirrup)?.Stirrup;
            longitudinalBarList = (Parent.Parent.Controls.Find("ucLongitudinalBar1", true).FirstOrDefault() as ucLongitudinalBar)?.LongitudinalBarList;
        }

        private double CalculateGama(bool Isconfined)
        {
            double gama = 0;

            GetConcreteStirrupAndBars(out _Concrete, out _Stirrup, out _LongitudinalBarList);

            if (Isconfined == false || _Stirrup.UseStirrup == false)
            {
                gama = 1.0;
            }

            else
            {
                var aixTop = _Concrete.Width - 2 * _Concrete.ClearCover - _Stirrup.NumberOfLegY * _Stirrup.Diameter - _LongitudinalBarList[0].Diameter;
                var aixBot = _Concrete.Width - 2 * _Concrete.ClearCover - _Stirrup.NumberOfLegY * _Stirrup.Diameter - _LongitudinalBarList[1].Diameter;
                var aiy = _Concrete.Height - 2 * _Concrete.ClearCover - _Stirrup.NumberOfLegX * _Stirrup.Diameter - 0.5 * (_LongitudinalBarList[0].Diameter + _LongitudinalBarList[1].Diameter);

                var b0 = _Concrete.Width - 2 * _Concrete.ClearCover - _Stirrup.Diameter;
                var h0 = _Concrete.Height - 2 * _Concrete.ClearCover - _Stirrup.Diameter;

                var Asx = _Stirrup.Asx;
                var Asy = _Stirrup.Asy;

                var rhoX = Asx / (b0 * h0);
                var rhoY = Asy / (b0 * h0);

                var rhoS = rhoX + rhoY;

                var As = _LongitudinalBarList[0].Area + _LongitudinalBarList[1].Area;

                var sumAiPow = Math.Pow(aixTop, 2) + Math.Pow(aixBot, 2) + 2 * Math.Pow(aiy, 2);

                var alpha = (1 - sumAiPow / (6 * b0 * h0)) * (1 - _Stirrup.Spacing / (2 * b0)) * (1 - _Stirrup.Spacing / (2 * h0));

                var ke = alpha * Math.Pow(1 - As / (b0 * h0), -1);

                var fex = ke * rhoX * _Stirrup.YieldingStrength;
                var fey = ke * rhoY * _Stirrup.YieldingStrength;

                var fe = (fex + fey) / 2;

                gama = 2.254 * Math.Sqrt(1 + 7.94 * (fe / _Concrete.CompressiveStrength)) - 2 * (fe / _Concrete.CompressiveStrength) - 1.254;


            }

            return gama;
        }

        private double CalculateEpsilonCC(bool isConfined)
        {
            var epsilonCO = 0.002;

            var epsilonCC = epsilonCO * (1 + 5 * (CalculateGama(isConfined) - 1));

            return epsilonCC;
        }

        private double CalculateUltimateStrain(bool isConfined)
        {
            GetConcreteStirrupAndBars(out _Concrete, out _Stirrup, out _LongitudinalBarList);


            double ultimateStrain = 0;

            if (isConfined)
            {
                var aixTop = _Concrete.Width - 2 * _Concrete.ClearCover - _Stirrup.NumberOfLegY * _Stirrup.Diameter - _LongitudinalBarList[0].Diameter;
                var aixBot = _Concrete.Width - 2 * _Concrete.ClearCover - _Stirrup.NumberOfLegY * _Stirrup.Diameter - _LongitudinalBarList[1].Diameter;
                var aiy = _Concrete.Height - 2 * _Concrete.ClearCover - _Stirrup.NumberOfLegX * _Stirrup.Diameter - 0.5 * (_LongitudinalBarList[0].Diameter + _LongitudinalBarList[1].Diameter);

                var b0 = _Concrete.Width - 2 * _Concrete.ClearCover - _Stirrup.Diameter;
                var h0 = _Concrete.Height - 2 * _Concrete.ClearCover - _Stirrup.Diameter;

                var Asx = _Stirrup.Asx;
                var Asy = _Stirrup.Asy;

                var rhoX = Asx / (b0 * h0);
                var rhoY = Asy / (b0 * h0);

                var As = _LongitudinalBarList[0].Area + _LongitudinalBarList[1].Area;

                var sumAiPow = Math.Pow(aixTop, 2) + Math.Pow(aixBot, 2) + 2 * Math.Pow(aiy, 2);

                var alpha = (1 - sumAiPow / (6 * b0 * h0)) * (1 - _Stirrup.Spacing / (2 * b0)) * (1 - _Stirrup.Spacing / (2 * h0));

                var ke = alpha * Math.Pow(1 - As / (b0 * h0), -1);

                var fex = ke * rhoX * _Stirrup.YieldingStrength;
                var fey = ke * rhoY * _Stirrup.YieldingStrength;

                var fe = (fex + fey) / 2;



                ultimateStrain = 0.0035 + 0.04 * Math.Sqrt(alpha * Math.Min(rhoX, rhoY) * _Stirrup.YieldingStrength / fe);

            }
            else
            {
                ultimateStrain = 0.0035;
            }

            return ultimateStrain;
        }

        private double CalculateFCC(bool isConfined)
        {
            GetConcreteStirrupAndBars(out _Concrete, out _Stirrup, out _LongitudinalBarList);

            var fcc = CalculateGama(isConfined) * _Concrete.CompressiveStrength;

            return fcc;
        }

        private double CalculateR(bool isConfined)
        {
            GetConcreteStirrupAndBars(out _Concrete, out _Stirrup, out _LongitudinalBarList);

            var Esec = CalculateFCC(isConfined) / CalculateEpsilonCC(isConfined);

            var r = _Concrete.Ec / (_Concrete.Ec - Esec);

            return r;
        }

        private double CalculateFC(double epsilonC, bool isConfined)
        {
            var x = epsilonC / CalculateEpsilonCC(isConfined);

            var r = CalculateR(isConfined);

            var fc = CalculateFCC(isConfined) * x * r / (r - 1 + (Math.Pow(x, r)));

            return fc;


        }

        private void CalculateAreas()
        {

            GetConcreteStirrupAndBars(out _Concrete, out _Stirrup, out _LongitudinalBarList);

            var b0 = _Concrete.Width - 2 * _Concrete.ClearCover - _Stirrup.Diameter;

            var numOfLayers = Convert.ToInt32(txtNumberOfLayers.Text);

            var layerHeight = _Concrete.Height / numOfLayers;

            var layerDepth = 0.0;

            var unconfinedWidthZone1Zone3 = _Concrete.Width;
            var unconfinedWidthZone2 = 2 * _Concrete.ClearCover + _Stirrup.Diameter;

            var confinedStartDepth = _Concrete.ClearCover + _Stirrup.Diameter / 2;
            var confinedEndDepth = _Concrete.Height - _Concrete.ClearCover - _Stirrup.Diameter / 2;

            var confinedArea = 0.0;
            var unconfinedArea = 0.0;

            for (int i = 0; i < numOfLayers - 1; i++)
            {
                layerDepth += layerHeight;


                if (layerDepth < confinedStartDepth)
                {
                    confinedArea = 0;
                    unconfinedArea = unconfinedWidthZone1Zone3 * layerHeight;

                    _ConfinedAreaList.Add(confinedArea);
                    _UnconfinedAreaList.Add(unconfinedArea);
                }


                else if (layerDepth >= confinedStartDepth && layerDepth <= confinedEndDepth)
                {
                    confinedArea = b0 * layerHeight;
                    unconfinedArea = unconfinedWidthZone2 * layerHeight;

                    _ConfinedAreaList.Add(confinedArea);
                    _UnconfinedAreaList.Add(unconfinedArea);
                }

                else
                {
                    confinedArea = 0;
                    unconfinedArea = unconfinedWidthZone1Zone3 * layerHeight;

                    _ConfinedAreaList.Add(confinedArea);
                    _UnconfinedAreaList.Add(unconfinedArea);
                }

            }
        }

        private List<double> CalculateMidLayers()
        {

            GetConcreteStirrupAndBars(out _Concrete, out _Stirrup, out _LongitudinalBarList);

            var numOfLayers = Convert.ToInt32(txtNumberOfLayers.Text);

            // Calculate height of each layer
            var layerHeight = _Concrete.Height / numOfLayers;

            // Calculate area for each layer
            var layerDepth = 0.0;

            for (int i = 0; i < numOfLayers - 1; i++)
            {
                layerDepth += layerHeight;
                _MidLayerList.Add(layerDepth);
            }

            return _MidLayerList;
        }

        private void FillAreasAndMidLayers()
        {
            CalculateAreas();
            CalculateMidLayers();
        }

        private List<double> CalculateForcesForLayer(double neutralAxis, double strain)
        {
            GetConcreteStirrupAndBars(out _Concrete, out _Stirrup, out _LongitudinalBarList);

            var forceList = new List<double>();

            for (int i = 0; i < _MidLayerList.Count; i++)
            {
                //var epsilonC = strain * (neutralAxis + _Concrete.ClearCover + _Stirrup.Diameter / 2 - _MidLayerList[j]) / neutralAxis;
                var epsilonC = strain * (neutralAxis - _MidLayerList[i]) / (neutralAxis - _Concrete.ClearCover - _Stirrup.Diameter);

                if (epsilonC >= 0)
                {

                    // Confined Concrete Force
                    var confinedForce = 0.0;

                    if (_MidLayerList[i] < neutralAxis)
                    {
                        confinedForce = _ConfinedAreaList[i] * CalculateFC(epsilonC, true);

                    }
                    else
                    {
                        confinedForce = 0.0;
                    }

                    // Unconfined Concrete Force
                    var unconfinedForce = 0.0;
                    if (_MidLayerList[i] < neutralAxis && epsilonC <= 0.0035)
                    {
                        unconfinedForce = _UnconfinedAreaList[i] * CalculateFC(epsilonC, false);

                    }
                    else
                    {
                        unconfinedForce = 0;

                    }


                    forceList.Add(confinedForce / 1000 + unconfinedForce / 1000); // Convert to kN

                }
                else
                {
                    forceList.Add(0);
                }

            }
            return forceList;
        }

        private List<double> CalculateSteelForces(double neutralAxis, double strain)
        {
            GetConcreteStirrupAndBars(out _Concrete, out _Stirrup, out _LongitudinalBarList);

            var forceList = new List<double>();


            // Steel Strains
            var epsilonSteelTop = Math.Abs(strain * (neutralAxis - _LongitudinalBarList[0].Depth) / (neutralAxis - _Concrete.ClearCover - _Stirrup.Diameter));
            var epsilonSteelBot = Math.Abs(strain * (_LongitudinalBarList[1].Depth - neutralAxis) / (neutralAxis - _Concrete.ClearCover - _Stirrup.Diameter));


            // Calculate Top Steel Force
            var topSteelForce = 0.0;
            var bottomSteelForce = 0.0;

            if (epsilonSteelTop <= _LongitudinalBarList[0].YieldStrain)
            {
                if (_LongitudinalBarList[0].Depth > neutralAxis)
                {
                    topSteelForce = -epsilonSteelTop * 200000 * _LongitudinalBarList[0].Area;

                }
                else if (_LongitudinalBarList[0].Depth < neutralAxis)
                {

                    topSteelForce = epsilonSteelTop * 200000 * _LongitudinalBarList[0].Area;
                }
                else
                {
                    topSteelForce = 0;
                }
            }

            else if (epsilonSteelTop > _LongitudinalBarList[0].YieldStrain && epsilonSteelTop < _LongitudinalBarList[0].UltimateStrain)
            {
                if (_LongitudinalBarList[0].Depth > neutralAxis)
                {
                    topSteelForce = -_LongitudinalBarList[0].YieldStrength * _LongitudinalBarList[0].Area;
                }
                else if (_LongitudinalBarList[0].Depth < neutralAxis)
                {
                    topSteelForce = _LongitudinalBarList[0].YieldStrength * _LongitudinalBarList[0].Area;
                }
                else
                {
                    topSteelForce = 0;
                }
            }

            else
            {
                topSteelForce = 0;
            }

            // Calculate Bottom Steel Force
            if (epsilonSteelBot <= _LongitudinalBarList[1].YieldStrain)
            {
                if (_LongitudinalBarList[1].Depth > neutralAxis)
                {
                    bottomSteelForce = -epsilonSteelBot * 200000 * _LongitudinalBarList[1].Area;

                }
                else if (_LongitudinalBarList[1].Depth < neutralAxis)
                {

                    bottomSteelForce = epsilonSteelBot * 200000 * _LongitudinalBarList[1].Area;
                }
                else
                {
                    bottomSteelForce = 0;
                }
            }

            else if (epsilonSteelBot > _LongitudinalBarList[1].YieldStrain && epsilonSteelBot < _LongitudinalBarList[1].UltimateStrain)
            {
                if (_LongitudinalBarList[1].Depth > neutralAxis)
                {
                    bottomSteelForce = -_LongitudinalBarList[1].YieldStrength * _LongitudinalBarList[1].Area;
                }
                else if (_LongitudinalBarList[1].Depth < neutralAxis)
                {
                    bottomSteelForce = _LongitudinalBarList[1].YieldStrength * _LongitudinalBarList[1].Area;
                }
                else
                {
                    bottomSteelForce = 0;
                }
            }

            else
            {
                bottomSteelForce = 0;
            }

            forceList.Add(topSteelForce / 1000); // Convert to kN
            forceList.Add(bottomSteelForce / 1000); // Convert to kN

            return forceList;
        }

        private double LocateNeutralAxis(double balanceError, double strain, double axialLoad)
        {
            GetConcreteStirrupAndBars(out _Concrete, out _Stirrup, out _LongitudinalBarList);

            double lowerBound = 0; // Initial lower bound for neutral axis
            double upperBound = _Concrete.Height; // Initial upper bound for neutral axis

            double neutralAxis = _Concrete.Height / 2; // Initial guess for neutral axis

            while (true)
            {
                var concreteForces = CalculateForcesForLayer(neutralAxis, strain).Sum();
                var steelForces = CalculateSteelForces(neutralAxis, strain).Sum();
                var totalForces = concreteForces + steelForces - axialLoad;

                // Check if the total forces are within the balance error
                if (Math.Abs(totalForces) < balanceError)
                {
                    break; // Neutral axis found
                }

                // Adjust the bounds based on the sign of the total forces
                if (totalForces > balanceError)
                {
                    upperBound = neutralAxis; // Adjust upper bound
                }
                else
                {
                    lowerBound = neutralAxis; // Adjust lower bound
                }

                // Update the neutral axis using bisection method
                neutralAxis = (lowerBound + upperBound) / 2;
            }

            return neutralAxis;


        }


        private void InitializeChartData(List<double> momentList, List<double> curvatureList)
        {
            var chart = Parent.Parent.Controls.Find("chartControl", true).FirstOrDefault() as ChartControl;

            // Add data to your _MomenList and _CurvatureList


            // Create a series and bind data to it
            Series series = new Series("Data Series", ViewType.ScatterLine);
            for (int i = 0; i < momentList.Count; i++)
            {
                series.Points.Add(new SeriesPoint(curvatureList[i], momentList[i]));
            }

            // Add the series to the chart
            chart.Series.Add(series);

            // Set chart title and axis labels if needed
            chart.Titles.Add(new ChartTitle { Text = "Moment - Curvature" });
            ((XYDiagram)chart.Diagram).AxisX.Title.Text = "Moment (kN.m)";
            ((XYDiagram)chart.Diagram).AxisY.Title.Text = "Curvature (rad/km)";
        }

        private void CalculateMomentCurvature()
        {
            GetConcreteStirrupAndBars(out _Concrete, out _Stirrup, out _LongitudinalBarList);

            FillAreasAndMidLayers();

            var ultimateStrain = CalculateUltimateStrain(_Stirrup.UseStirrup);

            //_CurvatureList.Add(0);
            //_MomentList.Add(0);

            var strainList = new List<double>();
            var neutralAxisList = new List<double>();



            var balanceError = Convert.ToDouble(txtBalanceError.Text);
            var strainIncrement = Convert.ToDouble(txtStrainIncrement.Text);
            var axialLoad = Convert.ToDouble(txtAxialLoad.Text);

            for (double currentStrain = 0; currentStrain <= ultimateStrain; currentStrain += strainIncrement)
            {
                strainList.Add(currentStrain);
            }

            for (double strain = 0; strain <= ultimateStrain; strain += strainIncrement)
            {
                var neutralAxis = LocateNeutralAxis(balanceError, strain, axialLoad);
                neutralAxisList.Add(neutralAxis);
            }

            for (int i = 0; i < strainList.Count; i++)
            {
                if (strainList[i] == 0)
                {
                    _CurvatureList.Add(0.0);
                    _MomentList.Add(0.0);
                }
                else
                {
                    _CurvatureList.Add((strainList[i] / neutralAxisList[i]) * Math.Pow(10, 6)); // Convert to rad / km

                    //var moment = 0.0;
                    //for (int j = 0; j < _MidLayerList.Count; j++)
                    //{
                    //    moment += (CalculateForcesForLayer(neutralAxisList[i], strainList[i])[j] * (_Concrete.Height / 2 - _MidLayerList[j])) / 1000; // Convert to kN.m

                    //}

                    //var forceSteelTop = CalculateSteelForces(neutralAxisList[i], strainList[i])[0];
                    //var forceSteelBot = CalculateSteelForces(neutralAxisList[i], strainList[i])[1];

                    //var momentSteelTop = forceSteelTop * (_Concrete.Height / 2 - _LongitudinalBarList[0].Depth) / 1000; // Convert to kN.m
                    //var momentSteelBot = forceSteelBot * (_LongitudinalBarList[1].Depth - _Concrete.Height / 2) / 1000; // Convert to kN.m

                    //_MomentList.Add(moment + momentSteelTop - momentSteelBot);


                }

            }
            var something = 0.0;

        }

        #endregion

        #region Events
        private void BtnDrawMC_Click(object sender, EventArgs e)
        {
            CalculateMomentCurvature();
            InitializeChartData(_MomentList, _CurvatureList);
        }


        #endregion


    }
}
