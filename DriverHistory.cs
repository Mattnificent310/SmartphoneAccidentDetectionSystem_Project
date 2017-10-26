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
using SADSUI.Resources.DataHandler;
namespace SADSUI
{
    [Activity(Label = "DriverHistory")]
    public class DriverHistory : Activity
    {
        DataHandler_MySQL dh;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            dh = new DataHandler_MySQL();
            SetContentView(Resource.Layout.DriveHistory);

            var btnCancel = FindViewById<Button>(Resource.Id.btnHistoryBack);
            MySqlConnection con = new MySqlConnection("Server=sql2.freemysqlhosting.net;Port=3306;database=sql2201049;User Id=sql2201049; Password=xZ3!sH3%;charset=utf8");

            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    List<string> hList = new List<string>();
                        foreach(History item in dh.showHistory())
                    {
                        hList.Add(string.Format("Description: {0}\nDate: {1}\nLocation: {2}\nUser: {3}",
                            item.Description,item.Date,item.Location,item.User));
                    }
                    ListView lv = new ListView(this);
                    


                    HistoryAdapter adapters = new HistoryAdapter(this, dh.showHistory());
                    ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem2, hList);

                    lv.Adapter = adapter;
                    lv.ItemClick += (s, e) =>
                    {
                        Toast.MakeText(this, "Calling", ToastLength.Short).Show();
                    };
                    var activity2 = new Intent(this, typeof(Home));
                    StartActivity(activity2);
                }
            }catch(Exception e) { }
            btnCancel.Click += btnCancel_Click;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var activity2 = new Intent(this, typeof(Home));
            StartActivity(activity2);
        }

        class HistoryAdapter : BaseAdapter<History>

        {

            private List<History> hList;
            private Context sContext;
            public HistoryAdapter()
            {
               
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
}