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
                if (Util.TipperCalculator.T37FmaxGtY2) {
                    FindViewById<TextView>(Resource.Id.textViewa).SetBackgroundColor(Android.Graphics.Color.Green);
                    FindViewById<TextView>(Resource.Id.textViewa).SetText("True".ToCharArray(), 0, 4);
                    FindViewById<TextView>(Resource.Id.textViewa).SetTextColor(Android.Graphics.Color.Black);
                } else {
                    FindViewById<TextView>(Resource.Id.textViewa).SetBackgroundColor(Android.Graphics.Color.Orange);
                }
                if (Util.TipperCalculator.T38PLsPmax) {
                    FindViewById<TextView>(Resource.Id.textViewb).SetBackgroundColor(Android.Graphics.Color.Green);
                    FindViewById<TextView>(Resource.Id.textViewb).SetText("True".ToCharArray(), 0, 4);
                    FindViewById<TextView>(Resource.Id.textViewb).SetTextColor(Android.Graphics.Color.Black);
                } else {
                    FindViewById<TextView>(Resource.Id.textViewb).SetBackgroundColor(Android.Graphics.Color.Orange);
                }
                if (Util.TipperCalculator.T48dGt39Lt58) {
                    FindViewById<TextView>(Resource.Id.textViewc).SetBackgroundColor(Android.Graphics.Color.Green);
                    FindViewById<TextView>(Resource.Id.textViewc).SetText("True".ToCharArray(), 0, 4);
                    FindViewById<TextView>(Resource.Id.textViewc).SetTextColor(Android.Graphics.Color.Black);
                } else {
                    FindViewById<TextView>(Resource.Id.textViewc).SetBackgroundColor(Android.Graphics.Color.Orange);
                }
                if (Util.TipperCalculator.T39TactLtTmax) {
                    FindViewById<TextView>(Resource.Id.textViewd).SetBackgroundColor(Android.Graphics.Color.Green);
                    FindViewById<TextView>(Resource.Id.textViewd).SetText("True".ToCharArray(), 0, 4);
                    FindViewById<TextView>(Resource.Id.textViewd).SetTextColor(Android.Graphics.Color.Black);
                } else {
                    FindViewById<TextView>(Resource.Id.textViewd).SetBackgroundColor(Android.Graphics.Color.Orange);
                }
                if (Util.TipperCalculator.T41Srh6L) {
                    FindViewById<TextView>(Resource.Id.textViewf).SetBackgroundColor(Android.Graphics.Color.Green);
                    FindViewById<TextView>(Resource.Id.textViewf).SetText("True".ToCharArray(), 0, 4);
                    FindViewById<TextView>(Resource.Id.textViewf).SetTextColor(Android.Graphics.Color.Black);
                } else {
                    FindViewById<TextView>(Resource.Id.textViewf).SetBackgroundColor(Android.Graphics.Color.Orange);
                }
                if (Util.TipperCalculator.T42SSH10L) {
                    FindViewById<TextView>(Resource.Id.textViewg).SetBackgroundColor(Android.Graphics.Color.Green);
                    FindViewById<TextView>(Resource.Id.textViewg).SetText("True".ToCharArray(), 0, 4);
                    FindViewById<TextView>(Resource.Id.textViewg).SetTextColor(Android.Graphics.Color.Black);
                } else {
                    FindViewById<TextView>(Resource.Id.textViewg).SetBackgroundColor(Android.Graphics.Color.Orange);
                }
                if (Util.TipperCalculator.T43SSH15l) {
                    FindViewById<TextView>(Resource.Id.textViewH).SetBackgroundColor(Android.Graphics.Color.Green);
                    FindViewById<TextView>(Resource.Id.textViewH).SetText("True".ToCharArray(), 0, 4);
                    FindViewById<TextView>(Resource.Id.textViewH).SetTextColor(Android.Graphics.Color.Black);
                } else {
                    FindViewById<TextView>(Resource.Id.textViewH).SetBackgroundColor(Android.Graphics.Color.Orange);
                }
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