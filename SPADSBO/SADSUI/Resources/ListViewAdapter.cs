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
using SADSUI.Resources.Model;

namespace SADSUI.Resources
{
    public class ViewHolder:Java.Lang.Object
    {
        public TextView txtKeyValue { get; set; }
    }

    class ListViewAdapter
    {
        private Activity activity;
        private List<Keys> lstkeys;
        public ListViewAdapter()
    }
}