using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using miniLib.Model;
using System.Data.SqlClient;

namespace miniLib.DAL
{
    partial class BookDAL
    {
        /// <summary>
        /// 通过ISBN来获得Book实体
        /// </summary>
        /// <param name="ISBN">ISBN号</param>
        /// <returns></returns>
        public IEnumerable<Book> GetByISBN(string ISBN) {
            string sql = "select * from Book where ISBN=@ISBN";
            var list = new List<Book>();
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql, new SqlParameter("ISBN", ISBN))) {
                if (reader.Read()) {
                   list.Add( ToModel(reader));
                }
            }
            return list ;
        }

        public Book GetModelByISBN(string ISBN) {
            string sql = "select * from Book where ISBN=@ISBN;";
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql, new SqlParameter("ISBN", ISBN))) {
                if (reader.Read())
                {
                    return ToModel(reader);
                }
                else {
                    return null;
                }
            }
        }

        public IEnumerable<Book> GetAllBookSort() {
            string sql = "select * from book order by Borrownum desc;";
            var list = new List<Book>();
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql)) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public IEnumerable<Book> GetByBookId(int id)
        {
            string sql = "select * from Book where Id=@Id";
            var list = new List<Book>();
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql, new SqlParameter("Id", id)))
            {
                while (reader.Read())
                {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public IEnumerable<Book> GetByBookName(string BookName) {
            string sql = "select * from Book where BookName=@BookName;";
            var list = new List<Book>();
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql, new SqlParameter("BookName", BookName))) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public IEnumerable<Book> GetByBookType(string type) {
            string sql = "select * from Book where Type=@Type;";
            var list = new List<Book>();
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql, new SqlParameter("Type", type))) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public IEnumerable<Book> GetByBookAuthor(string author) {
            string sql = "select * from Book where Author=@Author;";
            var list = new List<Book>();
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql, new SqlParameter("Author", author))) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public IEnumerable<Book> GetBookByPubName(string PubName) {
            string sql = "select * from Book where PubName=@PubName;";
            var list=new List<Book>();
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql, new SqlParameter("PubName", PubName))) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public IEnumerable<Book> GetBookByBookCase(string BookCase) {
            string sql = "select * from Book where BookCase=@BookCase;";
            var list = new List<Book>();
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql, new SqlParameter("BookCase", BookCase))) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }
    }
}