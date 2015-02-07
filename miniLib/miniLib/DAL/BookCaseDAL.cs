using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using miniLib.Model;
using System.Data.SqlClient;
using System.Text;

namespace miniLib.DAL
{
    public class BookCaseDAL
    {
        public int Add(BookCase model) {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("insert into [BookCase](BookCaseId,Name) ");
            sbStr.Append(" output insert.Id ");
            sbStr.Append("values(@BookCaseId,@Name);");
            SqlParameter[] paras = { 
                                        new SqlParameter("BookCaseId",model.BookCaseId),
                                        new SqlParameter("Name",model.Name)
                                   };
            int newId = (int)SqlHelper.ExcuteScalar(sbStr.ToString(),paras);
            return newId;
        }

        public int Delete(string id) {
            string sql = "delete BookCase where BookCaseId=@BookCaseId;";
            SqlParameter[] paras = { 
                                        new SqlParameter("BookCaseId",id)
                                   };
            return SqlHelper.ExcuteNonQuery(sql,paras);
        }

        public int Update(BookCase model) {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("update BookCase set ");
            sbStr.Append("Name=@Name ");
            sbStr.Append("where BookCaseId=@BookCaseId;");
            SqlParameter[] paras = { 
                                        new SqlParameter("Name",model.Name),
                                        new SqlParameter("BookCaseId",model.BookCaseId)
                                   };
            return SqlHelper.ExcuteNonQuery(sbStr.ToString(),paras);
        }

        public BookCase GetById(string id) {
            string sql = "select * from BookCase where BookCaseId=@BookCaseId;";
            SqlParameter[] paras = { 
                                        new SqlParameter("BookCaseId",id)
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

        public int TotalCount() {
            string sql = "select count(*) from BookCase;";
            return (int)SqlHelper.ExcuteScalar(sql);
        }

        public IEnumerable<BookCase> GetAll() {
            var list = new List<BookCase>();
            string sql = "select * from BookCase;";
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql)) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public BookCase ToModel(SqlDataReader reader) {
            BookCase model = new BookCase();
            model.BookCaseId = (string)ToModelValue(reader,"BookCaseId");
            model.Name = (string)ToModelValue(reader,"Name");
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