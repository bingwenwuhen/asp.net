using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;
using miniLib.Model;
using miniLib.DAL;

namespace miniLib.DAL
{
    partial class PurviewDAL
    {
        public int DeleteByLoginName(string LoginName) {
            string sql = "delete Purview where LoginName=@LoginName;";
            SqlParameter[] paras = { 
                                        new SqlParameter("LoginName",LoginName)
                                   };
            return SqlHelper.ExcuteNonQuery(sql,paras);
        }

        public Purview GetByLoginName(string LoginName) {
            string sql = "select * from Purview where LoginName=@LoginName;";
            SqlParameter[] paras = { 
                                        new SqlParameter("LoginName",LoginName)
                                   };
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql, paras)) {
                return ToModel(reader);
            }
        }
    }
}