using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using miniLib.DAL;
using miniLib.Model;

namespace miniLib.BLL
{
    [System.ComponentModel.DataObject]
    partial class BorrowBLL
    {
        public int Add(Borrow model) {
            return new BorrowDAL().Add(model);
        }

        public int Delete(int id) {
            return new BorrowDAL().Delete(id);
        }

        public int Update(Borrow model) {
            return new BorrowDAL().Update(model);
        }

        public Borrow GetById(int id) {
            return new BorrowDAL().GetById(id);
        }

        public int GetTotalCount() {
            return new BorrowDAL().GetTotalCount();
        }

        public IEnumerable<Borrow> GetAll() {
            return new BorrowDAL().GetAll();
        }
    }
}