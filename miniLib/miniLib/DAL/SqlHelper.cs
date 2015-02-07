using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Configuration;
namespace miniLib.DAL
{
    public class SqlHelper
    {
        private static readonly string Connstr = ConfigurationManager.ConnectionStrings["Connstr"].ConnectionString;

        public static int ExcuteNonQuery(string cmdText, params SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(Connstr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = cmdText;
                    cmd.Parameters.AddRange(paras);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExcuteScalar(string cmdText, params SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(Connstr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = cmdText;
                    cmd.Parameters.AddRange(paras);
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static DataTable ExcuteDataTable(string cmdText, params SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(Connstr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = cmdText;
                    cmd.Parameters.AddRange(paras);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public static SqlDataReader ExcuteDataReader(string cmdText, params SqlParameter[] paras) {
            SqlConnection conn = new SqlConnection(Connstr);
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand()) {
                    cmd.CommandText = cmdText;
                    cmd.Parameters.AddRange(paras);
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
        }

        public static int ExcuteStoredProcedure(string cmdText, params SqlParameter[] paras) {
            using (SqlConnection conn = new SqlConnection(Connstr)) {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand()) {
                    cmd.CommandText = cmdText;
                    cmd.Parameters.AddRange(paras);
                    cmd.CommandType = CommandType.StoredProcedure;
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}