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
                InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Context.InputMethodService);

                inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);

                // Recalculate
                Button recalculate = FindViewById<Button>(Resource.Id.button1);

                recalculate.Click += delegate {
                    this.StartActivity(typeof(MainActivity));
                };
            } catch {
                this.Dispose();
            }
        }
    }
}