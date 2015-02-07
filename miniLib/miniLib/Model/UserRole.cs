using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniLib.Model
{
    [Serializable]
    public class UserRole
    {
        /// <summary>
        /// 等级ID
        /// </summary>
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 等级名称
        /// </summary>
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 可借数量
        /// </summary>
        int bookNumber;

        public int BookNumber
        {
            get { return bookNumber; }
            set { bookNumber = value; }
        }
    }
}