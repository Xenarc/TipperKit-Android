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
                SetContentView(Resource.Layout.Main);
                
                //STYLING
                //Create Local Copies of 
                Button recalculateButton = FindViewById<Button>(Resource.Id.button1);
                
                try {
                    ActionBar.SetBackgroundDrawable(new Android.Graphics.Drawables.ColorDrawable(Android.Graphics.Color.Argb(0xFF, 0x1F, 0x1F, 0x1F)));
                    ActionBar.SetDisplayUseLogoEnabled(false);
                    ActionBar.SetIcon(BitmapDrawable.CreateFromPath("@drawable/icon"));
                } catch (Exception e) {
                    Android.Util.Log.Error("TipperKit", "ActionBarIcon Failed to load" + e.Message);
                    throw;
                }
                
                recalculateButton.SetBackgroundColor(Color.Argb(0xFF, 0x3F, 0x3F, 0x3F));
                
                
            } catch (Exception) {
                Android.Util.Log.Error("TipperKit", "SetContentView Failed  ");
            }
            // Fill out sample data
            //FillData();
            TipperCalculator = new Tipper();

            //Button ds = FindViewById<Button>(Resource.Id.button2);
            Button button = FindViewById<Button>(Resource.Id.button1);

            /*ds.Click += delegate {
                this.StartActivity(typeof(DataSheets));
            };*/
            button.Click += delegate {
                Android.Util.Log.Info("TipperKit", "Calculate Button was clicked");
                try {
                    TipperCalculator.Q9TrayWeightEmpty = int.Parse(FindViewById<EditText>(Resource.Id.editText1).Text);
                    TipperCalculator.Q10GrossTrayWeightLoaded = int.Parse(FindViewById<EditText>(Resource.Id.editText2).Text); // Tray weight Loaded
                    TipperCalculator.Q12DistanceBetweenPivotPoints = int.Parse(FindViewById<EditText>(Resource.Id.editText3).Text);
                    TipperCalculator.Q13CylinderStroke = int.Parse(FindViewById<EditText>(Resource.Id.editText4).Text);
                    TipperCalculator.Q14TrayLength = int.Parse(FindViewById<EditText>(Resource.Id.editText5).Text);
                    if (TipperCalculator.Q10GrossTrayWeightLoaded == null || TipperCalculator.Q9TrayWeightEmpty == null || TipperCalculator.Q12DistanceBetweenPivotPoints == null || TipperCalculator.Q13CylinderStroke == null || TipperCalculator.Q14TrayLength == null) {
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