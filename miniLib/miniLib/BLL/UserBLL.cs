using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using miniLib.DAL;
using miniLib.Model;
namespace miniLib.BLL
{

    partial class UserBLL
    {
        public int Add(User model) {
            return new UserDAL().Add(model);
        }

        public int DeleteById(int id) {
            return new UserDAL().DeleteById(id);
        }

        public int Update(User model) {
            return new UserDAL().Update(model);
        }

        public User GetById(int id) {
            return new UserDAL().GetById(id);
        }

        public int GetTotalCount() {
            return new UserDAL().GetTotalCount();
        }

        public IEnumerable<User> GetPageData(int minrownum,int maxrownum) {
            return new UserDAL().GetPageData(minrownum,maxrownum);
        }

        public IEnumerable<User> GetAll() {
            return new UserDAL().GetAll();
        }
    }
}