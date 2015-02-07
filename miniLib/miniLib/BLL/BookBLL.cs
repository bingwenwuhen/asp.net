using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using miniLib.Model;
using miniLib.DAL;

namespace miniLib.BLL
{
    [System.ComponentModel.DataObject]
    partial class BookBLL
    {
        public int Add(Book model) {
            return new BookDAL().Add(model);
        }

        public int DeleteById(int id) {
            return new BookDAL().DeleteById(id);
        }

        public int Update(Book model) {
            return new BookDAL().Update(model);
        }

        public Book GetById(int id) {
            return new BookDAL().GetById(id);
        }

        public int GetTotalCount() {
            return new BookDAL().GetTotalCount();
        }

        public IEnumerable<Book> GetAll() {
            return new BookDAL().GetAll();
        }

        public IEnumerable<Book> GetByISBN(string ISBN)
        {
            return new BookDAL().GetByISBN(ISBN);
        } 
    }
}