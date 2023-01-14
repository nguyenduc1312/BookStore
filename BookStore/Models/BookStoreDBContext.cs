using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BookStore.Models
{
    public class BookStoreDBContext
    {
        string conString = System.Configuration.ConfigurationManager.
                               ConnectionStrings["BookStoreDBContext"].ConnectionString;
        SqlConnection conn;
        SqlTransaction sqlTrans;
        public async Task<DataSet> ExecuteQuery(string queryStr)
        {
            conn = new SqlConnection(conString);

            SqlCommand cmd = new SqlCommand(queryStr, conn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet returnData = new DataSet();
            adapter.Fill(returnData);
            conn.Close();

            return returnData;
        }

        /// <summary>
        /// thực thi câu lệnh nonQuery, biến truyền vào là 1 câu lệnh sql, dictoinary, key (tên biến có @ ở đầu), value (giá trị)
        /// </summary>
        public async void ExecuteNonQuery(string cmdString, Dictionary<string, string> param)
        {
            conn = new SqlConnection(conString);

            SqlCommand cmd = new SqlCommand(cmdString, conn);
            cmd.CommandType = CommandType.Text;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            foreach (var p in param)
            {
                cmd.Parameters.AddWithValue(p.Key, p.Value);
            }
            cmd.ExecuteNonQuery();
        }

        public async void ExecuteSPNonQuery(string spName, Dictionary<string, string> param)
        {
            conn = new SqlConnection(conString);

            SqlCommand cmd = new SqlCommand(spName, conn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (var p in param)
            {
                cmd.Parameters.AddWithValue(p.Key, p.Value);
            }
            cmd.ExecuteNonQuery();
        }

        public async Task<DataSet> ExecuteSPQuery(string spName, Dictionary<string, string> param)
        {
            conn = new SqlConnection(conString);

            SqlCommand cmd = new SqlCommand(spName, conn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (var p in param)
            {
                cmd.Parameters.AddWithValue(p.Key, p.Value);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet returnData = new DataSet();
            adapter.Fill(returnData);
            conn.Close();

            return returnData;
        }

        public async Task<string> BeginTransactionAsync()
        {
            conn = new SqlConnection(conString);
            await conn.OpenAsync();

            sqlTrans = conn.BeginTransaction();

            return "";
        }

        public void TransactionCommitAsync()
        {
            try
            {
                sqlTrans.Commit();
            }
            catch { }
        }

        public void TransactionRollbackAsync()
        {
            try
            {
                if (sqlTrans != null)
                {
                    sqlTrans.Rollback();
                }
            }
            catch { }
        }

        public void CloseTransaction()
        {
            try
            {
                if (sqlTrans != null)
                {
                    sqlTrans.Dispose();
                    sqlTrans = null;
                }
            }
            catch { }

            try
            {

                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();

                    conn = null;
                }
            }
            catch { }
        }
    }
}