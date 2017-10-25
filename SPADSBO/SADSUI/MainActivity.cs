using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views;
using Android.Support.V4.View;
using System.Collections.Generic;
using Android.Graphics;
using SADSUI.Resources.Modell;
using SADSUI.Resources.DataHandler;
using Android.Webkit;
using System;
using Plugin.Connectivity;

namespace SADSUI
{
    [Activity(Label = "SADSUI")]
    public class MainActivity : Activity
    {
        
        private Button mbtnSignIn;
        private Button btnSupport;
        List<Keys> lstSource = new List<Keys>();
        List<Users> lstUsers = new List<Users>();
        DataHandler_MySQL dh;
        public bool userfound = false;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            ActionBar.Hide();

            if (CrossConnectivity.Current.IsConnected)
            {
                AlertDialog.Builder ad = new AlertDialog.Builder(this);
                ad.SetTitle("Existing Account");
                ad.SetMessage("Do you have a SADS account?");
                ad.SetPositiveButton("Yes, duh this app is awesome", (senderAlert, args) => {
                    ad.Dispose();
                });
                ad.SetNegativeButton("No, please I want one", (senderAlert, args) => {
                    var uri = Android.Net.Uri.Parse("http://www.vgsurvey.we.bs");
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                });
                ad.Show();

                //Create Database
                dh = new DataHandler_MySQL();

                lstUsers = dh.getUsers();

                mbtnSignIn = FindViewById<Button>(Resource.Id.btnSignIn);
                EditText txtKey = FindViewById<EditText>(Resource.Id.txtUniqueKey);
                btnSupport = FindViewById<Button>(Resource.Id.btnSupport);

                btnSupport.Click += (s, e) =>
                {
                    var uri = Android.Net.Uri.Parse("http://www.vgsurvey.we.bs");
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                };

                mbtnSignIn.Click += (s, e) =>
                {
                   

                    if (userfound == false)
                    {
                        foreach (Users item in lstUsers)
                        {
                            if (txtKey.Text == item.Key)
                            {
                                userfound = true;
                                AlertDialog.Builder ad2 = new AlertDialog.Builder(this);
                                ad2.SetTitle("Welcome");
                                ad2.SetMessage("Welcome " + item.Name + " " + item.Surname + ". Please enjoy the SADS App");
                                ad2.SetPositiveButton("Ok", (senderAlert, args) => {
                                    var activity2 = new Intent(this, typeof(Home));
                                    StartActivity(activity2);
                                });
                                ad2.Show();                   
                            }
                           
                            
                        }
                    }

                    checkuserfound(userfound);                            
                                                                           

                };
            }
            else
            {
                AlertDialog.Builder ad2 = new AlertDialog.Builder(this);
                ad2.SetTitle("Internet Connection");
                ad2.SetMessage("Please make sure a stable connection is available");
                ad2.SetPositiveButton("Ok", (senderAlert, args) => {
                    Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
                });
                ad2.Show();
            }
           



        }

        public void checkuserfound(bool found)
        {
            if (found == false)
            {
                AlertDialog.Builder alertD = new AlertDialog.Builder(this);
                alertD.SetTitle("INVALID KEY");
                alertD.SetMessage("Your Key Is Invalid...Please try to varify your key from our website.");
                alertD.SetNeutralButton("OK", delegate { alertD.Dispose(); });
                alertD.Show();
            }
        }

        
        


    }
}

