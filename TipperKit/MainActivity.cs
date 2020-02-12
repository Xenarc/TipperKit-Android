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
    public static class Util {
        public static Tipper TipperCalculator = new Tipper();
        public static bool GenerateReport = false;
        public static int devOptionsCount = 0;

        public static bool DeveloperMode = false;
        public static bool Testing = false;
        public static bool FillSampleData = false;
    }

    [Activity(Label = "MainActivity")]
    public class MainActivity : Activity {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            Android.Util.Log.Info("TipperKit", "Activity started");

            bool CorrectOutput = false;

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

            if (Util.FillSampleData) FillData(1);

            TipperCalculator = new Tipper();

            Button ds = FindViewById<Button>(Resource.Id.button2);
            Button button = FindViewById<Button>(Resource.Id.button1);
            Button devOptions = FindViewById<Button>(Resource.Id.button3);

            devOptions.Click += delegate {
                if (Util.DeveloperMode)
                    this.StartActivity(typeof(DetailedOutput));
                else{
                    Util.devOptionsCount += 1;
                    if (Util.devOptionsCount >= 40)
                        Util.DeveloperMode = true;
                }
            };
            ds.Click += delegate {
                this.StartActivity(typeof(DataSheets));
            };
            button.Click += delegate {
                Android.Util.Log.Info("TipperKit", "Calculate Button was clicked");
                try {
                    do
                    {
                        if (Util.Testing == true){
                            // Fill out sample data
                            Random r = new Random();
                            int[] CylinderStrokes = new int[] { 800, 1000, 1250, 1500 };

                            InsertTestData(r.Next(150, 301), r.Next(1500, 3751), r.Next(900, 2101), CylinderStrokes[r.Next(0, 4)], r.Next(2400, 4201));
                        }
                        // Put the sample data into the text fields
                        TipperCalculator.Q9TrayWeightEmpty = int.Parse(FindViewById<EditText>(Resource.Id.editText1).Text);
                        TipperCalculator.Q10GrossTrayWeightLoaded = int.Parse(FindViewById<EditText>(Resource.Id.editText2).Text); // Tray weight Loaded
                        TipperCalculator.Q12DistanceBetweenPivotPoints = int.Parse(FindViewById<EditText>(Resource.Id.editText3).Text);
                        TipperCalculator.Q13CylinderStroke = int.Parse(FindViewById<EditText>(Resource.Id.editText4).Text);
                        TipperCalculator.Q14TrayLength = int.Parse(FindViewById<EditText>(Resource.Id.editText5).Text);

                        if ( // check that they are legal values
                            TipperCalculator.Q9TrayWeightEmpty <= 0 ||
                            TipperCalculator.Q10GrossTrayWeightLoaded <= 0 ||
                            TipperCalculator.Q12DistanceBetweenPivotPoints <= 0 ||
                            TipperCalculator.Q13CylinderStroke <= 0 ||
                            TipperCalculator.Q14TrayLength <= 0
                        ) return;
                    
                
                        try {
                            TipperCalculator.Calculate(); // try calculating
                        } catch (Exception e) {
                            Toast.MakeText(ApplicationContext, "CALC ERROR" + e.Message, ToastLength.Long); // calc error log and try and show toast
                            Android.Util.Log.Info("TipperKit", "Calculation error! " + e.Message);
                        }

                    
                        for (int i = 0; i < 20; i++)
                        {     // Test Calculating for 20 times
                            TipperCalculator.Calculate();
                        }
                        if (TipperCalculator.E30CylinderPartNumber == "" || TipperCalculator.P3TipperKitPartNumber == "") 
                        // does the cylinder part number and tipper part number = ""?
                        // if so the calculation is failed
                        {
                            Android.Util.Log.Info("TipperKit", "Calculation Failed");
                            CorrectOutput = false;
                        }
                        if (Util.Testing)
                        {
                            if (TipperCalculator.T68OverallApplicationSetup == true)
                                CorrectOutput = true;
                        }
                        else CorrectOutput = true;
                    } while ((!CorrectOutput && Util.Testing));
                    CorrectOutput = false;

                    Android.Util.Log.Info("TipperKit", "Calculation output. Overall: " + Convert.ToString(TipperCalculator.T68OverallApplicationSetup) + "\nPart Numbers: TipperKit - " + Convert.ToString(TipperCalculator.P3TipperKitPartNumber) + " and Cylinder - " + Convert.ToString(TipperCalculator.E30CylinderPartNumber));

                    Util.TipperCalculator = TipperCalculator;
                    this.StartActivity(typeof(Output));

                }catch (Exception e){
                    Android.Util.Log.Info("TipperKit", "Failed! " + e.Message);
                    Toast.MakeText(ApplicationContext, "Error!", ToastLength.Long);
                    return;
                }
            };
        }
        // TODO: Add automated testing from the expected values in excel from the spreadsheet
        //       With Testing table.

        // TODO: Add more documentaion.

        private void InsertTestData(int TrayWeightEmpty, int TrayWeightLoaded, int PivotPointsDistance, int CylinderStroke, int TrayLength)
        {
            try
            {
                FindViewById<EditText>(Resource.Id.editText1).Text = Convert.ToString(TrayWeightEmpty);
                FindViewById<EditText>(Resource.Id.editText2).Text = Convert.ToString(TrayWeightLoaded);
                FindViewById<EditText>(Resource.Id.editText3).Text = Convert.ToString(PivotPointsDistance);
                FindViewById<EditText>(Resource.Id.editText4).Text = Convert.ToString(CylinderStroke);
                FindViewById<EditText>(Resource.Id.editText5).Text = Convert.ToString(TrayLength);
            } catch (Exception e) {
                Android.Util.Log.Debug("TipperKit", "Probally Designer Error     " + e.Message);
            }
}
        private void FillData(int i) {
                if (i == 0) {
                    InsertTestData(800, 1000, 1500, 1250, 2000);
                    Android.Util.Log.Info("TipperKit", "Filled sample data 0");
                } else if (i == 1) {
                    InsertTestData(150, 3500, 1000, 800, 2400);
                    Android.Util.Log.Info("TipperKit", "Filled sample data 1");
                }
            
        }
    }
}