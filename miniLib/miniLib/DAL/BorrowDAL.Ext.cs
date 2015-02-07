using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using miniLib.Model;
using System.Data.SqlClient;

namespace miniLib.DAL
{
    partial class BorrowDAL
    {
        public IEnumerable<Borrow> GetAllByBookCode(int BookId) {
            string sql = "select * from Borrow where BookId=@BookId;";
            var list = new List<Borrow>();
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql, new SqlParameter("BookId", BookId))) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public IEnumerable<Borrow> GetByBookName(string BookName) {
            string sql = "select * from Borrow where BookName=@BookName;";
            var list = new List<Borrow>();
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql, new SqlParameter("BookName", BookName))) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public IEnumerable<Borrow> GetByUserId(int UserId) {
            string sql = "select * from Borrow where UserId=@UserId;";
            var list = new List<Borrow>();
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql, new SqlParameter("UserId", UserId))) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public IEnumerable<Borrow> GetByBorrowTime(DateTime BorrowTime) {
            string sql = "select * from Borrow where BorrowTime=@BorrowTime;";
            var list = new List<Borrow>();
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql, new SqlParameter("BorrowTime", BorrowTime))) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public IEnumerable<Borrow> GetByReturnTime(DateTime ReturnTime) {
            string sql = "select * from Borrow where ReturnTime=@ReturnTime;";
            var list = new List<Borrow>();
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql, new SqlParameter("ReturnTime", ReturnTime))) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public IEnumerable<Borrow> GetByBorrowTimeAndReturnTime(DateTime BorrowTime, DateTime ReturnTime) {
            string sql = "select * from Borrow where BorrowTime=@BorrowTime and ReturnTime=@ReturnTime;";
            SqlParameter[] paras = { 
                                        new SqlParameter("BorrowTime",BorrowTime),
                                        new SqlParameter("ReturnTime",ReturnTime)
                                   };
            var list=new List<Borrow>();
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql, paras)) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public IEnumerable<Borrow> GetByBorrowStatus(int UserId) {
            string sql = "select * from Borrow where Status='未归还' and UserId=@UserId;";
            var list = new List<Borrow>();
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql, new SqlParameter("UserId", UserId))) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }
    }
}