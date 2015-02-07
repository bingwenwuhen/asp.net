using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniLib.Model
{
    [Serializable]
    public class Library
    {
        /// <summary>
        /// 图书馆名字
        /// </summary>
        string lName;

        public string LName
        {
            get { return lName; }
            set { lName = value; }
        }

        /// <summary>
        /// 馆长
        /// </summary>
        string lCurator;

        public string LCurator
        {
            get { return lCurator; }
            set { lCurator = value; }
        }

        /// <summary>
        /// 图书馆电话
        /// </summary>
        string lPhone;

        public string LPhone
        {
            get { return lPhone; }
            set { lPhone = value; }
        }

        /// <summary>
        /// 图书馆地址
        /// </summary>
        string lAddress;

        public string LAddress
        {
            get { return lAddress; }
            set { lAddress = value; }
        }

        /// <summary>
        /// 图书馆Email
        /// </summary>
        string lEmail;

        public string LEmail
        {
            get { return lEmail; }
            set { lEmail = value; }
        }

        /// <summary>
        /// 图书馆网址
        /// </summary>
        string lSite;

        public string LSite
        {
            get { return lSite; }
            set { lSite = value; }
        }

        /// <summary>
        /// 图书馆建馆时间
        /// </summary>
        DateTime lCreateTime;

        public DateTime LCreateTime
        {
            get { return lCreateTime; }
            set { lCreateTime = value; }
        }

        /// <summary>
        /// 图书馆简介
        /// </summary>
        string lIntroduce;

        public string LIntroduce
        {
            get { return lIntroduce; }
            set { lIntroduce = value; }
        }
    }
}