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
    class History
    {
        private int id;
        private string description;
        private string date;
        private string location;
        private string user;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }
        

        public string Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;
            }
        }

        public string User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        public History()
        {

        }
        public History(int id
        ,string type
        ,string date
        ,string location,
         string user 
            )
        {
            this.Id = id;
            this.Description = type;
            this.Date = date;
            this.Location = location;
            this.User = user;
        }
    }
}