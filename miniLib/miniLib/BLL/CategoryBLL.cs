using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using miniLib.Model;
using miniLib.DAL;

namespace miniLib.BLL
{
    public class CategoryBLL
    {
        public int Add(Category model) {
            return new CategoryDAL().Add(model);
        }

        public int Delete(int id) {
            return new CategoryDAL().Delete(id);
        }

        public int Update(Category model) {
            return new CategoryDAL().Update(model);
        }

        public Category GetById(int id) {
            return new CategoryDAL().GetById(id);
        }

        public IEnumerable<Category> GetAll() {
            return new CategoryDAL().GetAll();
        }

        public int GetTotalCount() {
            return new CategoryDAL().GetTotalCount();
        }
    }
}