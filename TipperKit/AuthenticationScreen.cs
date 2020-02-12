using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TipperKit
{
    [Activity(Label = "AuthenticationScreen", NoHistory = true)]
    public class AuthenticationScreen : Activity
    {
        private int[] ClientNumbers = new int[] { 89125785, 64513146, 59851595, 44849136, 47926911, 96407037, 98069336, 80760305, 41991887, 75455148, 19239873, 50830613, 50190722, 50400859, 30697893, 94994120, 56474798, 88803146, 92258400, 37355139, 39705670, 13256980, 53889034, 32794131, 91244019, 92958641, 83781300, 84044693, 34114093, 47164486, 65571621, 66916465, 64179866, 69685820, 57439724, 86399064, 77443287, 57277930, 94215179, 22600769, 58541491, 61217874, 55005161, 49707504, 42662707, 85898365, 53711860, 91343885, 39155670, 88961320, 68553526, 67974861, 55910447, 19176686, 80264061, 15023129, 95627969, 31047980, 70794427, 32330104, 52976196, 12647738, 52110256, 34848218, 30297659, 29593892, 26944139, 65129784, 93498787, 96488713, 99824785, 24237948, 58041265, 55658398, 37772171, 93853667, 49839598, 54549610, 59485178, 42556733, 99057736, 92557404, 59554695, 90165180, 96421482, 19012228, 18125297, 39985145, 66478094, 34454034, 63181166, 54426210, 38409508, 25726334, 18222042, 96724201, 95171045, 72692962, 59765828, 43416174 };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.RequestWindowFeature(Android.Views.WindowFeatures.NoTitle); // Remove ActionBar
            SetContentView(Resource.Layout.AuthenticationScreen);
            Button Go = FindViewById<Button>(Resource.Id.Go);
            
            Context mContext = Android.App.Application.Context;
            AppPreferences ap = new AppPreferences(mContext);

            if (ap.getAccessKey() == "1")
            {
                this.StartActivity(typeof(MainActivity));
            }

            Go.Click += delegate
            {
                for (int i = 0; i < ClientNumbers.Length; i++)
                {
                    if (ClientNumbers[i] == Convert.ToDouble(FindViewById<EditText>(Resource.Id.ClientNumber).Text)) {
                        this.StartActivity(typeof(MainActivity));
                        ap.saveAccessKey("1");
                    }
                }
            };
        }
    }
    public class AppPreferences
    {
        private ISharedPreferences mSharedPrefs;
        private ISharedPreferencesEditor mPrefsEditor;
        private Context mContext;

        private static String PREFERENCE_ACCESS_KEY = "LOGGED_IN";

        public AppPreferences(Context context)
        {
            this.mContext = context;
            mSharedPrefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            mPrefsEditor = mSharedPrefs.Edit();
        }

        public void saveAccessKey(string key)
        {
            mPrefsEditor.PutString(PREFERENCE_ACCESS_KEY, key);
            mPrefsEditor.Commit();
        }

        public string getAccessKey()
        {
            return mSharedPrefs.GetString(PREFERENCE_ACCESS_KEY, "");
        }
    }
}