using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Collections;

namespace Data_Access_Layer
{
    public class DataHandler
    {
        #region Fields
        private static DBConnection db;
        private static DBConn dbc;
        private static DataSet ds;
        private List<object> sender;
        private static string[] index;
        private static SqlParameter[] param;
        #endregion
        #region Constructor
        public DataHandler()
        {
            db = new DBConnection();
            dbc = new DBConn();
            sender = new List<object>();
            ds = new DataSet();


        }
        #endregion

        #region Method
        public List<object> GetData(string table, string[] columns)
        {
            int i = 0;
            string _query = "SELECT ";
            try
            {
                while (i < columns.Length)
                {
                    if (i > 0) _query += ", ";
                    _query += columns[i++];
                }
                _query += " FROM " + table;
                ds = db.ReadOnly(_query);
                foreach (DataRow item in ds.Tables[table].Rows) { sender.Add(item); }
            }
            catch (SqlException e) { throw new Exception(e.Message); }

            return sender;
        }

        public static bool CreateEntity(Dictionary<string, object> create, string[] columns, string table)
        {
            bool inserted = false;
            try
            {
                string _query = "INSERT INTO " + table + " (";
                string _query2 = " VALUES(";
                param = new SqlParameter[create.Count];
                int i = 0;
                foreach (var item in create)
                {
                    if (i > 1 && i < columns.Length) { _query += ", "; _query2 += ", "; }
                    if (i < columns.Length)
                    {
                        _query += item.Key; _query2 += "@" + item.Key;

                        param[i] = new SqlParameter("@" + item.Key, item.Value);
                    }
                    _query += ")" + _query2 + ")";

                    if (db.Create(_query, param))
                    {
                        inserted = true;
                    }

                }
            }
            catch (SqlException e) { throw new Exception(e.Message); }
            return inserted;
        }
        public static bool ChangeEntity(Dictionary<string, object> values, string[] columns, string table)
        {
            bool updated = false;

            try

            {
                int i = 0, j = 1;
                string _query = "UPDATE " + table + " SET ";

                param = new SqlParameter[values.Count];
                foreach (var item in values)
                {
                    if (j > 1 && j < columns.Length) _query += ", ";
                    if (j < columns.Length) _query += columns[j] + " = @" + columns[j++];

                    param[i] = new SqlParameter("@" + item.Key, item.Value);
                }
                _query += " WHERE " + columns[0] + " = @" + columns[0];

                if (db.Change(_query, param))
                {
                    updated = true;
                }

            }
            catch (SqlException e) { throw new Exception(e.Message); }
            return updated;
        }

        public bool Insert(Dictionary<string, object> values, string table)
        {

            bool insert = false;
            try
            {
                DataRow dr = ds.Tables[table].NewRow();
                foreach (var item in values)
                {
                    dr[item.Key] = item.Value;
                }
                ds.Tables[table].Rows.Add(dr);
                insert = true;
            }
            catch (SqlException e) { throw new Exception(e.Message); }
            return insert;
        }
        public int GetRow(DataSet ds, string table, string identifier)
        {
            int index = 0;
            foreach (DataRow dr in ds.Tables[table].Rows)
            {
                if (dr == ds.Tables[table].Rows.Find(identifier))
                {
                    index = (int)ds.Tables[table].Rows.IndexOf(dr);
                }
            }
            return index;
        }
        public bool Update(Dictionary<string, object> values, string table, string identifier)
        {

            bool upd = false;
            try
            {
                foreach (var item in values)
                {
                    ds.Tables[table].Rows[GetRow(ds, table, identifier)][item.Key] = item.Value;

                }
                dbc.Write(ds, table);
                upd = true;
            }
            catch (SqlException e) { throw new Exception(e.Message); }
            return upd;
        }
        public bool Delete(string table, string identifier)
        {
            bool del = false;
            try
            {
                ds.Tables[table].Rows[GetRow(ds, table, identifier)].Delete();
                dbc.Write(ds, table);
                del = true;
            }
            catch (SqlException e) { throw new Exception(e.Message); }
            return del;
        }
        #endregion

    }
}
