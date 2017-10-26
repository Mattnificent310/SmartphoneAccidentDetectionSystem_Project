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

namespace SADSUI.Resources.DataHandler
{
    class HistoryAdapter : BaseAdapter<History>
        
    {
          
    private List<History> hList;  
    private Context sContext;
        public HistoryAdapter()
        {
            HList = new List<History>();
        }
   public HistoryAdapter(Context context, List<History> list)
            {
                this.HList = list;
                this.SContext = context;
            }  
   public override History this[int position]
            {  
        get
                {
                               return HList[position];
                            }  
    }  
   public override int Count
            {  
        get
                {
                               return HList.Count;
                            }  
   }

        public Context SContext
        {
            get
            {
                return sContext;
            }

            set
            {
                sContext = value;
            }
        }

        internal List<History> HList
        {
            get
            {
                return hList;
            }

            set
            {
                hList = value;
            }
        }

        public override long GetItemId(int position)
            {
                      return position;
                    }  
    public override View GetView(int position, View convertView, ViewGroup parent)
            {
                View row = convertView;
                        try
                {
                               if (row == null)
                    {
                        row = LayoutInflater.From(SContext).Inflate(Resource.Layout.Main, null, false);
                                    }
                    TextView txtName = row.FindViewById<TextView>(Resource.Id.textView1);
                    txtName.Text = HList[position].Description;
                            }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                            }
                finally { }
                       return row;
                   }

        }
    }