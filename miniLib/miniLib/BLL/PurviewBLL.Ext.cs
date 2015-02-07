using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using miniLib.Model;
using miniLib.DAL;
namespace miniLib.BLL
{
    partial class PurviewBLL
    {
        public int DeleteByLoginName(string LoginName) {
            return new PurviewDAL().DeleteByLoginName(LoginName);
        }

        public Purview GetByLoginName(string LoginName) {
            return new PurviewDAL().GetByLoginName(LoginName);
        }
    }
}