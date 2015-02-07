using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using miniLib.Model;
using miniLib.DAL;

namespace miniLib.BLL
{
    partial class PurviewBLL
    {
        public int Add(Purview model) {
            return new PurviewDAL().Add(model);
        }

        public int Delete(int id) {
            return new PurviewDAL().Delete(id);
        }

        public int Update(Purview model) {
            return new PurviewDAL().Update(model);
        }

        public Purview GetById(int id) {
            return new PurviewDAL().GetById(id);
        }

        public IEnumerable<Purview> GetAll() {
            return new PurviewDAL().GetAll();
        }
    }
}