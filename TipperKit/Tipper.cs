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

namespace TipperKit {
	public class Tipper {
        public Tipper() {
            initSRH();
            initSSH();
            initTipperKits();
        }

        public Datasheets.SRH[] SRH;
        public Datasheets.SSH[] SSH;
        public Datasheets.TipperKits[] TipperKits;

        public float Q8TrayWeightLoaded = 1000;
		public float Q9GrossTrayWeighEmpty = 800;
		public float Q10CenterOfGravity = 1000;
		public float Q11DistanceBetweenPivotPoints = 1500;
		public float Q12CylinderStroke = 1250;
		public float Q13TrayLength = 2000;
		public float Q14TippingAngle = 49.2f;

		public float MaxWorkingPressureOfCylinder;

		public float Q17MaxWorkingPressureOfCylinder = 160.0f;
		public float Q18FlowRateOfPowerPackRaise = 5.5f;
		public float Q19FlowRateOfPowerPackLower = 9.0f;

		public float Q22StrokeVolumeOfCylinder;
		public float Q23OverallCylinderDiameter;
		public float Q24SmallestRodDiameter;

		public string P3TipperKitPartNumber;
		public string E30CylinderPartNumber;

		public bool T37FmaxGtY2;
		public bool T38PLsPmax;
		public bool T48dGt39Lt58;
		public bool T39TactLtTmax;
		public bool T41Srh6L;
		public bool T42SSH10L;
		public bool T43SSH15l;

		public bool T68OverallApplicationSetup;

		public float g = 9.81f;
		public float Pi = 3.14f;
		public float PaNM = 1f;
		public float MpaPa = 1000000.0f;
		public float BarPa = 100000.0f;

		public float N54ForceAppliedW;
		public float E58ForceRequiredW;
		public float E59ForceRequiredL1;
		public float E60ForceRequiredL2;
        public float E61ForceRequiredL3;
		public float E67ForceRequiredY1;
		public float E66ForceRequiredY2;
		public float E70PressureRequiredCD;
		public float E71PressureRequiredCR;
		public float E72PressureRequiredA;
		public float E73PressureRequiredMFR;
		public float C75PressureRequiredTheoPNM;
		public float E75PressureRequiredTheoPB;

        public float E55ForceAppliedFullLoadW;// NEW
        public float E51ForceAppliedFullLoadM;
        public float E53ForceAppliedFullLoadO;
        public float E50ForceAppliedFullLoadAFO = 20;

        public float D78ForceProducedCD;
		public float D79ForceProducedCR;
		public float D80ForceProducedA;
		public float H78ForceProducedPA;
		public float H79ForceProducedBP;
		public float H80ForceProducedPNM;
		public float H82ForceProducedMFWUO20N;
		public float H83ForceProducedMFWUO20KN;

		public float M58ForceResistanceOfCylinderEPM = 1.9f;
		public float Q58ForceResistanceOfCylinderCD;
		public float Q59ForceResistanceOfCylinderCR;
		public float M59ForceResistanceOfCylinderA;
		public float O61ForceResistanceOfCylinderYN;
		public float Q61ForceResistanceOfCylinderYKN;
		public float O63ForceResistanceOfCylinderPNM;
		public float Q63ForceResistanceOfCylinderPB;

		public float N67ForceAppliedOnCylinderByNoLoadL1;
		public float N68ForceAppliedOnCylinderByNoLoadL2;
		public float Q67ForceAppliedOnCylinderByNoLoadW1;
		public float O70ForceAppliedOnCylinderByNoLoadY1N;
		public float Q70ForceAppliedOnCylinderByNoLoadY1KN;
		public float O72ForceAppliedOnCylinderByNoLoadP1NM;
		public float Q72ForceAppliedOnCylinderByNoLoadP1B;

		public float P78PowerPackRaiseLowerTimeRaiseF;
		public float P77PowerPackRaiseLowerTimeRaiseSV;
		public float P81PowerPackRaiseLowerTimeLowerF;
		public float Q83PowerPackRaiseLowerTimeR;
		public float Q84PowerPackRaiseLowerTimeL;

        public void initSRH() {
            SRH = new Datasheets.SRH[]{ new Datasheets.SRH("KR45W", 5, 3.8f, 170, 250), 
                new Datasheets.SRH("YBZ-TRYX-6L-W", 6, 5.2f, 178, 300), 
                new Datasheets.SRH("YBZ-TRYX-8L-W", 8, 6.8f, 178, 370),
                new Datasheets.SRH("YBZ-TRYX-8L-W", 8, 6.8f, 178, 370),
                new Datasheets.SRH("YBZ-TRYX-10L-W", 10, 8.1f, 178, 370),
                new Datasheets.SRH("YBZ-TRYX-12L-W", 12, 10.2f, 178, 540)
                };
        }

        public void initSSH() {

            SSH = new Datasheets.SSH[] { new Datasheets.SSH("TK - 36C", 10, 8.5f, 213, 198, 260),
                new Datasheets.SSH("TK-03", 12, 10.2f, 213, 198, 301.5f),
                new Datasheets.SSH("TK-120-15L-66-W-A", 15, 13.5f, 213, 198, 410),
                new Datasheets.SSH("TK-15", 20, 17.8f, 213, 198, 734),
                new Datasheets.SSH("TK-34", 25, 23.5f, 213, 198, 705)
                };
        }

        public void initTipperKits() {
            TipperKits = new Datasheets.TipperKits[]{new Datasheets.TipperKits(1, "4TG-E90*800QZ", 4, 800, 5, 3.2f, 21, 155, 223, 85, 43, 40, 112, 135, 378, "TK*SHORT", 90, 75, 60, 45, null, null, 10.2f, 7.1f, 4.5f, 2.5f, null, null, 3.5f),
                new Datasheets.TipperKits(3, "6TG-E105*1000QZ", 6, 1000, 6, 4.2f, 23, 160, 186, 85, 43, 40, 125, 150, 346, "TK*LONG", 105, 90, 75, 60, 45, 30, 13.9f, 10.2f, 7.1f, 4.5f, 2.5f, 1.1f, 4.6f),
                new Datasheets.TipperKits(5, "6TG-E120*1250QZ", 6, 1250, 9, 7.7f, 33, 160, 231, 85, 43, 45, 142, 165, 391, "TK*XLONG", 120, 105, 90, 75, 60, 45, 18.1f, 13.9f, 10.2f, 7.1f, 4.5f, 2.5f, 8.5f),
                new Datasheets.TipperKits(6, "6TG-E120*1500QZ", 6, 1500, 9, 8.7f, 37, 160, 273, 85, 43, 45, 142, 165, 433, "TK*XXLONG", 120, 105, 90, 75, 60, 45, 18.1f, 13.9f, 10.2f, 7.1f, 4.5f, 2.5f, 9.6f)
                };
        }

        public bool Calculate() {
            H83ForceProducedMFWUO20KN = H82ForceProducedMFWUO20N / 1000;
            O63ForceResistanceOfCylinderPNM = O61ForceResistanceOfCylinderYN / M59ForceResistanceOfCylinderA;
            Q63ForceResistanceOfCylinderPB = O63ForceResistanceOfCylinderPNM / PaNM;


            MaxWorkingPressureOfCylinder = 160;
            E61ForceRequiredL3 = Q12CylinderStroke;
            E67ForceRequiredY1 = E58ForceRequiredW - E66ForceRequiredY2;

            Q10CenterOfGravity = Q13TrayLength / 2;
			Q14TippingAngle = (float)Math.Acos((Q12CylinderStroke / Q13TrayLength));

			T37FmaxGtY2 = (H82ForceProducedMFWUO20N > E66ForceRequiredY2);
			H82ForceProducedMFWUO20N = H80ForceProducedPNM * D80ForceProducedA;
			H80ForceProducedPNM = H79ForceProducedBP * PaNM;
			H79ForceProducedBP = H78ForceProducedPA * BarPa;

			Q72ForceAppliedOnCylinderByNoLoadP1B = O72ForceAppliedOnCylinderByNoLoadP1NM / BarPa;
			H78ForceProducedPA = Q17MaxWorkingPressureOfCylinder;
			Q17MaxWorkingPressureOfCylinder = 160.0f;

			D80ForceProducedA = (D79ForceProducedCR * D79ForceProducedCR) * Pi;
			D79ForceProducedCR = (D78ForceProducedCD / 1000) / 2;
			D78ForceProducedCD = Q22StrokeVolumeOfCylinder; //Q23 IS REFERENCED

            T38PLsPmax = E75PressureRequiredTheoPB < H78ForceProducedPA;
			E75PressureRequiredTheoPB = C75PressureRequiredTheoPNM / 100000;
			C75PressureRequiredTheoPNM = E73PressureRequiredMFR / E72PressureRequiredA;
			E73PressureRequiredMFR = E66ForceRequiredY2;
			E66ForceRequiredY2 = E58ForceRequiredW * E59ForceRequiredL1 / E60ForceRequiredL2;
			E58ForceRequiredW = E55ForceAppliedFullLoadW;
            E55ForceAppliedFullLoadW = E51ForceAppliedFullLoadM * g + E53ForceAppliedFullLoadO;
            E51ForceAppliedFullLoadM = Q9GrossTrayWeighEmpty + Q83PowerPackRaiseLowerTimeR;
            E53ForceAppliedFullLoadO = E51ForceAppliedFullLoadM * g * (E50ForceAppliedFullLoadAFO / 100);

            E59ForceRequiredL1 = Q10CenterOfGravity;
			E60ForceRequiredL2 = Q11DistanceBetweenPivotPoints;

			E72PressureRequiredA = (E71PressureRequiredCR * E71PressureRequiredCR) * Pi;
			E71PressureRequiredCR = (E70PressureRequiredCD / 1000) / 2;
			H78ForceProducedPA = Q17MaxWorkingPressureOfCylinder;
			E70PressureRequiredCD = ((Q22StrokeVolumeOfCylinder + Q23OverallCylinderDiameter) / 2);
			Q23OverallCylinderDiameter = 0;

			T39TactLtTmax = Q70ForceAppliedOnCylinderByNoLoadY1KN > Q61ForceResistanceOfCylinderYKN;
			Q70ForceAppliedOnCylinderByNoLoadY1KN = O70ForceAppliedOnCylinderByNoLoadY1N / 1000;
			O70ForceAppliedOnCylinderByNoLoadY1N = (Q67ForceAppliedOnCylinderByNoLoadW1 * N67ForceAppliedOnCylinderByNoLoadL1) / N68ForceAppliedOnCylinderByNoLoadL2;
			N67ForceAppliedOnCylinderByNoLoadL1 = E59ForceRequiredL1;
			E59ForceRequiredL1 = Q10CenterOfGravity;
			N68ForceAppliedOnCylinderByNoLoadL2 = E60ForceRequiredL2;

			Q67ForceAppliedOnCylinderByNoLoadW1 = N54ForceAppliedW;
			N54ForceAppliedW = Q8TrayWeightLoaded * g;

			N67ForceAppliedOnCylinderByNoLoadL1 = E59ForceRequiredL1;
			N68ForceAppliedOnCylinderByNoLoadL2 = O70ForceAppliedOnCylinderByNoLoadY1N;

			Q61ForceResistanceOfCylinderYKN = O61ForceResistanceOfCylinderYN / 1000;
			O61ForceResistanceOfCylinderYN = (M58ForceResistanceOfCylinderEPM * BarPa) * M59ForceResistanceOfCylinderA;
			M59ForceResistanceOfCylinderA = (Q59ForceResistanceOfCylinderCR * Q59ForceResistanceOfCylinderCR) * Pi;
			Q59ForceResistanceOfCylinderCR = (Q58ForceResistanceOfCylinderCD / 1000) / 2;
			Q58ForceResistanceOfCylinderCD = Q22StrokeVolumeOfCylinder;

            if (E30CylinderPartNumber == TipperKits[0].Model) {
                Q22StrokeVolumeOfCylinder = TipperKits[0].Volume;

            } else if (E30CylinderPartNumber == TipperKits[1].Model) {
                Q22StrokeVolumeOfCylinder = TipperKits[1].Volume;

            } else if (E30CylinderPartNumber == TipperKits[2].Model) {
                Q22StrokeVolumeOfCylinder = TipperKits[2].Volume;

            } else if (E30CylinderPartNumber == TipperKits[3].Model) {
                Q22StrokeVolumeOfCylinder = TipperKits[3].Volume;

            } else {
                // ERROR = Data doesnt match Datasheet
            }

            if (E30CylinderPartNumber == TipperKits[0].Model) {
                Q23OverallCylinderDiameter = TipperKits[3].RodDiameterPerStage6th;

            } else if (E30CylinderPartNumber == TipperKits[1].Model) {
                Q23OverallCylinderDiameter = TipperKits[3].RodDiameterPerStage6th;

            } else if (E30CylinderPartNumber == TipperKits[2].Model) {
                Q23OverallCylinderDiameter = TipperKits[3].RodDiameterPerStage6th;

            } else if (E30CylinderPartNumber == TipperKits[3].Model) {
                Q23OverallCylinderDiameter = TipperKits[3].RodDiameterPerStage6th;

            } else {
                //ERROR!!!
            }

            if (E30CylinderPartNumber == TipperKits[0].Model) {
                Q24SmallestRodDiameter = TipperKits[0].RodDiameterPerStage1st;

            } else if (E30CylinderPartNumber == TipperKits[1].Model) {
                Q24SmallestRodDiameter = TipperKits[1].RodDiameterPerStage1st;
            
            } else if (E30CylinderPartNumber == TipperKits[2].Model) {
                Q24SmallestRodDiameter = TipperKits[2].RodDiameterPerStage1st;
            
            } else if (E30CylinderPartNumber == TipperKits[3].Model) {
                Q24SmallestRodDiameter = TipperKits[3].RodDiameterPerStage1st;
            
            } else {
                // ERROR = Data doesnt match Datasheet
            }

            T41Srh6L = Q22StrokeVolumeOfCylinder < SRH[1].UsableVol;
			T42SSH10L = Q22StrokeVolumeOfCylinder < SSH[0].UsableVol;
			T43SSH15l = Q22StrokeVolumeOfCylinder < SSH[2].UsableVol;

			T48dGt39Lt58 = Q14TippingAngle < 58 && Q14TippingAngle > 39;
			T68OverallApplicationSetup = T37FmaxGtY2 && T38PLsPmax && T39TactLtTmax && T48dGt39Lt58;

            if (P3TipperKitPartNumber == TipperKits[0].Kit) {
                E30CylinderPartNumber = TipperKits[0].Model;

            } else if (P3TipperKitPartNumber == TipperKits[1].Kit) {
                E30CylinderPartNumber = TipperKits[1].Model;

            } else if (P3TipperKitPartNumber == TipperKits[1].Kit) {            //I THINK THIS IS A MISTAKE Because its done twice in spreadsheet
                E30CylinderPartNumber = TipperKits[1].Model;

            } else if (P3TipperKitPartNumber == TipperKits[2].Kit) {
                E30CylinderPartNumber = TipperKits[2].Model;

            } else if (P3TipperKitPartNumber == TipperKits[3].Kit) {
                E30CylinderPartNumber = TipperKits[3].Model;

            } else { 
                //ERROR!!!
            }
            

            if (Q12CylinderStroke == TipperKits[0].Stroke) {
                P3TipperKitPartNumber = TipperKits[0].Model;

            } else if (Q12CylinderStroke == TipperKits[1].Stroke) {
                P3TipperKitPartNumber = TipperKits[1].Model;

            } else if (Q12CylinderStroke == TipperKits[1].Stroke) {
                P3TipperKitPartNumber = TipperKits[1].Model;

            } else if (Q12CylinderStroke == TipperKits[2].Stroke) {
                P3TipperKitPartNumber = TipperKits[2].Model;

            } else if (Q12CylinderStroke == TipperKits[3].Stroke) {
                P3TipperKitPartNumber = TipperKits[3].Model;

            } else {
                //ERROR!!!
            }




            return T68OverallApplicationSetup;
		}
	}

	public static class Datasheets {
		public class SRH {
            public SRH(string PartNo, int NomVol, float UsableVol, int Length, int Dia) {
                this.PartNo = PartNo;
                this.NomVol = NomVol;
                this.UsableVol = UsableVol;
                this.Dia = Dia;
                this.Length = Length;
            }
            public string PartNo;
            public int NomVol;
            public float UsableVol;
            public int Length;
            public int Dia;
		}
		public class SSH{
            public SSH(string PartNo, int NomVol, float UsableVol, int Length, int Width, float Height) {
                this.PartNo = PartNo;
                this.NomVol = NomVol;
                this.UsableVol = UsableVol;
                this.Width = Width;
                this.Height = Height;
                this.Length = Length;
            }
            public string PartNo;
            public int NomVol;
            public float UsableVol;
            public int Length;
            public int Width;
			public float Height;
		}
        public class TipperKits {
            public TipperKits(int? No, string Model, int? Extension, int? Stroke, int? Capacity, float? Volume, int? Weight, int? A, int? B, int? D, int? E, int? F, int? H, int? I, int? L, string Kit, int? RodDiameterPerStage1st, int? RodDiameterPerStage2nd, int? RodDiameterPerStage3rd, int? RodDiameterPerStage4th, int? RodDiameterPerStage5th, int? RodDiameterPerStage6th, float? TonForce160BarPerStage1st, float? TonForce160BarPerStage2nd, float? TonForce160BarPerStage3rd, float? TonForce160BarPerStage4th, float? TonForce160BarPerStage5th, float? TonForce160BarPerStage6th, float? MinOilCapCylCapPlus10Percent) {
                No = this.No;
                Model = this.Model;
                Extension = this.Extension;
                Stroke = this.Stroke;
                Capacity = this.Capacity;
                Volume = this.Volume;
                Weight = this.Weight;
                A = this.A;
                B = this.B;
                D = this.D;
                E = this.E;
                F = this.F;
                H = this.H;
                I = this.I;
                L = this.L;
                Kit = this.Kit;
                RodDiameterPerStage1st = this.RodDiameterPerStage1st;
                RodDiameterPerStage2nd = this.RodDiameterPerStage2nd;
                RodDiameterPerStage3rd = this.RodDiameterPerStage3rd;
                RodDiameterPerStage4th = this.RodDiameterPerStage4th;
                RodDiameterPerStage5th = this.RodDiameterPerStage5th;
                RodDiameterPerStage6th = this.RodDiameterPerStage6th;
                TonForce160BarPerStage1st = this.TonForce160BarPerStage1st;
                TonForce160BarPerStage2nd = this.TonForce160BarPerStage2nd;
                TonForce160BarPerStage3rd = this.TonForce160BarPerStage3rd;
                TonForce160BarPerStage4th = this.TonForce160BarPerStage4th;
                TonForce160BarPerStage5th = this.TonForce160BarPerStage5th;
                TonForce160BarPerStage6th = this.TonForce160BarPerStage6th;
                MinOilCapCylCapPlus10Percent = this.MinOilCapCylCapPlus10Percent;
            }

            public int No;
            public string Model;
            public int Extension;
            public int Stroke;
            public int Capacity;
            public float Volume;
            public int Weight;
            public int A;
            public int B;
            public int D;
            public int E;
            public int F;
            public int H;
            public int I;
            public int L;
            public string Kit;
            public int RodDiameterPerStage1st;
            public int RodDiameterPerStage2nd;
            public int RodDiameterPerStage3rd;
            public int RodDiameterPerStage4th;
            public int RodDiameterPerStage5th;
            public int RodDiameterPerStage6th;
            public float TonForce160BarPerStage1st;
            public float TonForce160BarPerStage2nd;
            public float TonForce160BarPerStage3rd;
            public float TonForce160BarPerStage4th;
            public float TonForce160BarPerStage5th;
            public float TonForce160BarPerStage6th;
            public float MinOilCapCylCapPlus10Percent;
        }
	}
}


