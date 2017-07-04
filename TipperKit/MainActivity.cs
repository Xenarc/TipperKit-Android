using Android;
using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Views.InputMethods;
using Android.Content;

namespace TipperKit {
    [Activity(Label = "TipperKit", Icon = "@drawable/icon")]
    public class MainActivity : Activity {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            Tipper TipperCalculator = new Tipper();
            // Set our view from the "main" layout resource
            try {
                SetContentView(Resource.Layout.Main);
            } catch (Exception) {
                Android.Util.Log.Error("TipperKit", "SetContentView Failed");
            }
            // Fill out sample data
            FillData();
            Button button = FindViewById<Button>(Resource.Id.button1);

            button.Click += delegate {
                try {
                    TipperCalculator.Q9GrossTrayWeighEmpty = float.Parse(FindViewById<EditText>(Resource.Id.editText1).Text); // Tray weight Loaded
                    TipperCalculator.Q8TrayWeightLoaded = float.Parse(FindViewById<EditText>(Resource.Id.editText2).Text);
                    TipperCalculator.Q11DistanceBetweenPivotPoints = float.Parse(FindViewById<EditText>(Resource.Id.editText3).Text);
                    TipperCalculator.Q12CylinderStroke = float.Parse(FindViewById<EditText>(Resource.Id.editText4).Text);
                    TipperCalculator.Q13TrayLength = float.Parse(FindViewById<EditText>(Resource.Id.editText5).Text);
                    if (TipperCalculator.Q9GrossTrayWeighEmpty == null || TipperCalculator.Q8TrayWeightLoaded == null || TipperCalculator.Q11DistanceBetweenPivotPoints == null || TipperCalculator.Q12CylinderStroke == null || TipperCalculator.Q13TrayLength == null) {
                        Toast.MakeText(ApplicationContext, "Fields were left blank!", ToastLength.Long);
                        return;
                    }
                } catch (Exception) {
                    Toast.MakeText(ApplicationContext, "Error!", ToastLength.Long);
                    return;
                }
                
                    try {
                    TipperCalculator.Calculate();
                } catch (Exception e) {
                    Toast.MakeText(ApplicationContext, "CALC ERROR" + e.Message, ToastLength.Long); 
                }
                TipperCalculator.Calculate();
                
                Android.Util.Log.Info("[TipperKit Calculated Output]", "Overall: " + Convert.ToString(TipperCalculator.T68OverallApplicationSetup) + "\nPart Numbers: TipperKit - " + Convert.ToString(TipperCalculator.P3TipperKitPartNumber) + " and Cylinder - " + Convert.ToString(TipperCalculator.E30CylinderPartNumber));

                this.StartActivity(typeof(Output));
            };
        }

        private void FillData() {
            EditText editText1 = FindViewById<EditText>(Resource.Id.editText1);
            EditText editText2 = FindViewById<EditText>(Resource.Id.editText2);
            EditText editText3 = FindViewById<EditText>(Resource.Id.editText3);
            EditText editText4 = FindViewById<EditText>(Resource.Id.editText4);
            EditText editText5 = FindViewById<EditText>(Resource.Id.editText5);

            editText1.SetText(String.valueOf(800));
            editText2.SetText(String.valueOf(1000));
            editText3.SetText(String.valueOf(1500));
            editText4.SetText(String.valueOf(1250));
            editText5.SetText(String.valueOf(2000));
        }
    }
}