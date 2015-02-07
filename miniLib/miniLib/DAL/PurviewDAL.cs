using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;
using miniLib.Model;

namespace miniLib.DAL
{
    partial class PurviewDAL
    {
        public int Add(Purview model) {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("insert into [Purview](Id,SysSet,ReadSet,BookSet,BookBack,SysQuery,LoginName) ");
            sbStr.Append("output inserted.Id ");
            sbStr.Append("values(@Id,@SysSet,@ReadSet,@BookSet,@BookBack,@SysQuery,@LoginName);");
            SqlParameter[] paras = { 
                                        new SqlParameter("Id",model.Id),
                                        new SqlParameter("SysSet",model.SysSet),
                                        new SqlParameter("ReadSet",model.ReadSet),
                                        new SqlParameter("BookSet",model.BookSet),
                                        new SqlParameter("BookBack",model.BorrowBack),
                                        new SqlParameter("SysQuery",model.SysQuery),
                                        new SqlParameter("LoginName",model.LoginName)
                                   };
            return (int)SqlHelper.ExcuteScalar(sbStr.ToString(),paras);
        }

        public int Delete(int id) {
            string sql = "delete Purview where Id=@Id;";
            SqlParameter[] paras = { 
                                        new SqlParameter("Id",id)
                                   };
            return SqlHelper.ExcuteNonQuery(sql,paras);
        }

        public int Update(Purview model) {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("update Purview set ");
            sbStr.Append("SysSet=@SysSet,");
            sbStr.Append("ReadSet=@ReadSet,");
            sbStr.Append("BookSet=@BookSet,");
            sbStr.Append("BorrowBack=@BorrowBack,");
            sbStr.Append("SysQuery=@SysQuery,");
            sbStr.Append("LoginName=@LoginName ");
            sbStr.Append("where Id=@Id;");
            SqlParameter[] paras = { 
                                        new SqlParameter("Id",model.Id),
                                        new SqlParameter("SysSet",model.SysSet),
                                        new SqlParameter("ReadSet",model.ReadSet),
                                        new SqlParameter("BookSet",model.BookSet),
                                        new SqlParameter("BorrowBack",model.BorrowBack),
                                        new SqlParameter("SysQuery",model.SysQuery),
                                        new SqlParameter("LoginName",model.LoginName)
                                   };
            return SqlHelper.ExcuteNonQuery(sbStr.ToString(),paras);
        }

        public Purview GetById(int id) {
            string sql = "select * from Purview where Id=@Id;";
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

        public IEnumerable<Purview> GetAll() {
            string sql = "select * from Purview;";
            var list = new List<Purview>();
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql)) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public Purview ToModel(SqlDataReader reader) {
            Purview model = new Purview();
            model.Id = (int)ToModelValue(reader,"Id");
            model.SysSet = (bool)ToModelValue(reader,"SysSet");
            model.ReadSet = (bool)ToModelValue(reader,"ReadSet");
            model.BookSet = (bool)ToModelValue(reader,"BookSet");
            model.BorrowBack = (bool)ToModelValue(reader,"BorrowBack");
            model.SysQuery = (bool)ToModelValue(reader,"SysQuery");
            model.LoginName = (string)ToModelValue(reader,"LoginName");
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