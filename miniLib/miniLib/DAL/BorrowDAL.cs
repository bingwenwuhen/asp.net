using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using miniLib.Model;
using miniLib.DAL;
using System.Data.SqlClient;
using System.Text;

namespace miniLib.DAL
{
    partial class BorrowDAL
    {
        public int Add(Borrow Model) {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("insert into [Borrow](UserId,BookName,BookCase,BookId,BorrowTime,ReturnTime,Status,ReNewTime) ");
            sbStr.Append(" output inserted.Id ");
            sbStr.Append("values(@UserId,@BookId,@BorrowTime,@ReturnTime,@Status,@ReNewTime,@BookName,@BookCase )");
            SqlParameter[] paras = {    new SqlParameter("UserId",Model.UserId), 
                                        new SqlParameter("BookId",Model.BookId), 
                                        new SqlParameter("BorrowTime",Model.BorrowTime), 
                                        new SqlParameter("ReturnTime",Model.ReturnTime), 
                                        new SqlParameter("Status",Model.Status), 
                                        new SqlParameter("ReNewTime",Model.ReNewTime),
                                        new SqlParameter("BookName",Model.BookName),
                                        new SqlParameter("BookCase",Model.BookCase)
                                   };
            int newId = (int)SqlHelper.ExcuteScalar(sbStr.ToString(),paras);
            return newId;
        }

        public int Delete(int id) {
            string sql = "delete Borrow where Id=@Id";
            SqlParameter[] paras = { new SqlParameter("Id",id)};
            return SqlHelper.ExcuteNonQuery(sql,paras);
        }

        public int Update(Borrow model) {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("update Borrow set ");
            sbStr.Append("UserId=@UserId, ");
            sbStr.Append("BookId=@BookId,");
            sbStr.Append("BorrowTime=@BorrowTime,");
            sbStr.Append("ReturnTime=@ReturnTime,");
            sbStr.Append("Status=@Status, ");
            sbStr.Append("RenewTime=@RenewTime, ");
            sbStr.Append("BookName=@BookName, ");
            sbStr.Append("BookCase=@BookCase");
            SqlParameter[] paras = { new SqlParameter("UserId",model.UserId),
                                     new SqlParameter("BookId",model.BookId),
                                     new SqlParameter("BorrowTime",model.BorrowTime),
                                     new SqlParameter("ReturnTime",model.ReturnTime),
                                     new SqlParameter("Status",model.Status),
                                     new SqlParameter("RenewTime",model.ReNewTime),
                                     new SqlParameter("BookName",model.BookName),
                                     new SqlParameter("BookCase",model.BookCase)
                                   };
            return SqlHelper.ExcuteNonQuery(sbStr.ToString(),paras);
        }

        public Borrow GetById(int id) {
            string sql = "select * from Borrow where Id=@Id";
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
            string sql = "select count(*)  from Borrow";
            return (int)SqlHelper.ExcuteScalar(sql);
        }


        public IEnumerable<Borrow> GetAll() {
            var list = new List<Borrow>();
            string sql = "select * from Borrow";
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql)) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public Borrow ToModel(SqlDataReader reader) {
            Borrow model = new Borrow();
            model.UserId = (int)ToModelValue(reader,"UserId");
            model.BookId = (int)ToModelValue(reader,"BookId");
            model.BorrowTime =Convert.ToDateTime( ToModelValue(reader,"BorrowTime"));
            model.ReturnTime = Convert.ToDateTime(ToModelValue(reader,"ReturnTime"));
            model.ReNewTime = (int)ToModelValue(reader,"ReNewTime");
            model.BookCase = (string)ToModelValue(reader,"BookCase");
            model.BookName = (string)ToModelValue(reader,"BookName");
            model.Status = (string)ToModelValue(reader,"Status");
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