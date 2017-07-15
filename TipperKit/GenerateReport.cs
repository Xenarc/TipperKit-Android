using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net.Mail;

namespace TipperKit {
    [Activity(Label = "GenerateReport")]
    public class GenerateReport : Activity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            if (!Util.GenerateReport) {
                this.Finish();
                this.StartActivity(typeof(MainActivity));
            }

            this.RequestWindowFeature(Android.Views.WindowFeatures.NoTitle); // Remove ActionBar
            SetContentView(Resource.Layout.GenerateReportLayout);

            Button Send = FindViewById<Button>(Resource.Id.Send);
            Button Back = FindViewById<Button>(Resource.Id.Back);

            Back.Click += delegate {
                this.Finish();
            };

            Send.Click += delegate {
                var email = new Intent(Android.Content.Intent.ActionSend);
                email.PutExtra(Android.Content.Intent.ExtraEmail, new string[] {
                    FindViewById<EditText>(Resource.Id.editText1).Text
                });
                email.PutExtra(Android.Content.Intent.ExtraSubject, FindViewById<EditText>(Resource.Id.editText2).Text);
                email.PutExtra(Android.Content.Intent.ExtraText, FindViewById<EditText>(Resource.Id.Message).Text + "\n" + FindViewById<EditText>(Resource.Id.Report));
                email.SetType("message/rfc822");
                StartActivity(email);
                this.Finish();
            };
        }
    }
}