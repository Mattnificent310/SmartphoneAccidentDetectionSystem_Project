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
using SADSUI.Resources.Modell;
using SADSUI.Resources;
using Android.Webkit;
using Android.Support.V4.App;

namespace SADSUI
{
    [Activity(Label = "AboutUs")]
    public class AboutUs : FragmentActivity
    {
        ListView lstData;
        List<Keys> lstSource = new List<Keys>();
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Fragment_AboutUs);



        }

      
    }

    
}