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

namespace SADSUI.Resources.Modell
{

   public class Users
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ContactNo { get; set; }
        public string VModel { get; set; }
        public string RegNo { get; set; }
        public string Key { get; set; }

        public Users(int id, string name, string surname, string contactNo, string vModel, string regNo,string key)
        {
            this.ID = id;
            this.Name = name;
            this.Surname = surname;
            this.ContactNo = contactNo;
            this.VModel = vModel;
            this.RegNo = regNo;
            this.Key = key;
        }
    }
}