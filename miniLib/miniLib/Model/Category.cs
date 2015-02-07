using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniLib.Model
{
    public class Category
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}