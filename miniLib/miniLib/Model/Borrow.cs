using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniLib.Model
{
    public class Borrow
    {
        /// <summary>
        /// Id
        /// </summary>
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 用户Id
        /// </summary>
        int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        /// <summary>
        /// book Id
        /// </summary>
        int bookId;

        public int BookId
        {
            get { return bookId; }
            set { bookId = value; }
        }

        /// <summary>
        /// 借阅时间
        /// </summary>
        DateTime borrowTime;

        public DateTime BorrowTime
        {
            get { return borrowTime; }
            set { borrowTime = value; }
        }

        /// <summary>
        /// 应归还时间
        /// </summary>
        DateTime returnTime;

        public DateTime ReturnTime
        {
            get { return returnTime; }
            set { returnTime = value; }
        }

        /// <summary>
        /// 目前借阅状态
        /// </summary>
        string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// 续借次数
        /// </summary>
        int reNewTime;

        public int ReNewTime
        {
            get { return reNewTime; }
            set { reNewTime = value; }
        }

        string bookName;

        public string BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }

        string bookCase;

        public string BookCase
        {
            get { return bookCase; }
            set { bookCase = value; }
        }
    }
}