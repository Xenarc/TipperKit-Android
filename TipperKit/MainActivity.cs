using Android;
using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Views.InputMethods;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace TipperKit {
    public class Util {
        public static Tipper TipperCalculator = new Tipper();
        public static bool GenerateReport = false;
    }
    [Activity(Label = "MainActivity")]
    public class MainActivity : Activity {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            Android.Util.Log.Info("TipperKit", "Activity started");

            Tipper TipperCalculator = Util.TipperCalculator;
            Android.Util.Log.Info("TipperKit", "TipperCalculator has initialised");

            // Set the content view from Main.axml
            try {
                this.RequestWindowFeature(Android.Views.WindowFeatures.NoTitle); // Remove ActionBar
                SetContentView(Resource.Layout.Main);
                
            } catch (Exception e) {
                Android.Util.Log.Error("TipperKit", "SetContentView Failed: Stack Trace: " + e.StackTrace + " Message: " + e.Message + " Target Site: " + e.TargetSite);
                Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
            }
            // Fill out sample data
            FillData(0);

            TipperCalculator = new Tipper();

            Button ds = FindViewById<Button>(Resource.Id.button2);
            Button button = FindViewById<Button>(Resource.Id.button1);

            ds.Click += delegate {
                this.StartActivity(typeof(DataSheets));
            };
            button.Click += delegate {
                Android.Util.Log.Info("TipperKit", "Calculate Button was clicked");
                try {
                    TipperCalculator.Q9TrayWeightEmpty = int.Parse(FindViewById<EditText>(Resource.Id.editText1).Text);
                    TipperCalculator.Q10GrossTrayWeightLoaded = int.Parse(FindViewById<EditText>(Resource.Id.editText2).Text); // Tray weight Loaded
                    TipperCalculator.Q12DistanceBetweenPivotPoints = int.Parse(FindViewById<EditText>(Resource.Id.editText3).Text);
                    TipperCalculator.Q13CylinderStroke = int.Parse(FindViewById<EditText>(Resource.Id.editText4).Text);
                    TipperCalculator.Q14TrayLength = int.Parse(FindViewById<EditText>(Resource.Id.editText5).Text);

                    if (
                        TipperCalculator.Q9TrayWeightEmpty <= 0 ||
                        TipperCalculator.Q10GrossTrayWeightLoaded <= 0 ||
                        TipperCalculator.Q12DistanceBetweenPivotPoints <= 0 ||
                        TipperCalculator.Q13CylinderStroke <= 0 ||
                        TipperCalculator.Q14TrayLength <= 0
                    ) return;
                } catch (Exception e) {
                    Android.Util.Log.Info("TipperKit", "Failed! " + e.Message);
                    Toast.MakeText(ApplicationContext, "Error!", ToastLength.Long);
                    return;
                }
                
                    try {
                    TipperCalculator.Calculate();
                } catch (Exception e) {
                    Toast.MakeText(ApplicationContext, "CALC ERROR" + e.Message, ToastLength.Long);
                    Android.Util.Log.Info("TipperKit", "Calculation error! " + e.Message);
                }
                for (int i = 0; i < 20; i++) {     // Test Calculating for 20 times
                    TipperCalculator.Calculate();
                }
                if(TipperCalculator.E30CylinderPartNumber == "" || TipperCalculator.P3TipperKitPartNumber == "") {
                    Android.Util.Log.Info("TipperKit", "Calculation Failed");
                }
                Android.Util.Log.Info("TipperKit", "Calculation output. Overall: " + Convert.ToString(TipperCalculator.T68OverallApplicationSetup) + "\nPart Numbers: TipperKit - " + Convert.ToString(TipperCalculator.P3TipperKitPartNumber) + " and Cylinder - " + Convert.ToString(TipperCalculator.E30CylinderPartNumber));

                Util.TipperCalculator = TipperCalculator;
                this.StartActivity(typeof(Output));
            };
        }
        private void FillData(int i) {
            try {
                if (i == 0) {
                    FindViewById<EditText>(Resource.Id.editText1).Text = "800";
                    FindViewById<EditText>(Resource.Id.editText2).Text = "1000";
                    FindViewById<EditText>(Resource.Id.editText3).Text = "1500";
                    FindViewById<EditText>(Resource.Id.editText4).Text = "1250";
                    FindViewById<EditText>(Resource.Id.editText5).Text = "2000";
                    Android.Util.Log.Info("TipperKit", "Filled sample data 0");
                } else if (i == 1) {
                    FindViewById<EditText>(Resource.Id.editText1).Text = "150";
                    FindViewById<EditText>(Resource.Id.editText2).Text = "3500";
                    FindViewById<EditText>(Resource.Id.editText3).Text = "1000";
                    FindViewById<EditText>(Resource.Id.editText4).Text = "800";
                    FindViewById<EditText>(Resource.Id.editText5).Text = "2400";
                    Android.Util.Log.Info("TipperKit", "Filled sample data 1");
                }
            } catch (Exception e) {
                Android.Util.Log.Debug("TipperKit", "Probally Designer Error    " + e.Message);
            }
        }
    }
}