using DevExpress.Drawing;
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



        private List<double> _MidLayerList = new List<double>();
        private List<double> _ConfinedAreaList = new List<double>();
        private List<double> _UnconfinedAreaList = new List<double>();

        private List<double> _NeutralAxisList = new List<double>();
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

        private void GetConcreteStirrupAndBars(out Concrete concrete, out Stirrup stirrup, out BindingList<LongitudinalBar> longitudinalBarList)
        {
            concrete = (Parent.Parent.Controls.Find("ucConcrete1", true).FirstOrDefault() as ucConcrete)?.Concrete;
            stirrup = (Parent.Parent.Controls.Find("ucStirrup1", true).FirstOrDefault() as ucStirrup)?.Stirrup;
            longitudinalBarList = (Parent.Parent.Controls.Find("ucLongitudinalBar1", true).FirstOrDefault() as ucLongitudinalBar)?.LongitudinalBarList;
        }

        // Algorithms

        // Area and Mid Layer Calculations
        private void CalculateAreas()
        {
            var numOfLayers = Convert.ToInt32(txtNumberOfLayers.Text);

            var b0 = _Concrete.Width - 2 * _Concrete.ClearCover -  _Stirrup.Diameter;


            var layerHeight = _Concrete.Height / numOfLayers;

            var layerDepth = layerHeight / 2;

            var unconfinedWidthZone1Zone3 = _Concrete.Width;
            var unconfinedWidthZone2 = 2 * _Concrete.ClearCover + _Stirrup.Diameter;

            var confinedStartDepth = _Concrete.ClearCover + _Stirrup.Diameter / 2;
            var confinedEndDepth = _Concrete.Height - _Concrete.ClearCover - _Stirrup.Diameter / 2;

            var confinedArea = 0.0;
            var unconfinedArea = 0.0;

            if (_Stirrup.UseStirrup)
            {
                for (int i = 0; i < numOfLayers; i++)
                {

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

                    layerDepth += layerHeight;
                }
            }

            else
            {

                for (int i = 0; i < numOfLayers; i++)
                {

                    unconfinedArea = _Concrete.Width * layerHeight;

                    _ConfinedAreaList.Add(0);
                    _UnconfinedAreaList.Add(unconfinedArea);

                    layerDepth += layerHeight;
                }

            }

        }

        private List<double> CalculateMidLayers()
        {

            var numOfLayers = Convert.ToInt32(txtNumberOfLayers.Text);

            var layerHeight = _Concrete.Height / numOfLayers;

            var layerDepth = layerHeight / 2;

            for (int i = 0; i < numOfLayers; i++)
            {
                _MidLayerList.Add(layerDepth);

                layerDepth += layerHeight;
            }

            return _MidLayerList;
        }

        private void FillAreasAndMidLayers()
        {
            CalculateAreas();
            CalculateMidLayers();
        }

        #region Stress Strain Calculations

        private double CalculateFC(double epsilonC, bool isConfined)
        {

            if (isConfined)
            {
                // Calculate Lambda

                var longBarTop = _LongitudinalBarList[0];
                var longBarBot = _LongitudinalBarList[1];

                var aixTop = (_Concrete.Width - 2 * _Concrete.ClearCover - _Stirrup.NumberOfLegY * _Stirrup.Diameter - longBarTop.Count * longBarTop.Diameter) / (longBarTop.Count - 1);
                var aixBot = (_Concrete.Width - 2 * _Concrete.ClearCover - _Stirrup.NumberOfLegY * _Stirrup.Diameter - longBarBot.Count * longBarBot.Diameter) / (longBarBot.Count - 1);
                var aiy = _Concrete.Height - 2 * _Concrete.ClearCover - _Stirrup.NumberOfLegX * _Stirrup.Diameter - (longBarTop.Diameter + longBarBot.Diameter);

                var b0 = _Concrete.Width - 2 * _Concrete.ClearCover - _Stirrup.Diameter;
                var h0 = _Concrete.Height - 2 * _Concrete.ClearCover - _Stirrup.Diameter;

                var Asx = _Stirrup.Asx;
                var Asy = _Stirrup.Asy;

                var rhoX = Asx / (_Stirrup.Spacing * h0);
                var rhoY = Asy / (_Stirrup.Spacing * b0);

                var rhoS = rhoX + rhoY;

                var As = _LongitudinalBarList[0].Area + _LongitudinalBarList[1].Area;

                var sumAiPow = Math.Pow(aixTop, 2) * (longBarTop.Count - 1) + Math.Pow(aixBot, 2) * (longBarBot.Count - 1) + 2 * Math.Pow(aiy, 2);

                var alpha = (1 - sumAiPow / (6 * b0 * h0)) * (1 - _Stirrup.Spacing / (2 * b0)) * (1 - _Stirrup.Spacing / (2 * h0));

                var ke = alpha * Math.Pow(1 - As / (b0 * h0), -1);

                var fex = ke * rhoX * _Stirrup.YieldingStrength;
                var fey = ke * rhoY * _Stirrup.YieldingStrength;

                var fe = (fex + fey) / 2;

                var lambda = 2.254 * Math.Sqrt(1 + 7.94 * (fe / _Concrete.CompressiveStrength)) - 2 * (fe / _Concrete.CompressiveStrength) - 1.254;

                // Calculate Fcc

                var fcc = lambda * _Concrete.CompressiveStrength;

                // Calculate EpsilonCC

                var epsilonCC = 0.002 * (1 + 5 * (lambda - 1));

                // Calculate Esec

                var Esec = fcc / epsilonCC;

                // Calculate R

                var r = _Concrete.Ec / (_Concrete.Ec - Esec);

                // Calculate x 

                var x = epsilonC / epsilonCC;

                // Calculate Fc

                var fc = fcc * x * r / (r - 1 + Math.Pow(x, r));

                return fc;

            }

            else
            {
                // Calculate Fcc
                var fcc = _Concrete.CompressiveStrength;

                // Calculate Esec
                var Esec = fcc / 0.002;

                // Calculate R
                var r = _Concrete.Ec / (_Concrete.Ec - Esec);

                // Calculate x
                var x = epsilonC / 0.002;

                // Calculate Fc
                var fc = fcc * x * r / (r - 1 + Math.Pow(x, r));

                return fc;

            }

        }

        private double CalculateUltimateStrain()
        {

            double ultimateStrain = 0;

            if (_Stirrup.UseStirrup)
            {
                var longBarTop = _LongitudinalBarList[0];
                var longBarBot = _LongitudinalBarList[1];

                var aixTop = (_Concrete.Width - 2 * _Concrete.ClearCover - _Stirrup.NumberOfLegY * _Stirrup.Diameter - longBarTop.Count * longBarTop.Diameter) / (longBarTop.Count - 1);
                var aixBot = (_Concrete.Width - 2 * _Concrete.ClearCover - _Stirrup.NumberOfLegY * _Stirrup.Diameter - longBarBot.Count * longBarBot.Diameter) / (longBarBot.Count - 1);
                var aiy = _Concrete.Height - 2 * _Concrete.ClearCover - _Stirrup.NumberOfLegX * _Stirrup.Diameter - (longBarTop.Diameter + longBarBot.Diameter);

                var b0 = _Concrete.Width - 2 * _Concrete.ClearCover - _Stirrup.Diameter;
                var h0 = _Concrete.Height - 2 * _Concrete.ClearCover - _Stirrup.Diameter;

                var Asx = _Stirrup.Asx;
                var Asy = _Stirrup.Asy;

                var rhoX = Asx / (_Stirrup.Spacing * h0);
                var rhoY = Asy / (_Stirrup.Spacing * b0);

                var As = _LongitudinalBarList[0].Area + _LongitudinalBarList[1].Area;

                var sumAiPow = Math.Pow(aixTop, 2) * (longBarTop.Count - 1) + Math.Pow(aixBot, 2) * (longBarBot.Count - 1) + 2 * Math.Pow(aiy, 2);

                var alpha = (1 - sumAiPow / (6 * b0 * h0)) * (1 - _Stirrup.Spacing / (2 * b0)) * (1 - _Stirrup.Spacing / (2 * h0));


                ultimateStrain = 0.0035 + 0.04 * Math.Sqrt(alpha * Math.Min(rhoX, rhoY) * _Stirrup.YieldingStrength / _Concrete.CompressiveStrength);

                if (ultimateStrain > 0.018)
                {
                    ultimateStrain = 0.018;
                }
            }

            else
            {
                ultimateStrain = 0.0035;
            }

            return ultimateStrain;
        }

        #endregion

        #region Force Calculations

        private List<double> CalculateForcesForLayer(double neutralAxis, double strain)
        {

            var forceList = new List<double>();

            var ultimateConfinedConcreteStrain = CalculateUltimateStrain();
            var stirrupFactor = _Stirrup.UseStirrup ? (_Concrete.ClearCover + _Stirrup.Diameter) : 0;

            foreach (var layerDepth in _MidLayerList)
            {
                var depthDifference = neutralAxis - layerDepth;

                var epsilonC = strain * (depthDifference) / (neutralAxis /*- stirrupFactor*/);

                var confinedForce = 0.0;
                var unconfinedForce = 0.0;


                if (_Stirrup.UseStirrup && epsilonC <= ultimateConfinedConcreteStrain) // Confined Zone
                {
                    confinedForce = epsilonC <= 0 ? 0 : _ConfinedAreaList[_MidLayerList.IndexOf(layerDepth)] * CalculateFC(epsilonC, true);
                }

                if (epsilonC <= 0.0035) // Unconfined Zone
                {
                    unconfinedForce = epsilonC <= 0 ? 0 : _UnconfinedAreaList[_MidLayerList.IndexOf(layerDepth)] * CalculateFC(epsilonC, false);
                }

                forceList.Add((confinedForce + unconfinedForce) / 1000); // Convert to kN
            }

            return forceList;
        }

        private List<double> CalculateSteelForces(double neutralAxis, double strain)
        {

            var forceList = new List<double>();

            foreach (var bar in _LongitudinalBarList)
            {
                var depthDifference = neutralAxis - bar.Depth;
                var stirrupFactor = _Stirrup.UseStirrup ? (_Concrete.ClearCover + _Stirrup.Diameter) : 0;

                var epsilonSteel = Math.Abs(strain * depthDifference / (neutralAxis));

                var steelForce = 0.0;

                if (epsilonSteel <= bar.YieldStrain)
                {
                    if (depthDifference > 0)
                    {
                        steelForce = epsilonSteel * bar.ElasticModulus * bar.Area;
                    }
                    else if (depthDifference < 0)
                    {
                        steelForce = - epsilonSteel * bar.ElasticModulus * bar.Area;
                    }
                    else
                    {
                        steelForce = 0;
                    }
                }

                else if (epsilonSteel > bar.YieldStrain && epsilonSteel <= bar.HardeningStrain)
                {
                    if (depthDifference > 0)
                    {
                        steelForce = bar.YieldStrength * bar.Area;
                    }
                    else if (depthDifference < 0)
                    {
                        steelForce = - bar.YieldStrength * bar.Area;
                    }
                    else
                    {
                        steelForce = 0;
                    }
                }

                else if (epsilonSteel > bar.HardeningStrain && epsilonSteel <= bar.UltimateStrain)
                {
                    if (depthDifference > 0)
                    {
                        var steelStress = bar.UltimateStrength - (bar.UltimateStrength - bar.YieldStrength) * Math.Pow(bar.UltimateStrain - epsilonSteel, 2)
                                                                                                     / Math.Pow(bar.UltimateStrain - bar.HardeningStrain, 2);
                        steelForce = steelStress * bar.Area;
                    }
                    else if (depthDifference < 0)
                    {
                        var steelStress = bar.UltimateStrength - (bar.UltimateStrength - bar.YieldStrength) * Math.Pow(bar.UltimateStrain - epsilonSteel, 2)
                                                                                                     / Math.Pow(bar.UltimateStrain - bar.HardeningStrain, 2);
                        steelForce = - steelStress * bar.Area;
                    }
                    else
                    {
                        steelForce = 0;
                    }
                }


                forceList.Add(steelForce / 1000); // Convert to kN
            }

            return forceList;
        }

        #endregion

        #region Neutral Axis Calculation

        //public void LocateNeutralAxis(double numOfLayers, double strain, double axialLoad)
        //{
        //    double neutralAxis = _Concrete.Height / 2;

        //    if (strain == 0)
        //    {
        //        _NeutralAxisList.Add(neutralAxis);
        //    }
        //    else
        //    {
        //        double totalForce = 1;
        //        double neutralAxisIncriment = Height / numOfLayers;

        //        while (totalForce > 0)
        //        {
        //            var concreteForces = CalculateForcesForLayer(neutralAxis, strain).Sum();
        //            var steelForces = CalculateSteelForces(neutralAxis, strain).Sum();
        //            totalForce = concreteForces + steelForces - axialLoad;

        //            neutralAxis -= neutralAxisIncriment;

        //            if (neutralAxis <= Height) { break; }

        //        }

        //        _NeutralAxisList.Add(neutralAxis);
        //    }
        //}

        //Neutral Axis Calculation
        private void LocateNeutralAxis(double balanceError, double strain, double axialLoad)
        {
            var numberOfLayers = Convert.ToInt32(txtNumberOfLayers.Text);
            double lowerBound = 0;
            double upperBound = _Concrete.Height;

            // Better initial guess can be obtained based on known factors
            double neutralAxis = _Concrete.Height / 2;

            // Maximum number of iterations to avoid infinite loops
            int maxIterations = 2500;
            int iterationCount = 0;

            while (iterationCount < maxIterations)
            {
                iterationCount++;

                var concreteForces = CalculateForcesForLayer(neutralAxis, strain).Sum();
                var steelForces = CalculateSteelForces(neutralAxis, strain).Sum();
                var totalForces = concreteForces + steelForces - axialLoad;

                // Check if the total forces are within the balance error
                if (Math.Abs(totalForces) < 0.01)
                {
                    _NeutralAxisList.Add(neutralAxis);
                    break;
                }

                if (totalForces > balanceError)
                {
                    upperBound = neutralAxis;
                }
                else
                {
                    lowerBound = neutralAxis;
                }

                // Update the neutral axis using bisection method
                neutralAxis = (lowerBound + upperBound) / 2;

                if (iterationCount == maxIterations)
                {
                    _NeutralAxisList.Add(neutralAxis);
                    break;
                }

            }


        }

        #endregion
        private void CalculateMomentCurvature()
        {
            GetConcreteStirrupAndBars(out _Concrete, out _Stirrup, out _LongitudinalBarList);

            FillAreasAndMidLayers();

            var numOfLayers = Convert.ToDouble(txtNumberOfLayers.Text);
            var axialLoad = Convert.ToDouble(txtAxialLoad.Text);
            var numberOfPoints = Convert.ToInt32(txtNumberOfPoints.Text);

            
            var ultimateStrain = _Stirrup.UseStirrup ? 0.018 : 0.0035; // PBDY 5A.1 Epsilon Collapse Boundary Condition
            var strainIncrement = ultimateStrain / (numberOfPoints - 1);

            var strainList = new List<double>();

            var firstStrain = 0.0;

            for (int i = 0; i < numberOfPoints; i++)
            {
                double currentStrain = firstStrain + i * strainIncrement;
                strainList.Add(currentStrain);
            }

            // Add the ultimate strain if it's not included due to rounding errors
            if (!strainList.Contains(ultimateStrain))
            {
                strainList.Add(ultimateStrain);
            }

            for (int i = 0; i < strainList.Count; i++)
            {
                LocateNeutralAxis(numOfLayers, strainList[i], axialLoad);

                if (strainList[i] == 0.0)
                {
                    _CurvatureList.Add(0.0);
                    _MomentList.Add(0.0);
                }
                else
                {
                    var stirrupFactor = _Stirrup.UseStirrup ? (_Concrete.ClearCover + _Stirrup.Diameter) : 0;
                    var moment = 0.0;

                    // Calculate moment contribution from concrete
                    for (int j = 0; j < _MidLayerList.Count; j++)
                    {
                        // Calculate force acting on the layer from concrete
                        var concreteForces = CalculateForcesForLayer(_NeutralAxisList[i], strainList[i])[j];

                        // Determine depth of layer relative to the neutral axis
                        var depthFromCentroid = Math.Abs(_Concrete.Height / 2 - _MidLayerList[j]);

                        // Calculate moment contribution from this layer and add it to total moment
                        moment += concreteForces * depthFromCentroid / 1000; // Convert to kN.m
                    }

                    // Calculate moment contribution from steel
                    var steelForces = CalculateSteelForces(_NeutralAxisList[i], strainList[i]);
                    var forceSteelTop = steelForces[0];
                    var forceSteelBot = steelForces[1];

                    var depthSteelTop = Math.Abs(_Concrete.Height / 2 - _LongitudinalBarList[0].Depth);
                    var depthSteelBot = Math.Abs(_Concrete.Height / 2 - _LongitudinalBarList[1].Depth);

                    var momentSteelTop = forceSteelTop * depthSteelTop / 1000; // Convert to kN.m
                    var momentSteelBot = forceSteelBot * depthSteelBot / 1000; // Convert to kN.m

                    moment += momentSteelTop - momentSteelBot;

                    _MomentList.Add(moment);

                    // Calculate Curvature
                    var curvature = strainList[i] / (_NeutralAxisList[i]) * Math.Pow(10, 6); // Convert to rad / m
                    _CurvatureList.Add(curvature);
                }
            }

        }

        private void InitializeChartData(List<double> momentList, List<double> curvatureList)
        {
            var chart = Parent.Parent.Controls.Find("chartControl", true).FirstOrDefault() as ChartControl;

            chart.Series.Clear();
            chart.Titles.Clear();

            // Create a series and bind data to it
            Series series = new Series("MC", ViewType.Spline);
            for (int i = 0; i < momentList.Count; i++)
            {
                series.Points.Add(new SeriesPoint(curvatureList[i], momentList[i]));
            }

            // Add the series to the chart
            chart.Series.Add(series);

            // Set chart title and axis labels if needed
            chart.Titles.Add(new ChartTitle { Text = "Moment - Curvature" });
            chart.Titles[0].DXFont = new DXFont("Tahoma", 16, DXFontStyle.Underline);
            chart.Titles[0].Visibility = DevExpress.Utils.DefaultBoolean.True;

            XYDiagram diagram = (XYDiagram)chart.Diagram;

            AxisX axisX = diagram.AxisX;
            axisX.Title.Text = "Curvature (rad/km)";
            diagram.AxisX.Title.DXFont = new DXFont("Tahoma", 14, DXFontStyle.Bold);
            axisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;

            AxisY axisY = diagram.AxisY;
            axisY.Title.Text = "Moment (kN.m)";
            diagram.AxisY.Title.DXFont = new DXFont("Tahoma", 14, DXFontStyle.Bold);
            axisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;


        }

        #endregion

        #region Events
        private void BtnDrawMC_Click(object sender, EventArgs e)
        {
            _NeutralAxisList.Clear();
            _MomentList.Clear();
            _CurvatureList.Clear();

            CalculateMomentCurvature();

            InitializeChartData(_MomentList, _CurvatureList);
        }


        #endregion


    }
}
