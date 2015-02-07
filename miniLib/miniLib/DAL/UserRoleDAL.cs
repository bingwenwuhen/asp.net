using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using miniLib.Model;
using System.Data.SqlClient;
using System.Text;

namespace miniLib.DAL
{
    public class UserRoleDAL
    {
        public int Add(UserRole model) {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("insert into [UserRole](Id,Name,BookNumber) ");
            sbStr.Append("output inserted.Id ");
            sbStr.Append("values(@Id,@Name,@BookNumber);");
            SqlParameter[] paras = { 
                                        new SqlParameter("Id",model.Id),
                                        new SqlParameter("Name",model.Name),
                                        new SqlParameter("BookNumber",model.BookNumber)
                                   };
            int newId = (int)SqlHelper.ExcuteScalar(sbStr.ToString(),paras);
            return newId;
        }

        public int Delete(int id) {
            string sql = "delete UserRole where Id=@Id;";
            SqlParameter[] paras = { 
                                        new SqlParameter("Id",id)
                                   };
            return SqlHelper.ExcuteNonQuery(sql,paras);
        }

        public int Update(UserRole model) {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("update [UserRole] set ");
            sbStr.Append("Name=@Name,");
            sbStr.Append("BookNumber=@BookNumber ");
            sbStr.Append(" where Id=@Id;");
            SqlParameter[] paras = { 
                                        new SqlParameter("Name",model.Name),
                                        new SqlParameter("BookNumber",model.BookNumber),
                                        new SqlParameter("Id",model.Id)
                                   };
            return SqlHelper.ExcuteNonQuery(sbStr.ToString(),paras);
        }

        public UserRole GetById(int id) {
            string sql = "select * from UserRole where Id=@Id;";
            SqlParameter[] paras = { 
                                        new SqlParameter("Id",id)
                                   };
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql, paras)) {
                if (reader.Read())
                {
                    return ToModel(reader);
                }
                else {
                    return null;
                }
            }
        }

        public int GetTotalCount() {
            string sql = "select count(*) from UserRole;";
            return (int)SqlHelper.ExcuteScalar(sql);
        }

        public IEnumerable<UserRole> GetAll() {
            var list = new List<UserRole>();
            string sql = "select * from UserRole;";
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql)) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public UserRole ToModel(SqlDataReader reader) {
            UserRole model = new UserRole();
            model.Id = (int)ToModelValue(reader,"Id");
            model.Name = (string)ToModelValue(reader,"Name");
            model.BookNumber = (int)ToModelValue(reader,"BookNumber");
            return model;
        }

        public object ToModelValue(SqlDataReader reader, string columnName) {
            if (reader.IsDBNull(reader.GetOrdinal(columnName)))
            {
                return null;
            }
            else { 
            return reader[columnName];
            }
        }
    }
}