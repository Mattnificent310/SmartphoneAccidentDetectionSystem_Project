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
using Android.Support.V4.App;

namespace SADSUI
{
    [Activity(Label = "EmergencyInfo")]
    public class EmergencyInfo : Activity
    {
        private List<string> mItems;
        private ListView listview;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Fragment_EmergencyInfo);

           


        }
    }
}