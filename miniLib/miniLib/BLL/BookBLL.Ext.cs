using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using miniLib.Model;
using miniLib.DAL;

namespace miniLib.BLL
{
    partial class BookBLL
    {
        public Book GetModelByISBN(string ISBN) {
            return new BookDAL().GetModelByISBN(ISBN);
        }

        public IEnumerable<Book> GetAllBookSort() {
            return new BookDAL().GetAllBookSort();
        }

        public IEnumerable<Book> GetByBookId(int id)
        {
            return new BookDAL().GetByBookId(id);
        }

        public IEnumerable<Book> GetByBookName(string BookName) {
            return new BookDAL().GetByBookName(BookName);
        }

        public IEnumerable<Book> GetByBookType(string type) {
            return new BookDAL().GetByBookType(type);
        }

        public IEnumerable<Book> GetByBookAuthor(string author) {
            return new BookDAL().GetByBookAuthor(author);
        }

        public IEnumerable<Book> GetBookByPubName(string PubName) {
            return new BookDAL().GetBookByPubName(PubName);
        }

        public IEnumerable<Book> GetBookByBookCase(string BookCase) {
            return new BookDAL().GetBookByBookCase(BookCase);
        }
    }
}