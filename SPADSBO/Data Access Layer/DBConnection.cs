using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    class DBConnection
    {

        #region Fields
        private static SqlDataAdapter adapter;
        private static SqlConnection conn;
        private static SqlCommand cmd;
        private static DataSet ds;
        private string connStr;
        public static List<string> errors;

        #endregion
        #region Constructor
        public DBConnection()
        {
            adapter = new SqlDataAdapter();
            connStr = @"Data Source=MSI;Initial Catalog=Diary;Integrated Security=True";
            conn = new SqlConnection(connStr);
            cmd = new SqlCommand();
            ds = new DataSet();
            errors = null;

        }
        #endregion

        #region Method
        public static SqlConnection Disconnect()
        {
            try
            {
                if (conn.State == ConnectionState.Open || conn.State != ConnectionState.Fetching || conn.State != ConnectionState.Executing || conn.State != ConnectionState.Broken)
                {
                    conn.Dispose();
                    conn.Close();
                }
            }
            catch (SqlException e) { errors.Add(e.Message); }
            return conn;
        }
        public static SqlConnection Connect()
        {
            try
            {
                if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                {

                    conn.Open();
                }
            }
            catch (SqlException e) { throw new Exception(e.Message); }
            return conn;
        }

        public DataSet ReadOnly(string _query)
        {
            try
            {
                cmd.Connection = Connect();
                cmd.CommandText = _query;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
            }
            catch (SqlException ex) { errors.Add(ex.Message); }
            return ds;
        }

        public bool Create(string _query, SqlParameter[] param)
        {
            bool inserted = false;
            try
            {
                cmd.Connection = Connect();
                cmd.CommandText = _query;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddRange(param);

                adapter.InsertCommand = cmd;
                cmd.ExecuteNonQuery();
                inserted = true;
            }
            catch (SqlException ex) { throw new Exception(ex.Message); }
            return inserted;
        }
        public bool Change(string _query, SqlParameter[] param)
        {
            bool updated = false;
            try
            {
                cmd.Connection = Connect();
                cmd.CommandText = _query;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddRange(param);

                adapter.UpdateCommand = cmd;
                cmd.ExecuteNonQuery();
                updated = true;
            }
            catch (SqlException e) { throw new Exception(e.Message); }
            return updated;
        }
        #endregion
    }
}
