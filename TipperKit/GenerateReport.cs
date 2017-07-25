﻿using System;
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
using System.IO;
using Android.Graphics;

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
            //SetContentView(Resource.Layout.GenerateReportLayout);
            
            Button Send = FindViewById<Button>(Resource.Id.Send);
            Button Back = FindViewById<Button>(Resource.Id.Back);

            Send.PerformClick(); // skips activity

            Back.Click += delegate {
                this.Finish();
            };

            Send.Click += delegate {
                var email = new Intent(Android.Content.Intent.ActionSend);
                email.PutExtra(Android.Content.Intent.ExtraEmail, new string[] {
                    FindViewById<EditText>(Resource.Id.editText1).Text
                });
                
                string filename = System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "Documents/TipperKitGeneratedReport.html");

                using (var streamWriter = new StreamWriter(filename, true)) {
                    streamWriter.WriteLine("<html> <head> <style media=\"screen\"> *{ margin: 0; padding: 0; } </style></head> <body style=\"margin: 0; padding: 0;\"> <div style=\"width: 600px; margin: auto; font-family: 'Segoe UI Light', 'Verdana', 'Arial', 'sans-serif'; background-color: #222; color: #FFF; padding: 0.5%;\"> <div style=\"font-size: 12pt;\"> <div style=\"clear: both;\"><h1 style=\"padding: 1%;clear: both; background-color: #00F; float: left;\">Cylinder Part Number: </h1><h1 style=\"background-color: #00F; padding: 1%; text-align: right; padding-right: 2%;\">4TG-E90*900QZ </h1></div> <div style=\"margin-top: 1%; clear: both;\"><h1 style=\"padding: 1%; clear: both; background-color: #00F; float: left;\">Tipper Kit Part Number: </h1><h1 style=\"background-color: #00F; padding: 1%; text-align: right; padding-right: 2%;\">TK*SHORT </h1></div> </div> <div style=\"clear: both;\"><h1 style=\"margin-top: 1.5%; padding: 1%;clear: both; background-color: #0F0; text-align: center; color: #000; float: left; width: 98%;\">Application ACCEPTABLE</h1></div> <h3 style=\"padding: 2%; clear: both; text-align: center;\">Cylinder is able to produce a maximum of 5.2 Tonne at a pressure of 144.2 Bar. Cylinder can produce a maximum force of 10.2 Tonne, which includes an underload of 20% with a maximum working pressure of 160 Bar</h3> <div> <h2 style=\"margin: 0; margin-bottom: 1%; text-align: center; background-color: #333; padading: 0.5%;\">Key</h2> <div> <h2 style=\"margin: 0; display: inline-block; float: left; width: 49%; background-color: #F00; color: black; text-align: center; padding: 0.5%;\">NOT Acceptable</h2> <h2 style=\"margin: 0; margin-bottom: 1%; display: inline-block; width: 49%; background-color: #0F0; color: black; text-align: center; padding: 0.5%;\">Acceptable</h2> </div> </div> <h2 style=\"margin-bottom: 1%; padding: 0.5%; background-color: #333; display: inline-block; width: 69%;\">SYSTEM OK = Fmax &gt; Y2</h2><h2 style=\"padding: 0.5%; text-align: center; float: right; display: inline-block; width: 29%; background-color: #0F0; color: #000;\">Acceptable</h2> <h2 style=\"margin-bottom: 1%; padding: 0.5%; background-color: #333; display: inline-block; width: 69%;\">SYSTEM OK = P &lt; Pmax</h2><h2 style=\"padding: 0.5%; text-align: center; float: right; display: inline-block; width: 29%; background-color: #0F0; color: #000;\">Acceptable</h2> <h2 style=\"margin-bottom: 1%; padding: 0.5%; background-color: #333; display: inline-block; width: 69%;\">SYSTEM OK = d &gt; 39&deg; &amp; &lt; 58&deg;</h2><h2 style=\"padding: 0.5%; text-align: center; float: right; display: inline-block; width: 29%; background-color: #0F0; color: #000;\">Acceptable</h2> <h2 style=\"margin-bottom: 1%; padding: 0.5%; background-color: #333; display: inline-block; width: 69%;\">SYSTEM OK = tact &lt; tmax</h2><h2 style=\"padding: 0.5%; text-align: center; float: right; display: inline-block; width: 29%; background-color: #0F0; color: #000;\">Acceptable</h2> <div style=\"margin-bottom: 1%;\"> <h2 style=\"margin: 0; padding: 0.5%; margin-right: 0.5%; background-color: #333; line-height: 46pt; float: left; display: inline-block; width: 39%;\">6L SRH (Option)</h2> <div style=\"display: inline-block; width: 29%;\"> <h3 style=\"padding: 0.5%; background-color: #333; display: block; line-height: 24pt; text-align: center;\">Tank Vol. (Usable) = </h3> <h3 style=\"padding: 0.5%; background-color: #444; display: block; line-height: 24pt; text-align: center; \">8.5</h3> </div> <h2 style=\"padding: 0.5%; text-align: center; float: right; display: inline-block; line-height: 46pt; background-color: #0F0; color: #000; width: 29%;\">Acceptable</h2> </div> <div style=\"margin-bottom: 1%;\"> <h2 style=\"margin: 0; padding: 0.5%; margin-right: 0.5%; background-color: #333; line-height: 46pt; float: left; display: inline-block; width: 39%;\">10L SSH (Standard)</h2> <div style=\"display: inline-block; width: 29%;\"> <h3 style=\"padding: 0.5%; background-color: #333; display: block; line-height: 24pt; text-align: center;\">Tank Vol. (Usable) = </h3> <h3 style=\"padding: 0.5%; background-color: #444; display: block; line-height: 24pt; text-align: center; \">8.5</h3> </div> <h2 style=\"padding: 0.5%; text-align: center; float: right; display: inline-block; line-height: 46pt; background-color: #0F0; color: #000; width: 29%;\">Acceptable</h2> </div> <div style=\"margin-bottom: 1%;\"> <h2 style=\"margin: 0; padding: 0.5%; margin-right: 0.5%; background-color: #333; line-height: 46pt; float: left; display: inline-block; width: 39%;\">15L SSH (Option)</h2> <div style=\"display: inline-block; width: 29%;\"> <h3 style=\"padding: 0.5%; background-color: #333; display: block; line-height: 24pt; text-align: center;\">Tank Vol. (Usable) = </h3> <h3 style=\"padding: 0.5%; background-color: #444; display: block; line-height: 24pt; text-align: center; \">13.5</h3> </div> <h2 style=\"padding: 0.5%; text-align: center; float: right; display: inline-block; line-height: 46pt; background-color: #0F0; color: #000; width: 29%;\">Acceptable</h2> </div> <div style=\"clear: both; text-align: center; font-family: 'Segoe UI', 'Verdana', 'Arial', 'sans-serif'; font-weight: 400;\"> <h2 style=\"font-family: 'Segoe UI Light'; margin-bottom: 0.6%; background-color: #DBAD20; color: #000; padding: 0.2%;\">Manually Inputted</h2> <div style=\"margin-bottom: 0.6%;\"> <div style=\"background-color: #DBAD20; float: left; color: #000; padding: 0.5%; display: inline-block; width: 75.5%; text-align: left;\">Tray Weight (Empty)</div> <div style=\"background-color: #DBAD20; float: center; color: #000; padding: 0.5%; display: inline-block; width: 10%; \">NULL</div> <div style=\"background-color: #DBAD20; float: right; color: #000; padding: 0.5%; display: inline-block; width: 10%; \">kg</div> </div> <div style=\"margin-bottom: 0.6%;\"> <div style=\"background-color: #DBAD20; float: left; color: #000; padding: 0.5%; display: inline-block; width: 75.5%; text-align: left; \">Gross Tray Weight (Loaded)</div> <div style=\"background-color: #DBAD20; float: center; color: #000; padding: 0.5%; display: inline-block; width: 10%; \">NULL</div> <div style=\"background-color: #DBAD20; float: right; color: #000; padding: 0.5%; display: inline-block; width: 10%; \">kg</div> </div> <div style=\"margin-bottom: 0.6%;\"> <div style=\"background-color: #DBAD20; color: #000; padding: 0.5%; display: inline-block; width: 63.5%; text-align: left;\">Distance Between Pivot Points</div> <div style=\"background-color: #DBAD20; color: #000; padding: 0.5%; display: inline-block; width: 10%; \">L1</div> <div style=\"background-color: #DBAD20; color: #000; padding: 0.5%; display: inline-block; width: 10%; \">NULL</div> <div style=\"background-color: #DBAD20; color: #000; padding: 0.5%; display: inline-block; width: 10%; \">mm</div> </div> <div style=\"margin-bottom: 0.6%;\"> <div style=\"background-color: #DBAD20; color: #000; padding: 0.5%; display: inline-block; width: 63.5%; text-align: left;\">Center of Gravity</div> <div style=\"background-color: #DBAD20; color: #000; padding: 0.5%; display: inline-block; width: 10%; \">L2</div> <div style=\"background-color: #DBAD20; color: #000; padding: 0.5%; display: inline-block; width: 10%; \">NULL</div> <div style=\"background-color: #DBAD20; color: #000; padding: 0.5%; display: inline-block; width: 10%; \">mm</div> </div> <div style=\"margin-bottom: 0.6%;\"> <div style=\"background-color: #DBAD20; color: #000; padding: 0.5%; display: inline-block; width: 63.5%; text-align: left;\">Cylinder Stroke </div> <div style=\"background-color: #DBAD20; color: #000; padding: 0.5%; display: inline-block; width: 10%; \">L3</div> <div style=\"background-color: #DBAD20; color: #000; padding: 0.5%; display: inline-block; width: 10%; \">NULL</div> <div style=\"background-color: #DBAD20; color: #000; padding: 0.5%; display: inline-block; width: 10%; \">mm</div> </div> <div style=\"margin-bottom: 0.6%;\"> <div style=\"background-color: #DBAD20; color: #000; padding: 0.5%; display: inline-block; width: 63.5%; text-align: left;\">Tray Length</div> <div style=\"background-color: #DBAD20; color: #000; padding: 0.5%; display: inline-block; width: 10%; \">L4</div> <div style=\"background-color: #DBAD20; color: #000; padding: 0.5%; display: inline-block; width: 10%; \">NULL</div> <div style=\"background-color: #DBAD20; color: #000; padding: 0.5%; display: inline-block; width: 10%; \">mm</div> </div> <div style=\"\"> <div style=\"background-color: #DBAD20; color: #000; padding: 0.5%; display: inline-block; width: 63.5%; text-align: left;\">Tipping Angle</div> <div style=\"background-color: #DBAD20; color: #000; padding: 0.5%; display: inline-block; width: 10%; \">Tilt</div> <div style=\"background-color: #DBAD20; color: #000; padding: 0.5%; display: inline-block; width: 10%; \">NULL</div> <div style=\"background-color: #DBAD20; color: #000; padding: 0.5%; display: inline-block; width: 10%; \">d</div> </div> </div> <div style=\"margin-top: 1%; clear: both; text-align: center; font-family: 'Segoe UI', 'Verdana', 'Arial', 'sans-serif'; font-weight: 400;\"> <h2 style=\"font-family: 'Segoe UI Light'; margin-bottom: 0.6%; background-color: #639144; color: #FFF; padding: 0.2%;\">Fixed Values</h2> <div style=\"\"> <div style=\"margin-bottom: 0.6%;\"> <div style=\"background-color: #639144; float: left; color: #FFF; padding: 0.5%; display: inline-block; width: 75.5%; text-align: left;\">Max Working Pressure of Cylinder (Pmax)</div> <div style=\"background-color: #639144; float: center; color: #FFF; padding: 0.5%; display: inline-block; width: 10%; \">NULL</div> <div style=\"background-color: #639144; float: right; color: #FFF; padding: 0.5%; display: inline-block; width: 10%; \">Bar</div> </div><div style=\"\"> <div style=\"margin-bottom: 0.6%;\"> <div style=\"background-color: #639144; float: left; color: #FFF; padding: 0.5%; display: inline-block; width: 75.5%; text-align: left;\">Flow Rate of Power Pack (Raise)</div> <div style=\"background-color: #639144; float: center; color: #FFF; padding: 0.5%; display: inline-block; width: 10%; \">NULL</div> <div style=\"background-color: #639144; float: right; color: #FFF; padding: 0.5%; display: inline-block; width: 10%; \">Bar</div> </div> </div> <div style=\"\"> <div style=\"margin-bottom: 0.6%;\"> <div style=\"background-color: #639144; float: left; color: #FFF; padding: 0.5%; display: inline-block; width: 75.5%; text-align: left;\">Flow Rate of Power Pack (Lower)</div> <div style=\"background-color: #639144; float: center; color: #FFF; padding: 0.5%; display: inline-block; width: 10%; \">NULL</div> <div style=\"background-color: #639144; float: right; color: #FFF; padding: 0.5%; display: inline-block; width: 10%; \">Bar</div> </div> </div> <div style=\"margin-top: 1%; clear: both; text-align: center; font-family: 'Segoe UI', 'Verdana', 'Arial', 'sans-serif'; font-weight: 400;\"> <h2 style=\"font-family: 'Segoe UI Light'; margin-bottom: 0.6%; background-color: #32cddb; color: #FFF; padding: 0.2%;\">Referenced Values</h2> <div style=\"\"> <div style=\"margin-bottom: 0.6%;\"> <div style=\"background-color: #32cddb; float: left; color: #FFF; padding: 0.5%; display: inline-block; width: 75.5%; text-align: left;\">Stroke Volume of Cylinder</div> <div style=\"background-color: #32cddb; float: center; color: #FFF; padding: 0.5%; display: inline-block; width: 10%; \">NULL</div> <div style=\"background-color: #32cddb; float: right; color: #FFF; padding: 0.5%; display: inline-block; width: 10%; \">Bar</div> </div> <div style=\"\"> <div style=\"margin-bottom: 0.6%;\"> <div style=\"background-color: #32cddb; float: left; color: #FFF; padding: 0.5%; display: inline-block; width: 75.5%; text-align: left;\">Overall Cylinder Diamter</div> <div style=\"background-color: #32cddb; float: center; color: #FFF; padding: 0.5%; display: inline-block; width: 10%; \">NULL</div> <div style=\"background-color: #32cddb; float: right; color: #FFF; padding: 0.5%; display: inline-block; width: 10%; \">I/min</div> </div> <div style=\"\"> <div style=\"background-color: #32cddb; float: left; color: #FFF; padding: 0.5%; display: inline-block; width: 75.5%; text-align: left;\">Smallest Rod Diameter</div> <div style=\"background-color: #32cddb; float: center; color: #FFF; padding: 0.5%; display: inline-block; width: 10%; \">NULL</div> <div style=\"background-color: #32cddb; float: right; color: #FFF; padding: 0.5%; display: inline-block; width: 10%; \">I/min</div> </div> </div> </div> </div> </body></html>");
                }

                email.PutExtra(Android.Content.Intent.ExtraSubject, FindViewById<EditText>(Resource.Id.editText2).Text);

                email.PutExtra(Intent.ExtraStream, Android.Net.Uri.FromFile(new Java.IO.File(System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "Documents/TipperKitGeneratedReport.html"))));
                email.SetType("message/rfc822");

                StartActivity(email);

                this.Finish();
            };
        }
    }
}
