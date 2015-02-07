using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using miniLib.DAL;
using miniLib.Model;

namespace miniLib.BLL
{
    public class LibraryBLL
    {
        public int Update(Library model) {
            return new LibraryDAL().Update(model);
        }

        public Library Get() {
            return new LibraryDAL().Get();
        }
    }
}