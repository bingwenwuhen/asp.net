using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using miniLib.Model;
using System.Text;
using System.Data.SqlClient;

namespace miniLib.DAL
{
    partial class UserDAL
    {
        public int Add(User model) {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("insert into [User](LoginName,LoginPwd,Address,Phone,Mail,UserRoleId,Gender，CardNumber,CreateDate,BorrowSum ) ");
            sbStr.Append(" output inserted.Id ");
            sbStr.Append("values(@LoginName,@LoginPwd,@Address,@Phone,@Mail,@UserRoleId,@Gender,@CardNumber,@CreateDate,@BorrowSum);");
            SqlParameter[] paras = { 
                                   new SqlParameter("LoginName",model.LoginName),
                                   new SqlParameter("LoginPwd",model.LoginPwd),
                                   new SqlParameter("Address",model.Address),
                                   new SqlParameter("Phone",model.Phone),
                                   new SqlParameter("Mail",model.Mail),
                                   new SqlParameter("UserRoleId",model.UserRoleId),
                                   new SqlParameter("Gender",model.Gender),
                                   new SqlParameter("CardNumber",model.CardNumber),
                                   new SqlParameter("CreateDate",model.CreateDate),
                                   new SqlParameter("BorrowSum",model.BorrowSum)
                                   };
            int newId = (int)SqlHelper.ExcuteScalar(sbStr.ToString(),paras);
            return newId;
        }

        public int DeleteById(int id) {
            string sql = "delete User where Id=@Id";
            SqlParameter[] paras = { 
                                   new SqlParameter("Id",id)
                                   };
            return SqlHelper.ExcuteNonQuery(sql,paras);
        }

        public int Update(User model) {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("update [User] set ");
            sbStr.Append("LoginName=@LoginName, ");
            sbStr.Append("LoginPwd=@LoginPwd, ");
            sbStr.Append("Address=@Address, ");
            sbStr.Append("Phone=@Phone, ");
            sbStr.Append("Mail=@Mail, ");
            sbStr.Append("UserRoleId=@UserRoleId, ");
            sbStr.Append("Gender=@Gender,");
            sbStr.Append("CardNumber=@CardNumber,");
            sbStr.Append("BorrowSum=@BorrowSum,");
            sbStr.Append("CreateDate=@CreateDate ");
            sbStr.Append(" where Id=@Id");
            SqlParameter[] paras = { 
                                   new SqlParameter("LoginName",model.LoginName),
                                   new SqlParameter("LoginPwd",model.LoginPwd),
                                   new SqlParameter("Address",model.Address),
                                   new SqlParameter("Phone",model.Phone),
                                   new SqlParameter("Mail",model.Mail),
                                   new SqlParameter("UserRoleId",model.UserRoleId),
                                   new SqlParameter("Gender",model.Gender),
                                   new SqlParameter("Id",model.Id),
                                   new SqlParameter("CardNumber",model.CardNumber),
                                   new SqlParameter("CreateDate",model.CreateDate),
                                   new SqlParameter("BorrowSum",model.BorrowSum)
                                   };
            return SqlHelper.ExcuteNonQuery(sbStr.ToString(),paras);
        }

        public User GetById(int id) {
            string sql = "select * from [User] where Id=@Id";
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql, new SqlParameter("Id", id))) {
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
            string sql = "select count(*) from User";
            return (int)SqlHelper.ExcuteScalar(sql);
        }

        public IEnumerable<User> GetPageData(int minrownum, int maxrownum) {
            var list = new List<User>();
            string sql = "select * from(select *,row_number() over(order by Id) rownum from User) t where rownum >=@minrownum and rownum<=@maxrownum";
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql, new SqlParameter("minrownum", minrownum),
                                                                      new SqlParameter("maxrownum", maxrownum))) {
                                                                          while (reader.Read()) {
                                                                              list.Add(ToModel(reader));
                                                                          }
            }
            return list;
        }

        public IEnumerable<User> GetAll() {
            var list = new List<User>();
            string sql = "select * from [User]";
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql)) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public User ToModel(SqlDataReader reader) {
            User model = new User();
            model.Id = (int)ToModelValue(reader,"Id");
            model.LoginName = (string)ToModelValue(reader,"LoginName");
            model.LoginPwd = (string)ToModelValue(reader,"LoginPwd");
            model.Address = (string)ToModelValue(reader,"Address");
            model.Phone = (string)ToModelValue(reader,"Phone");
            model.Mail = (string)ToModelValue(reader,"Mail");
            model.UserRoleId = (int)ToModelValue(reader,"UserRoleId");
            model.Gender = (string)ToModelValue(reader,"Gender");
            model.CardNumber = (string)ToModelValue(reader,"CardNumber");
            model.CreateDate = Convert.ToDateTime(ToModelValue(reader,"CreateDate"));
            model.BorrowSum = (int)ToModelValue(reader,"BorrowSum");
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