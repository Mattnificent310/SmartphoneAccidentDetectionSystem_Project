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
using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.Webkit;
using Android.Locations;
using Android.Views.Animations;


namespace SADSUI
{
    [Activity(Label = "Home")]
    public class Home : FragmentActivity
    {
        private ViewPager mViewPager;
        private SlidingTabScrollView mScrollView;
        static readonly string TAG = "X:" + typeof(Home).Name;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Home);

            mScrollView = FindViewById<SlidingTabScrollView>(Resource.Id.sliding_tabs);
            mViewPager = FindViewById<ViewPager>(Resource.Id.viewPager);

            mViewPager.Adapter = new SamplePagerAdapter(SupportFragmentManager);
            mScrollView.ViewPager = mViewPager;

           
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public class SamplePagerAdapter : FragmentPagerAdapter
        {
            private List<Android.Support.V4.App.Fragment> mFragmentHolder;

            public SamplePagerAdapter(Android.Support.V4.App.FragmentManager fragManager) : base(fragManager)
            {
                mFragmentHolder = new List<Android.Support.V4.App.Fragment>();
                mFragmentHolder.Add(new Fragment1());
                mFragmentHolder.Add(new Fragment3());
                mFragmentHolder.Add(new Fragment4());
                mFragmentHolder.Add(new Fragment2());
                mFragmentHolder.Add(new Fragment5());
            }

            public override int Count
            {
                get { return mFragmentHolder.Count; }
            }

            public override Android.Support.V4.App.Fragment GetItem(int position)
            {
                return mFragmentHolder[position];
            }
        }

        public class Fragment1 : Android.Support.V4.App.Fragment
        {
           
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                var view = inflater.Inflate(Resource.Layout.Fragment_Drive, container, false);

                var rotateAboutCenterButton = view.FindViewById<ImageButton>(Resource.Id.btnDrive);
                var rotateAboutCenterAnimation = AnimationUtils.LoadAnimation(this.Context, Resource.Animation.rotate_center);
                rotateAboutCenterButton.Click += (sender, args) => rotateAboutCenterButton.StartAnimation(rotateAboutCenterAnimation);

                return view;
            }

            public override string ToString() 
            {
                return "Drive";
            }
        }

        public class Fragment2 : Android.Support.V4.App.Fragment
        {
            private Button btnEditProfile;
            private Button btnHistory;

            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                var view = inflater.Inflate(Resource.Layout.Fragment_PersonalProfile, container, false);
                btnEditProfile = view.FindViewById<Button>(Resource.Id.btnEditProfile);
                btnEditProfile.Click += BtnOption_Click;
                btnHistory = view.FindViewById<Button>(Resource.Id.btnProfileHistory);
                btnHistory.Click += BtnHistory_Click;
                return view;
            }

            private void BtnHistory_Click(object sender, EventArgs e)
            {
                var activity2 = new Intent(this.Context, typeof(DriverHistory));
                StartActivity(activity2);
            }

            private void BtnOption_Click(object sender, EventArgs e)
            {
                var activity2 = new Intent(this.Context, typeof(Website));
                StartActivity(activity2);
            }

            public override string ToString() 
            {
                return "Personal Profile";
            }
        }

        public class Fragment3 : Android.Support.V4.App.Fragment, ILocationListener
        {
            Location _currentLocation;
            LocationManager _locationManager;
            String _locationProvider;
            private TextView address;
            private TextView txtLocation;
            private string latitud;
            private string longitud;
          public string AddressReport;


            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
               View view = inflater.Inflate(Resource.Layout.Fragment_Report, container, false);

               
                txtLocation = view.FindViewById<TextView>(Resource.Id.location_text);

                InitializeLocationManager();

                var btnGetLocation = view.FindViewById<Button>(Resource.Id.get_address_button);
                btnGetLocation.Click += GetLocation_OnClick;
                var btnSendReport = view.FindViewById<Button>(Resource.Id.btnSendReport);
                btnGetLocation.Click += SendEmail_OnClick;

                var spinner1 = view.FindViewById<Spinner>(Resource.Id.spinnerServerity);
                var spinner2 = view.FindViewById<Spinner>(Resource.Id.spinnerCarsInvolved);
                var spinner3 = view.FindViewById<Spinner>(Resource.Id.spinnerType);
                spinner1.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_Itemselected);
                var adaptor1 = ArrayAdapter.CreateFromResource(this.Context, Resource.Array.ServerityLevel, Android.Resource.Layout.SimpleSpinnerItem);
                var adaptor2 = ArrayAdapter.CreateFromResource(this.Context, Resource.Array.CarsInvolved, Android.Resource.Layout.SimpleSpinnerItem);
                var adaptor3 = ArrayAdapter.CreateFromResource(this.Context, Resource.Array.Type, Android.Resource.Layout.SimpleSpinnerItem);
                adaptor1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
                adaptor2.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
                adaptor3.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
                spinner1.Adapter = adaptor1;
                spinner2.Adapter = adaptor2;
                spinner3.Adapter = adaptor3;
                return view;
            }

            private async System.Threading.Tasks.Task ReverseGeocodeCurrentLocationAsync()
            {
                
            }

            private void InitializeLocationManager()
            {
                _locationManager = (LocationManager)Activity.GetSystemService(Context.LocationService);
                Criteria criteriaForLocationService = new Criteria
                {
                    Accuracy = Accuracy.Fine
                };
                IList<string> acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);
                if (acceptableLocationProviders.Any())
                {
                    _locationProvider = acceptableLocationProviders.First();
                }
                else
                {
                    _locationProvider = String.Empty;
                }
            }

            public void OnLocationChanged(Location location)
            {
                _currentLocation = location;
                if (_currentLocation == null)
                {
                    Toast.MakeText(Activity.ApplicationContext, "No se pudo obtener la localizacion", ToastLength.Long).Show();
                }
                else
                {

                    latitud = _currentLocation.Latitude.ToString();
                    longitud = _currentLocation.Longitude.ToString();
                    Geocoder geocoder = new Geocoder(this.Context);
                    IList<Address> addressList =
                         geocoder.GetFromLocation(_currentLocation.Latitude, _currentLocation.Longitude, 10);

                    Address address = addressList.FirstOrDefault();
                    AddressReport = address.GetAddressLine(0);
                    txtLocation.Text = AddressReport;
                   // txtLocation.Text = "Location : " + latitud + ", " + longitud;
                }
            }

            public void OnProviderDisabled(string provider)
            {
                throw new NotImplementedException();
            }

            public void OnProviderEnabled(string provider)
            {
                throw new NotImplementedException();
            }

            public void OnStatusChanged(string provider, Availability status, Bundle extras)
            {
                
            }

            public override void OnResume()
            {
                base.OnResume();
                _locationManager.RequestLocationUpdates(_locationProvider, 0, 0, this);
            }

            public override void OnPause()
            {
                base.OnPause();
                _locationManager.RemoveUpdates(this);
            }

            private void SendEmail_OnClick(object sender, EventArgs e)
            {
                var btnSendReport = View.FindViewById<Button>(Resource.Id.btnSendReport);
                btnSendReport.Click += SendReport_Click;
                
            }

            private void SendReport_Click(object sender, EventArgs e)
            {
                var emailIntent = new Intent(Android.Content.Intent.ActionSend);
                emailIntent.PutExtra(Android.Content.Intent.ExtraEmail, new[] { "Reports.sads@gmail.com" });

                var spinReportType = View.FindViewById<Spinner>(Resource.Id.spinnerType);
                var spinServerity = View.FindViewById<Spinner>(Resource.Id.spinnerServerity);
                var spinV = View.FindViewById<Spinner>(Resource.Id.spinnerCarsInvolved);

                emailIntent.PutExtra(Android.Content.Intent.ExtraSubject, "By-Stander Report");
                emailIntent.SetType("text/plain");
                emailIntent.PutExtra(Android.Content.Intent.ExtraText, "Accident Reported by Jean-Louis Els \n" + "Report Type : " + spinReportType.SelectedItem + "\n Serverity Level : " + spinServerity.SelectedItem + "\n Number of vehicles involved : " + spinV.SelectedItem + "\n Location : " + AddressReport);
                StartActivity(emailIntent);
            }

            private void GetLocation_OnClick(object sender, EventArgs e)
            {
                var btnReport = View.FindViewById<Button>(Resource.Id.btnSendReport);
                btnReport.Enabled = true;
            }

            private void spinner_Itemselected(object sender, AdapterView.ItemSelectedEventArgs e)
            {
                var spinner1 = sender as Spinner;
                Toast.MakeText(this.Context, "your choose : " + spinner1.GetItemAtPosition(e.Position), ToastLength.Short);
            }

            public override string ToString() //Called on line 156 in SlidingTabScrollView
            {
                return "Report Accident";
            }
        }

        public class Fragment4 : Android.Support.V4.App.Fragment
        {
            protected List<string> mItems;
            protected ListView listview;

            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {

                var view = inflater.Inflate(Resource.Layout.Fragment_EmergencyInfo, container, false);
                listview = view.FindViewById<ListView>(Resource.Id.EmergencyListView);

                mItems = new List<string>();
                mItems.Add("911");
                mItems.Add("Police");
                mItems.Add("Ambulance respond team");
                mItems.Add("Fire Rescue respond team");
                mItems.Add("Emergincy Medical unit");
                mItems.Add("Tow-Away responds team");
                mItems.Add("24/7 Medical Unit");

                ArrayAdapter<string> adapter = new ArrayAdapter<string>(this.Context, Android.Resource.Layout.SimpleListItem1, mItems);

                listview.Adapter = adapter;
                listview.ItemClick += (s, e) => 
                {
                    Toast.MakeText(this.Context,"Calling", ToastLength.Short).Show();
                };

                return view;
            }

            public override string ToString() //Called on line 156 in SlidingTabScrollView
            {
                return "Emergency Info";
            }
        }

        public class Fragment5 : Android.Support.V4.App.Fragment
        {
            private Button btnWebsite;
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                 var view = inflater.Inflate(Resource.Layout.Fragment_AboutUs, container, false);
                var web = view.FindViewById<WebView>(Resource.Id.webView1);
                web.SetWebViewClient(new ExtendWebViewClient());
                web.LoadUrl("http://www.vgsurvey.we.bs");

                WebSettings webSetting = web.Settings;
                webSetting.JavaScriptEnabled = true;
                return view;
            }

            public override string ToString() //Called on line 156 in SlidingTabScrollView
            {
                return "About Us";
            }
        }


        internal class ExtendWebViewClient : WebViewClient
        {
            public override bool ShouldOverrideUrlLoading(WebView view, string url)
            {
                view.LoadUrl(url);
                return true;
            }
        }

        public class MyEventArgs : EventArgs
        {
            public int Id { get; set; }
        }




    }
}
