using miniLib.DAL;
using miniLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniLib.BLL
{
    partial class BorrowBLL
    {
        public IEnumerable<Borrow> GetAllByBookCode(int BookId) {
            return new BorrowDAL().GetAllByBookCode(BookId);
        }

        public IEnumerable<Borrow> GetByBookName(string BookName) {
            return new BorrowDAL().GetByBookName(BookName);
        }

        public IEnumerable<Borrow> GetByUserId(int UserId) {
            return new BorrowDAL().GetByUserId(UserId);
        }

        public IEnumerable<Borrow> GetByBorrowTime(DateTime BorrowTime) {
            return new BorrowDAL().GetByBorrowTime(BorrowTime);
        }

        public IEnumerable<Borrow> GetByReturnTime(DateTime ReturnTime) {
            return new BorrowDAL().GetByReturnTime(ReturnTime);
        }

        public IEnumerable<Borrow> GetByBorrowTimeAndReturnTime(DateTime BorrowTime, DateTime ReturnTime) {
            return new BorrowDAL().GetByBorrowTimeAndReturnTime(BorrowTime,ReturnTime);
        }

        public IEnumerable<Borrow> GetByBorrowStatus(int UserId) {
            return new BorrowDAL().GetByBorrowStatus(UserId);
        }
    }
}