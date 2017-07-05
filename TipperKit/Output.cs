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

namespace TipperKit {
    [Activity(Label = "Output", Theme = "@style/Theme.DeviceDefault.Light.DarkActionBar")]
    public class Output : Activity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            try {
                SetContentView(Resource.Layout.OutputLayout);

                // Recalculate
                Button Recalculate = FindViewById<Button>(Resource.Id.Recalculate);
                Button GenerateReport = FindViewById<Button>(Resource.Id.GenerateReport);

                Recalculate.Click += delegate {
                    this.Finish();
                    Android.Util.Log.Info("Tipperkit", "Recalculate button has been Pressed");
                };

                GenerateReport.Click += delegate {
                    Android.Util.Log.Info("Tipperkit", "GenerateReport button has been Pressed");
                    //Generate Report Activity
                };
            } catch {
                this.Dispose();
            }
        }
    }
}