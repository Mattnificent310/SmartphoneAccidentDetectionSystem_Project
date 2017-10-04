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
using Android.Locations;

namespace SADSUI
{
    [Activity(Label = "ReportAccident")]
    public class ReportAccident : FragmentActivity,ILocationListener
    {
        LocationManager location;
        String provider;

        protected override void OnResume()
        {
            base.OnResume();
            location.RequestLocationUpdates(provider, 400, 1, this);
        }

        protected override void OnPause()
        {
            base.OnPause();
            location.RemoveUpdates(this);
        }

        public void OnLocationChanged(Location location)
        {
            Double lat, lng;
            lat = location.Latitude;
            lng = location.Longitude;

        }

        public void OnProviderDisabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            SetContentView(Resource.Layout.Fragment_Report);

            var spinner1 = FindViewById<Spinner>(Resource.Id.spinnerServerity);
            var spinner2 = FindViewById<Spinner>(Resource.Id.spinnerCarsInvolved);
            //spinner1.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_Itemselected);
            var adaptor1 = ArrayAdapter.CreateFromResource(this, Resource.Array.ServerityLevel, Android.Resource.Layout.SimpleSpinnerItem);
            var adaptor2 = ArrayAdapter.CreateFromResource(this, Resource.Array.CarsInvolved, Android.Resource.Layout.SimpleSpinnerItem);

            adaptor1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            adaptor2.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner1.Adapter = adaptor1;
            spinner2.Adapter = adaptor2;

        }

        private void spinner_Itemselected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var spinner = sender as Spinner;
            Toast.MakeText(this, "Your choose: " + spinner.GetItemAtPosition(e.Position), ToastLength.Short);
        }
    }
}