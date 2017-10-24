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
using MySql.Data.MySqlClient;
using System.Data;

namespace SADSUI
{
    [Activity(Label = "Profile")]
    public class Website : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Website);

            var btnCancel = FindViewById<Button>(Resource.Id.btnCancel);
            var btnSave = FindViewById<Button>(Resource.Id.btnSaveEditProfile);

            btnCancel.Click += btnCancel_Click;
            btnSave.Click += btnSave_Click;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=db4free.net;Port=3306,database=sadsdb1;User Id=louisdev1; Password=Louis1;charset=utf8");

            try
            {
               
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                ex.ToString(); 
            }
            finally
            {
                con.Close();
            }

           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var activity2 = new Intent(this, typeof(Home));
            StartActivity(activity2);
        }
    }

}