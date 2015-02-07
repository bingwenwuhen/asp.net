using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using miniLib.Model;
using miniLib.DAL;

namespace miniLib.BLL
{
    public class BookCaseBLL
    {
        public int Add(BookCase model) {
            return new BookCaseDAL().Add(model);
        }

        public int Delete(string id) {
            return new BookCaseDAL().Delete(id);
        }

        public int Update(BookCase model) {
            return new BookCaseDAL().Update(model);
        }

        public BookCase GetById(string id) {
            return new BookCaseDAL().GetById(id);
        }

        public int TotalCount() {
            return new BookCaseDAL().TotalCount();
        }

        public IEnumerable<BookCase> GetAll() {
            return new BookCaseDAL().GetAll();
        }
    }
}