using miniLib.DAL;
using miniLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniLib.BLL
{
    [System.ComponentModel.DataObject]
    partial class UserBLL
    {
        public User GetByLoginName(string LoginName) {
            return new UserDAL().GetByLoginName(LoginName);
        }

        public int GetMaxId() {
            return new UserDAL().GetMaxId();
        }

        public IEnumerable<User> GetAdmin() {
            return new UserDAL().GetAdmin();
        }

        public int DeleteByName(string name) {
            return new UserDAL().DeleteByName(name);
        }

        public IEnumerable<User> GetUserSort() {
            return new UserDAL().GetUserSort();
        }
    }
}