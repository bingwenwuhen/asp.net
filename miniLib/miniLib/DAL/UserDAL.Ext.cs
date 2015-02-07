using miniLib.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace miniLib.DAL
{
	partial class UserDAL
	{
        public User GetByLoginName(string LoginName) {
            string sql = "select * from [User] where LoginName=@LoginName";
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql, new SqlParameter("LoginName", LoginName))) {
                if (reader.Read())
                {
                    return ToModel(reader);
                }
                else {
                    return null;
                }
            }
        }

        public int GetMaxId() {
            string sql = "select max(Id) from [User];";
            return SqlHelper.ExcuteNonQuery(sql);
        }

        public IEnumerable<User> GetAdmin() {
            string sql = "select * from User where UserRoleId=1;";
            var list = new List<User>();
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql)) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public int DeleteByName(string LoginName) {
            string sql = "delete from User where LoginName=@LoginName;";
            SqlParameter[] paras = { 
                                        new SqlParameter("LoginName",LoginName)
                                   };
            return SqlHelper.ExcuteNonQuery(sql,paras);
        }

        public IEnumerable<User> GetUserSort() {
            string sql = "select * from [User] order by BorrowSum desc;";
            var list=new List<User>();
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql)) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }
	}
}