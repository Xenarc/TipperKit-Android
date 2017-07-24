using System;
using System.Text;
using Android.App;
using Android.OS;
using Android.Widget;
using Android.Graphics;
using static Android.Views.View;
using Android.Content.PM;

namespace TipperKit {
    [Activity(Label = "DataSheets")]
    public class DataSheets : Activity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            try {
                this.RequestWindowFeature(Android.Views.WindowFeatures.NoTitle); // Remove ActionBar
                this.RequestedOrientation = ScreenOrientation.Landscape; // Make Landscape Only

                SetContentView(Resource.Layout.DataSheetLayout);

            } catch (Exception e) {
                Android.Util.Log.Debug("TipperKit", "SetContentView() failed: " + e.Message);
            }

        }
    }
}