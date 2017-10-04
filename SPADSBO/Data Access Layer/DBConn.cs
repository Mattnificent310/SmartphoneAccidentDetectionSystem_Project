using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    class DBConn
    {
        private static SqlDataAdapter adapter;
        private static SqlConnection conn;
        private static SqlCommandBuilder cmd;
        private static DataSet ds;
        private string connStr;

        public DBConn()
        {
            connStr = @"Data Source=MSI;Initial Catalog=Diary;Integrated Security=True";
            ds = new DataSet();

            //adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

        }
        public DataSet Read(string _table)
        {
            using (conn = new SqlConnection(connStr))
            {
                using (adapter = new SqlDataAdapter("SELECT * FROM " + _table, conn))
                {
                    using (cmd = new SqlCommandBuilder(adapter))
                    {
                        adapter.Fill(ds, _table);

                    }
                }

            }
            return ds;
        }
        public bool Write(DataSet updDS, string _table)
        {
            bool saved = false;
            using (conn = new SqlConnection(connStr))
            {
                using (adapter = new SqlDataAdapter("SELECT * FROM " + _table, conn))
                {
                    using (cmd = new SqlCommandBuilder(adapter))
                    {
                        adapter.Update(ds, _table);
                        saved = true;
                    }
                }

            }
            return saved;
        }

    }
}
