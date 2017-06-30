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

            } catch (Exception) {
                this.Dispose();
            }

        }
    }
}