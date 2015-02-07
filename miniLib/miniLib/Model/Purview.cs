using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniLib.Model
{
    public class Purview
    {
        /// <summary>
        /// 管理员Id
        /// </summary>
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 系统设置
        /// </summary>
        bool sysSet;

        public bool SysSet
        {
            get { return sysSet; }
            set { sysSet = value; }
        }

        /// <summary>
        /// 读者管理
        /// </summary>
        bool readSet;

        public bool ReadSet
        {
            get { return readSet; }
            set { readSet = value; }
        }

        /// <summary>
        /// 图书管理
        /// </summary>
        bool bookSet;

        public bool BookSet
        {
            get { return bookSet; }
            set { bookSet = value; }
        }

        /// <summary>
        /// 图书借还
        /// </summary>
        bool borrowBack;

        public bool BorrowBack
        {
            get { return borrowBack; }
            set { borrowBack = value; }
        }

        /// <summary>
        /// 系统查询
        /// </summary>
        bool sysQuery;

        public bool SysQuery
        {
            get { return sysQuery; }
            set { sysQuery = value; }
        }

        /// <summary>
        /// 登录名
        /// </summary>
        string loginName;

        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }

    }
}