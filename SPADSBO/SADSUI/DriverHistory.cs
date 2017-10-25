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

namespace SADSUI
{
    [Activity(Label = "DriverHistory")]
    public class DriverHistory : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DriveHistory);
            ActionBar.Hide();

            var btnCancel = FindViewById<Button>(Resource.Id.btnHistoryBack);

            btnCancel.Click += btnCancel_Click;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var activity2 = new Intent(this, typeof(Home));
            StartActivity(activity2);
        }

    }
}