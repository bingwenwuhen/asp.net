using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using miniLib.Model;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace miniLib.DAL
{
    partial class BookDAL
    {
        public int Add(Book model) {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("insert into [Book](Id,BookName,Type,Author,PubName,Page,BookCase,Borrownum,ContentDescription,TOC,CategoryId,Price,ISBN) ");
            sbStr.Append(" output inserted.Id ");
            sbStr.Append("values(@Id,@BookName,@Type,@Author,@PubName,@Page,@BookCase,@Borrownum,@ContentDescription,@TOC,@CategoryId,@Price,@ISBN)");
            SqlParameter[] paras = { new SqlParameter("Id",model.Id),
                                     new SqlParameter("BookName",model.BookName),
                                     new SqlParameter("Type",model.Type),
                                     new SqlParameter("Author",model.Author),
                                     new SqlParameter("PubName",model.PubName),
                                     new SqlParameter("Page",model.Page),
                                     new SqlParameter("BookCase",model.BookCase),
                                     new SqlParameter("Borrownum",model.Borrownum),
                                     new SqlParameter("ContentDescription",model.ContentDescription),
                                     new SqlParameter("TOC",model.TOC),
                                     new SqlParameter("CategoryId",model.CategoryId),
                                     new SqlParameter("Price",model.Price),
                                     new SqlParameter("ISBN",model.ISBN)
                                   };
            int newId = (int)SqlHelper.ExcuteScalar(sbStr.ToString(),paras);
            return newId;
        }

        public int DeleteById(int id) {
            string sql = "delete Book where Id=@Id";
            SqlParameter[] paras = { new SqlParameter("Id",id)};
            return SqlHelper.ExcuteNonQuery(sql,paras);
        }

        public int Update(Book model) {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("update Book set ");
            sbStr.Append("BookName=@BookName,");
            sbStr.Append("Type=@Type,");
            sbStr.Append("Author=@Author,");
            sbStr.Append("PubName=@PubName,");
            sbStr.Append("Page=@Page,");
            sbStr.Append("BookCase=@BookCase,");
            sbStr.Append("Borrownum=@Borrownum,");
            sbStr.Append("ContentDescription=@ContentDecription,");
            sbStr.Append("TOC=@TOC,");
            sbStr.Append("CategoryId=@CategoryId,");
            sbStr.Append("ISBN=@ISBN,");
            sbStr.Append("Price=@Price");
            SqlParameter[] paras = { 
                                     new SqlParameter("BookName",model.BookName),
                                     new SqlParameter("Type",model.Type),
                                     new SqlParameter("Author",model.Author),
                                     new SqlParameter("PubName",model.PubName),
                                     new SqlParameter("Page",model.Page),
                                     new SqlParameter("BookCase",model.BookCase),
                                     new SqlParameter("Borrownum",model.Borrownum),
                                     new SqlParameter("ContentDescription",model.ContentDescription),
                                     new SqlParameter("TOC",model.TOC),
                                     new SqlParameter("CategoryId",model.CategoryId),
                                     new SqlParameter("ISBN",model.ISBN),
                                     new SqlParameter("Price",model.Price)
                                   };
            return SqlHelper.ExcuteNonQuery(sbStr.ToString(),paras);
        }

        public Book GetById(int id) {
            string sql = "select * from Book where Id=@Id";
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
            string sql = "select count(*) from Book";
            return (int)SqlHelper.ExcuteScalar(sql);
        }

        public IEnumerable<Book> GetAll() {
            var list = new List<Book>();
            string sql = "select * from Book";
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql)) {
                while (reader.Read()) {
                    list.Add(ToModel(reader));                    
                }
            }
            return list;
        }

        public Book ToModel(SqlDataReader reader) {
            Book model = new Book();
            model.Id = (int)ToModelValue(reader,"Id");
            model.BookName = (string)ToModelValue(reader,"BookName");
            model.BookCase = (string)ToModelValue(reader,"BookCase");
            model.Borrownum = (int)ToModelValue(reader,"Borrownum");
            model.Author = (string)ToModelValue(reader,"Author");
            model.Type = (string)ToModelValue(reader,"Type");
            model.PubName = (string)ToModelValue(reader,"PubName");
            model.Page = (int)ToModelValue(reader,"Page");
            model.ContentDescription = (string)ToModelValue(reader,"ContentDescription");
            model.Price = (decimal)ToModelValue(reader,"Price");
            model.ISBN = (string)ToModelValue(reader,"ISBN");
            model.CategoryId = (int)ToModelValue(reader,"CategoryId");
            model.TOC = (string)ToModelValue(reader,"TOC");
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