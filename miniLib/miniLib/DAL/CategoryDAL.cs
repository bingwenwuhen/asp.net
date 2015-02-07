using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using miniLib.Model;

namespace miniLib.DAL
{
    public class CategoryDAL
    {
        public int Add(Category model) {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("insert into [Category](Id,Name) ");
            sbStr.Append("output inserted.Id ");
            sbStr.Append("values(@Id,@Name);");
            SqlParameter[] paras = { 
                                        new SqlParameter("Id",model.Id),
                                        new SqlParameter("Name",model.Name)
                                   };
            return (int)SqlHelper.ExcuteScalar(sbStr.ToString(),paras);
        }

        public int Delete(int id) {
            string sql = "delete Category where Id=@Id;";
            SqlParameter[] paras = { 
                                        new SqlParameter("Id",id)
                                   };
            return SqlHelper.ExcuteNonQuery(sql,paras);
        }

        public int Update(Category model) {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("update Category set ");
            sbStr.Append("Name=@Name ");
            sbStr.Append("where Id=@Id;");
            SqlParameter[] paras = { 
                                        new SqlParameter("Id",model.Id),
                                        new SqlParameter("Name",model.Name)
                                   };
            return SqlHelper.ExcuteNonQuery(sbStr.ToString(),paras);
        }

        public Category GetById(int id) {
            string sql = "select * from Category where Id=@Id;";
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

        public IEnumerable<Category> GetAll() {
            string sql = "select * from Category;";
            var list=new List<Category>();
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql)) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public int GetTotalCount() {
            string sql = "select count(*) from Category;";
            return SqlHelper.ExcuteNonQuery(sql);
        }

        public Category ToModel(SqlDataReader reader) {
            Category model = new Category();
            model.Id = (int)ToModelValue(reader,"Id");
            model.Name = (string)ToModelValue(reader,"Name");
            return model;
        }

        public object ToModelValue(SqlDataReader reader, string ColumnName) {
            if (reader.IsDBNull(reader.GetOrdinal(ColumnName)))
            {
                return null;
            }
            else { 
            return reader[ColumnName];
            }
        }
    }
}