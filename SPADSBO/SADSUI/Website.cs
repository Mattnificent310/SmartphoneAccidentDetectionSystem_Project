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
using SADSUI.Resources.Modell;
using SADSUI.Resources.DataHandler;

namespace SADSUI
{
    [Activity(Label = "Profile")]
    public class Website : Activity
    {
        Button btnCancel;
        Button btnSave;
        TextView txtStatus;
        TextView txtUserName;
        TextView txtUserSurname;
        EditText txtUserContact;
        EditText txtUserModel;
        EditText txtUserReg;

        List<Users> lstUser;
        DataHandler_MySQL dh;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Website);

            dh = new DataHandler_MySQL();

            lstUser = dh.getUsers();

            txtUserName = FindViewById<TextView>(Resource.Id.txtUserNameEdit);
            txtUserSurname = FindViewById<TextView>(Resource.Id.txtUserSurnameEdit);
            txtUserContact = FindViewById<EditText>(Resource.Id.txtUserContactEdit);
            txtUserModel = FindViewById<EditText>(Resource.Id.txtUserModelEdit);
            txtUserReg = FindViewById<EditText>(Resource.Id.txtUserRegNumber);

            txtUserName.Text = lstUser[0].Name;
            txtUserSurname.Text = lstUser[0].Surname;
            txtUserContact.Text = lstUser[0].ContactNo;
            txtUserModel.Text = lstUser[0].VModel;
            txtUserReg.Text = lstUser[0].RegNo;

            btnCancel = FindViewById<Button>(Resource.Id.btnCancel);
            btnSave = FindViewById<Button>(Resource.Id.btnSaveEditProfile);

            btnCancel.Click += btnCancel_Click;
            btnSave.Click += btnSave_Click;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtStatus = FindViewById<TextView>(Resource.Id.txtDBCon);

            MySqlConnection con = new MySqlConnection("Server=sql2.freemysqlhosting.net;Port=3306;database=sql2201049;User Id=sql2201049; Password=xZ3!sH3%;charset=utf8");

            try
            {
               
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    dh.updateUser(txtUserContact.Text,txtUserModel.Text,txtUserReg.Text);
                    AlertDialog.Builder alertD = new AlertDialog.Builder(this);
                    alertD.SetTitle("Update");
                    alertD.SetMessage("Update Successful");
                    alertD.SetNeutralButton("OK", delegate { alertD.Dispose(); });
                    alertD.Show();
                    var activity2 = new Intent(this, typeof(Home));
                    StartActivity(activity2);
                }
            }
            catch (MySqlException ex)
            {
                txtStatus.Text = ex.ToString();
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