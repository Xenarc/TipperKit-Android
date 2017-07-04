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
    [Activity(Label = "Output")]
    public class Output : Activity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            try {
                SetContentView(Resource.Layout.OutputLayout);

                // Recalculate
                Button recalculate = FindViewById<Button>(Resource.Id.Recalculate);

                recalculate.Click += delegate {
                    this.Finish();
                    Android.Util.Log.Info("Tipperkit", "Recalculate button has been Pressed");
                };
            } catch {
                this.Dispose();
            }
        }
    }
}