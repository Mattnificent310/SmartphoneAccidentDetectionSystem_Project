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
using SQLite;
using Android.Util;
using SADSUI.Resources.Modell;

namespace SADSUI.Resources.DataHelper
{
    public class DataBase
    {
        public int ID;
        public String keyvalue;

        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool createDataBase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "KeysDatabase.db")))
                {
                    connection.CreateTable<Keys>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool createDataBaseUsers()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Users.db")))
                {
                    connection.CreateTable<Users>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool InsertKey(Keys keys)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "KeysDatabase.db")))
                {
                    connection.Insert(keys);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool InsertUser(Users users)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Users.db")))
                {
                    connection.Insert(users);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool UpdateKey(Keys keys)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "KeysDatabase.db")))
                {
                    connection.Query<Keys>("UPDATE Keys set KeysValue=? WHERE ID=?",keys.KeyValue,keys.ID);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool UpdateUsers(Users users)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Users.db")))
                {
                    connection.Query<Keys>("UPDATE Users set Name=? WHERE ID=?", users.Name, users.ID);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public List<Keys> Select()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "KeysDatabase.db")))
                {
                    return connection.Table<Keys>().ToList();                   
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public bool SelectQuery(int ID)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "KeysDatabase.db")))
                {
                     connection.Query<Keys>("SELECT * FROM Keys Where ID=?",ID);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
    }
}