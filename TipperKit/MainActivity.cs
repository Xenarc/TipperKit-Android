using Android;
using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Views.InputMethods;
using Android.Content;

namespace TipperKit {
    [Activity(Label = "TipperKit", Icon = "@drawable/icon", Theme = "@style/Theme.DeviceDefault.Light.DarkActionBar")]
    public class Util {
        public static Tipper TipperCalculator = new Tipper();
    }
    public class MainActivity : Activity {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            Android.Util.Log.Info("TipperKit", "Activity started");

            Tipper TipperCalculator = Util.TipperCalculator;
            Android.Util.Log.Info("TipperKit", "TipperCalculator has initialised");

            // Set the content view from Main.axml
            try {
                SetContentView(Resource.Layout.Main);
            } catch (Exception) {
                Android.Util.Log.Error("TipperKit", "SetContentView Failed  ");
            }
            // Fill out sample data
            FillData();
            Button button = FindViewById<Button>(Resource.Id.button1);

            button.Click += delegate {
                Android.Util.Log.Info("TipperKit", "Calculate Button was clicked");
                try {
                    TipperCalculator.Q9GrossTrayWeightEmpty = float.Parse(FindViewById<EditText>(Resource.Id.editText1).Text); // Tray weight Loaded
                    TipperCalculator.Q8TrayWeightLoaded = float.Parse(FindViewById<EditText>(Resource.Id.editText2).Text);
                    TipperCalculator.Q11DistanceBetweenPivotPoints = float.Parse(FindViewById<EditText>(Resource.Id.editText3).Text);
                    TipperCalculator.Q12CylinderStroke = float.Parse(FindViewById<EditText>(Resource.Id.editText4).Text);
                    TipperCalculator.Q13TrayLength = float.Parse(FindViewById<EditText>(Resource.Id.editText5).Text);
                    if (TipperCalculator.Q9GrossTrayWeightEmpty == null || TipperCalculator.Q8TrayWeightLoaded == null || TipperCalculator.Q11DistanceBetweenPivotPoints == null || TipperCalculator.Q12CylinderStroke == null || TipperCalculator.Q13TrayLength == null) {
                        Android.Util.Log.Info("TipperKit", "Calculate failed, fields were left blank!");
                        Toast.MakeText(ApplicationContext, "Fields were left blank!", ToastLength.Long);
                        return;
                    }
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
                for (int i = 0; i < 100; i++) {     // Test Calculating for 100 times
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
        private void FillData() {
            FindViewById<EditText>(Resource.Id.editText1).Text = "800";
            FindViewById<EditText>(Resource.Id.editText2).Text = "1000";
            FindViewById<EditText>(Resource.Id.editText3).Text = "1500";
            FindViewById<EditText>(Resource.Id.editText4).Text = "1250";
            FindViewById<EditText>(Resource.Id.editText5).Text = "2000";
            Android.Util.Log.Info("TipperKit", "Filled sample data");
        }
    }
}