using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Views.InputMethods;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android;
using Android.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TipperKit {
    [Activity(Label = "Output")]
    public class Output : Activity {
        protected override void OnResume() {
            base.OnResume();
        }
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            try {
                int SmallFont = 14;
                this.RequestWindowFeature(Android.Views.WindowFeatures.NoTitle); // Remove ActionBar
                SetContentView(Resource.Layout.OutputLayout);
                Android.Util.Log.Debug("(*****************************************", "Set Content View");
                FindViewById<TextView>(Resource.Id.overallApplication).Background = new Android.Graphics.Drawables.ColorDrawable(Android.Graphics.Color.Argb(0xFF, 0x1F, 0x1F, 0x1F));
                // Recalculate
                Button Recalculate = FindViewById<Button>(Resource.Id.Recalculate);
                Button Continue = FindViewById<Button>(Resource.Id.GenerateReport);

                if (Util.TipperCalculator.T37FmaxGtY2) {
                    FindViewById<TextView>(Resource.Id.textViewA).SetBackgroundColor(Android.Graphics.Color.Green);
                    FindViewById<TextView>(Resource.Id.textViewA).SetText("Acceptable".ToCharArray(), 0, 10);
                } else {
                    FindViewById<TextView>(Resource.Id.textViewA).SetBackgroundColor(Android.Graphics.Color.Red);
                    FindViewById<TextView>(Resource.Id.textViewA).SetText("Unacceptable".ToCharArray(), 0, 12);
                    FindViewById<TextView>(Resource.Id.textViewA).TextSize = SmallFont;
                }
                if (Util.TipperCalculator.T38PLsPmax) {
                    FindViewById<TextView>(Resource.Id.textViewb).SetBackgroundColor(Android.Graphics.Color.Green);
                    FindViewById<TextView>(Resource.Id.textViewb).SetText("Acceptable".ToCharArray(), 0, 10);
                } else {
                    FindViewById<TextView>(Resource.Id.textViewb).SetBackgroundColor(Android.Graphics.Color.Red);
                    FindViewById<TextView>(Resource.Id.textViewb).SetText("Unacceptable".ToCharArray(), 0, 12);
                    FindViewById<TextView>(Resource.Id.textViewb).TextSize = SmallFont;
                }
                if (Util.TipperCalculator.T48dGt39Lt58) {
                    FindViewById<TextView>(Resource.Id.textViewc).SetBackgroundColor(Android.Graphics.Color.Green);
                    FindViewById<TextView>(Resource.Id.textViewc).SetText("Acceptable".ToCharArray(), 0, 10);
                } else {
                    FindViewById<TextView>(Resource.Id.textViewc).SetBackgroundColor(Android.Graphics.Color.Red);
                    FindViewById<TextView>(Resource.Id.textViewc).SetText("Unacceptable".ToCharArray(), 0, 12);
                    FindViewById<TextView>(Resource.Id.textViewc).TextSize = SmallFont;
                }
                if (Util.TipperCalculator.T39TactLtTmax) {
                    FindViewById<TextView>(Resource.Id.textViewd).SetBackgroundColor(Android.Graphics.Color.Green);
                    FindViewById<TextView>(Resource.Id.textViewd).SetText("Acceptable".ToCharArray(), 0, 10);
                } else {
                    FindViewById<TextView>(Resource.Id.textViewd).SetBackgroundColor(Android.Graphics.Color.Red);
                    FindViewById<TextView>(Resource.Id.textViewd).SetText("Unacceptable".ToCharArray(), 0, 12);
                    FindViewById<TextView>(Resource.Id.textViewd).TextSize = SmallFont;
                }
                if (Util.TipperCalculator.T41Srh6L) {
                    FindViewById<TextView>(Resource.Id.textViewf).SetBackgroundColor(Android.Graphics.Color.Green);
                    FindViewById<TextView>(Resource.Id.textViewf).SetText("Acceptable".ToCharArray(), 0, 10);
                } else {
                    FindViewById<TextView>(Resource.Id.textViewf).SetBackgroundColor(Android.Graphics.Color.Red);
                    FindViewById<TextView>(Resource.Id.textViewf).SetText("Unacceptable".ToCharArray(), 0, 12);
                }
                if (Util.TipperCalculator.T42SSH10L) {
                    FindViewById<TextView>(Resource.Id.textViewg).SetBackgroundColor(Android.Graphics.Color.Green);
                    FindViewById<TextView>(Resource.Id.textViewg).SetText("Acceptable".ToCharArray(), 0, 10);
                } else {
                    FindViewById<TextView>(Resource.Id.textViewg).SetBackgroundColor(Android.Graphics.Color.Red);
                    FindViewById<TextView>(Resource.Id.textViewg).SetText("Unacceptable".ToCharArray(), 0, 12);
                }
                if (Util.TipperCalculator.T43SSH15l) {
                    FindViewById<TextView>(Resource.Id.textViewH).SetBackgroundColor(Android.Graphics.Color.Green);
                    FindViewById<TextView>(Resource.Id.textViewH).SetText("Acceptable".ToCharArray(), 0, 10);
                } else {
                    FindViewById<TextView>(Resource.Id.textViewH).SetBackgroundColor(Android.Graphics.Color.Red);
                    FindViewById<TextView>(Resource.Id.textViewH).SetText("Unacceptable".ToCharArray(), 0, 12);
                }
                if (TipperKit.Util.TipperCalculator.T68OverallApplicationSetup) {
                    FindViewById<TextView>(Resource.Id.overallApplication).Background = new Android.Graphics.Drawables.ColorDrawable(Android.Graphics.Color.Green);
                    FindViewById<TextView>(Resource.Id.overallApplication).Text = "Application ACCEPTABLE";
                } else {
                    FindViewById<TextView>(Resource.Id.overallApplication).Text = "Application UNACCEPTABLE";
                    FindViewById<TextView>(Resource.Id.overallApplication).Background = new Android.Graphics.Drawables.ColorDrawable(Android.Graphics.Color.Red);
                }

                Recalculate.Click += delegate {
                    this.Finish();
                };
                FindViewById<EditText>(Resource.Id.OutputPartC).Text = Convert.ToString(Util.TipperCalculator.E30CylinderPartNumber);
                FindViewById<EditText>(Resource.Id.OutputPartT).Text = Convert.ToString(Util.TipperCalculator.P3TipperKitPartNumber);

                FindViewById<EditText>(Resource.Id.OutputA1).Text = Convert.ToString(Util.TipperCalculator.Q9TrayWeightEmpty);
                FindViewById<EditText>(Resource.Id.OutputA2).Text = Convert.ToString(Util.TipperCalculator.Q10GrossTrayWeightLoaded);
                FindViewById<EditText>(Resource.Id.OutputA3).Text = Convert.ToString(Util.TipperCalculator.Q11CenterOfGravity);
                FindViewById<EditText>(Resource.Id.OutputA4).Text = Convert.ToString(Util.TipperCalculator.Q12DistanceBetweenPivotPoints);
                FindViewById<EditText>(Resource.Id.OutputA5).Text = Convert.ToString(Util.TipperCalculator.Q13CylinderStroke);
                FindViewById<EditText>(Resource.Id.OutputA6).Text = Convert.ToString(Util.TipperCalculator.Q14TrayLength);
                FindViewById<EditText>(Resource.Id.OutputA7).Text = Convert.ToString(Math.Round(Util.TipperCalculator.Q15TippingAngle, 2));


                FindViewById<EditText>(Resource.Id.OutputA8).Text = Convert.ToString(Util.TipperCalculator.Q17MaxWorkingPressureOfCylinder);
                FindViewById<EditText>(Resource.Id.OutputA9).Text = Convert.ToString(Util.TipperCalculator.Q18FlowRateOfPowerPackRaise);
                FindViewById<EditText>(Resource.Id.OutputA10).Text = Convert.ToString(Util.TipperCalculator.Q19FlowRateOfPowerPackLower);

                FindViewById<EditText>(Resource.Id.OutputA11).Text = Convert.ToString(Util.TipperCalculator.Q23StrokeVolumeOfCylinder);
                FindViewById<EditText>(Resource.Id.OutputA12).Text = Convert.ToString(Util.TipperCalculator.Q24OverallCylinderDiameter);
                FindViewById<EditText>(Resource.Id.OutputA13).Text = Convert.ToString(Util.TipperCalculator.Q25SmallestRodDiameter);

                FindViewById<EditText>(Resource.Id.OutputA14).Text = Convert.ToString(Math.Round(Util.TipperCalculator.Q83PowerPackRaiseLowerTimeR, 2));
                FindViewById<EditText>(Resource.Id.OutputA15).Text = Convert.ToString(Math.Round(Util.TipperCalculator.Q84PowerPackRaiseLowerTimeL, 2));

                FindViewById<TextView>(Resource.Id.Sentance).Text = Convert.ToString("Cylinder is able to produce a force of " + Math.Round(Util.TipperCalculator.E66ForceRequiredY2 / 1000 / 10, 1) + " Tonne at a pressure of " + Math.Round(Util.TipperCalculator.E75PressureRequiredTheoPB, 1) + " Bar. " + "Cylinder can produce a maximum force of " + Math.Round(Util.TipperCalculator.H83ForceProducedMFWUO20KN / 10, 1) + " Tonne, which includes an underload of 20% with a maximum working pressure of 160 Bar.");
                Android.Util.Log.Debug("Tipperkit", Convert.ToString("Cylinder is able to produce a force of " + Math.Round(Util.TipperCalculator.E66ForceRequiredY2 / 1000/10, 1) + " at a pressure of " + Math.Round(Util.TipperCalculator.E75PressureRequiredTheoPB, 1) + " Bar." + "Cylinder can produce a maximum force of " + Math.Round(Util.TipperCalculator.H83ForceProducedMFWUO20KN/10, 1 ) + "Tonne, which includes an underload of 20% with a maximum working pressure of 160 Bar."));

                Util.GenerateReport = true;

                Continue.Click += delegate {
                    if (!Util.GenerateReport) {
                        this.Finish();

                    } else {
                        StartActivity(typeof(GenerateReport));

                    }
                };

            } catch(Exception e) {
                Android.Util.Log.Debug("TipperKit", "Set Content View FAILED: " + e.Message);
            }
        }
    }
}