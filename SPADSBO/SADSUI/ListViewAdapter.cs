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
using Java.Lang;
using SADSUI.Resources.Modell;

namespace SADSUI.Resources
{
    public class ViewHolder:Java.Lang.Object
    {
        public TextView txtKeyValue { get; set; }
    }

    class ListViewAdapter:BaseAdapter
    {
        private Activity activity;
        private List<Keys> lstkeys;
       public ListViewAdapter(Activity activity, List<Keys> lstKeys)
        {
            this.activity = activity;
            this.lstkeys = lstKeys;
        }

        public override int Count
        {
            get
            {
                return lstkeys.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return lstkeys[position].ID;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.list_view_dataTemplate, parent, false);
            return view;
        }
    }
}