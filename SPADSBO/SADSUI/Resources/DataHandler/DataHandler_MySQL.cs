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
using MySql.Data.MySqlClient;
using System.Data;
using SADSUI.Resources.Modell;

namespace SADSUI.Resources.DataHandler
{
    class DataHandler_MySQL
    {
        public List<Users> users = new List<Users>();

        public void updateUser(string contactno,string vmodel,string regno)
        {
            MySqlConnection con = new MySqlConnection("Server=sql2.freemysqlhosting.net;Port=3306;database=sql2201049;User Id=sql2201049; Password=xZ3!sH3%;charset=utf8");

            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE tblUsers SET User_ContactNo = '"+contactno +"', User_VehicleModel = '"+vmodel+"',User_RegNo = '"+regno+"' WHERE 1", con);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
        }

        public List<Users> getUsers()
        {
            MySqlConnection con = new MySqlConnection("Server=sql2.freemysqlhosting.net;Port=3306;database=sql2201049;User Id=sql2201049; Password=xZ3!sH3%;charset=utf8");

            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblUsers",con);
                    MySqlDataReader data_reader = cmd.ExecuteReader();
                    
                    while (data_reader.Read())
                    {
                        int id = int.Parse((data_reader.GetValue(0).ToString()));
                        string name = data_reader.GetValue(1).ToString();
                        string surname = data_reader.GetValue(2).ToString();
                        string contact = data_reader.GetValue(3).ToString();
                        string model = data_reader.GetValue(4).ToString();
                        string reg = data_reader.GetValue(5).ToString();
                        string key = data_reader.GetValue(6).ToString();

                        users.Add(new Users(id,name, surname,contact,model,reg,key));
                    }
                   
                    return users;
                }
            }
            catch (MySqlException ex)
            {
               
            }
            finally
            {
                con.Close();
            }

            return users;
        }
    }
}