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
    [Activity(Label = "Drive")]
    public class Drive : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Fragment_Drive);

            var btnClick = FindViewById<Button>(Resource.Id.btnDrive);

            btnClick.Click += (s, e) =>
            {
               
            };
        }
    }
}