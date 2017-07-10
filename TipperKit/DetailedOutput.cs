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
using Android;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace TipperKit {
    [Activity(Label = "DetailedOutput")]
    public class DetailedOutput : Activity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DetailedOutputLayout);
            ActionBar.SetBackgroundDrawable(new Android.Graphics.Drawables.ColorDrawable(Android.Graphics.Color.Argb(0xFF, 0x1F, 0x1F, 0x1F)));


            //FindViewById<Button>(Resource.Id.Output).Text = Convert.ToString(Util.TipperCalculator.);
            //Force Applied Full Load
            FindViewById<EditText>(Resource.Id.Output49).Text = Convert.ToString(Util.TipperCalculator.E50ForceAppliedFullLoadAFO);
            FindViewById<EditText>(Resource.Id.Output1).Text = Convert.ToString(Util.TipperCalculator.E51ForceAppliedFullLoadM);
            FindViewById<EditText>(Resource.Id.Output2).Text = Convert.ToString(Util.TipperCalculator.g);
            FindViewById<EditText>(Resource.Id.Output3).Text = Convert.ToString(Util.TipperCalculator.E53ForceAppliedFullLoadO);
            FindViewById<EditText>(Resource.Id.Output4).Text = Convert.ToString(Util.TipperCalculator.E55ForceAppliedFullLoadW);

            //Force Applied (No Load)
            FindViewById<EditText>(Resource.Id.Output5).Text = Convert.ToString(Util.TipperCalculator.Q9TrayWeightEmpty);
            FindViewById<EditText>(Resource.Id.Output6).Text = Convert.ToString(Util.TipperCalculator.g);
            FindViewById<EditText>(Resource.Id.Output7).Text = Convert.ToString(Util.TipperCalculator.N57ForceAppliedW);
            FindViewById<EditText>(Resource.Id.Output8).Text = Convert.ToString(Util.TipperCalculator.BarPa);
            FindViewById<EditText>(Resource.Id.Output9).Text = Convert.ToString(Util.TipperCalculator.PaNM);
            FindViewById<EditText>(Resource.Id.Output10).Text = Convert.ToString(Util.TipperCalculator.Pi);
            FindViewById<EditText>(Resource.Id.Output11).Text = Convert.ToString(Util.TipperCalculator.MpaPa);

            //Force Required to lift a full load
            FindViewById<EditText>(Resource.Id.Output12).Text = Convert.ToString(Util.TipperCalculator.E58ForceRequiredW);
            FindViewById<EditText>(Resource.Id.Output13).Text = Convert.ToString(Util.TipperCalculator.E59ForceRequiredL1);
            FindViewById<EditText>(Resource.Id.Output14).Text = Convert.ToString(Util.TipperCalculator.E60ForceRequiredL2);
            FindViewById<EditText>(Resource.Id.Output15).Text = Convert.ToString(Util.TipperCalculator.E61ForceRequiredL3);
            FindViewById<EditText>(Resource.Id.Output16).Text = Convert.ToString(Util.TipperCalculator.E66ForceRequiredY2);
            FindViewById<EditText>(Resource.Id.Output17).Text = Convert.ToString(Util.TipperCalculator.E67ForceRequiredY1);

            //Pressure Required to Lift a full load
            FindViewById<EditText>(Resource.Id.Output18).Text = Convert.ToString(Util.TipperCalculator.E73PressureRequiredCD);
            FindViewById<EditText>(Resource.Id.Output19).Text = Convert.ToString(Util.TipperCalculator.E74PressureRequiredCR);
            FindViewById<EditText>(Resource.Id.Output20).Text = Convert.ToString(Util.TipperCalculator.E75PressureRequiredA);
            FindViewById<EditText>(Resource.Id.Output21).Text = Convert.ToString(Util.TipperCalculator.E76PressureRequiredMFR);
            FindViewById<EditText>(Resource.Id.Output24).Text = Convert.ToString(Util.TipperCalculator.C75PressureRequiredTheoPNM);
            FindViewById<EditText>(Resource.Id.Output25).Text = Convert.ToString(Util.TipperCalculator.E75PressureRequiredTheoPB);

            //Force Resistance of Cylinder
            FindViewById<EditText>(Resource.Id.Output26).Text = Convert.ToString(Util.TipperCalculator.M58ForceResistanceOfCylinderEPM);
            FindViewById<EditText>(Resource.Id.Output27).Text = Convert.ToString(Util.TipperCalculator.M59ForceResistanceOfCylinderA);
            FindViewById<EditText>(Resource.Id.Output28).Text = Convert.ToString(Util.TipperCalculator.Q58ForceResistanceOfCylinderCD);
            FindViewById<EditText>(Resource.Id.Output29).Text = Convert.ToString(Util.TipperCalculator.Q59ForceResistanceOfCylinderCR);
            FindViewById<EditText>(Resource.Id.Output30).Text = Convert.ToString(Util.TipperCalculator.O61ForceResistanceOfCylinderYN);
            FindViewById<EditText>(Resource.Id.Output31).Text = Convert.ToString(Util.TipperCalculator.Q61ForceResistanceOfCylinderYKN);
            FindViewById<EditText>(Resource.Id.Output32).Text = Convert.ToString(Util.TipperCalculator.O63ForceResistanceOfCylinderPNM);
            FindViewById<EditText>(Resource.Id.Output33).Text = Convert.ToString(Util.TipperCalculator.Q63ForceResistanceOfCylinderPB);

            //Force applied on cylinder by no load equally distributed 
            FindViewById<EditText>(Resource.Id.Output34).Text = Convert.ToString(Util.TipperCalculator.N67ForceAppliedOnCylinderByNoLoadL1);
            FindViewById<EditText>(Resource.Id.Output35).Text = Convert.ToString(Util.TipperCalculator.N68ForceAppliedOnCylinderByNoLoadL2);
            FindViewById<EditText>(Resource.Id.Output36).Text = Convert.ToString(Util.TipperCalculator.Q67ForceAppliedOnCylinderByNoLoadW1);
            FindViewById<EditText>(Resource.Id.Output37).Text = Convert.ToString(Util.TipperCalculator.O70ForceAppliedOnCylinderByNoLoadY1N);
            FindViewById<EditText>(Resource.Id.Output38).Text = Convert.ToString(Util.TipperCalculator.Q70ForceAppliedOnCylinderByNoLoadY1KN);
            FindViewById<EditText>(Resource.Id.Output39).Text = Convert.ToString(Util.TipperCalculator.O72ForceAppliedOnCylinderByNoLoadP1NM);
            FindViewById<EditText>(Resource.Id.Output40).Text = Convert.ToString(Util.TipperCalculator.Q72ForceAppliedOnCylinderByNoLoadP1B);

            //Powerpack raise lower times
            FindViewById<EditText>(Resource.Id.Output41).Text = Convert.ToString(Util.TipperCalculator.MinSec);
            FindViewById<EditText>(Resource.Id.Output42).Text = Convert.ToString(Util.TipperCalculator.P77PowerPackRaiseLowerTimeRaiseSV);
            FindViewById<EditText>(Resource.Id.Output44).Text = Convert.ToString(Util.TipperCalculator.P78PowerPackRaiseLowerTimeRaiseF);
            FindViewById<EditText>(Resource.Id.Output46).Text = Convert.ToString(Util.TipperCalculator.P81PowerPackRaiseLowerTimeLowerF);
            FindViewById<EditText>(Resource.Id.Output47).Text = Convert.ToString(Util.TipperCalculator.Q18FlowRateOfPowerPackRaise);
            FindViewById<EditText>(Resource.Id.Output48).Text = Convert.ToString(Util.TipperCalculator.Q19FlowRateOfPowerPackLower);

        }
    }
}