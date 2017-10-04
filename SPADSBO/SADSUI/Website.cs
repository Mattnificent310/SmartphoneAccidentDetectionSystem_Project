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
using Android.Webkit;

namespace SADSUI
{
    [Activity(Label = "Website")]
    public class Website : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Website);

            var btnCancel = FindViewById<Button>(Resource.Id.btnCancel);

            btnCancel.Click += btnCancel_Click;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var activity2 = new Intent(this, typeof(Home));
            StartActivity(activity2);
        }
    }

}