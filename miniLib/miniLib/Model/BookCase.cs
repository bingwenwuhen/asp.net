using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniLib.Model
{
    [Serializable]
    public class BookCase
    {
        /// <summary>
        /// 书架ID
        /// </summary>
        string bookCaseId;

        public string BookCaseId
        {
            get { return bookCaseId; }
            set { bookCaseId = value; }
        }

        /// <summary>
        /// 书架类别
        /// </summary>
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}