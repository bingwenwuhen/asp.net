using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using miniLib.Model;
using miniLib.DAL;
namespace miniLib.BLL
{
    public class UserRoleBLL
    {
        public int Add(UserRole model) {
            return new UserRoleDAL().Add(model);
        }

        public int Delete(int id) {
            return new UserRoleDAL().Delete(id);
        }

        public int Update(UserRole model) {
            return new UserRoleDAL().Update(model);
        }

        public UserRole GetById(int id) {
            return new UserRoleDAL().GetById(id);
        }

        public int GetTotalCount() {
            return new UserRoleDAL().GetTotalCount();
        }

        public IEnumerable<UserRole> GetAll() {
            return new UserRoleDAL().GetAll();
        }
    }
}