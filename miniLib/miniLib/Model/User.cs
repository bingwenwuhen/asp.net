using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniLib.Model
{
    [Serializable]
    public class User
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string loginName;

        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }
        string loginPwd;

        public string LoginPwd
        {
            get { return loginPwd; }
            set { loginPwd = value; }
        }
        string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        string mail;

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        int userRoleId;

        public int UserRoleId
        {
            get { return userRoleId; }
            set { userRoleId = value; }
        }

        string gender;

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        /// <summary>
        /// 证件号码
        /// </summary>
        string cardNumber;

        public string CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }

        /// <summary>
        /// 注册日期
        /// </summary>
        DateTime createDate;

        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }

        /// <summary>
        /// 借阅次数
        /// </summary>
        int borrowSum;

        public int BorrowSum
        {
            get { return borrowSum; }
            set { borrowSum = value; }
        }
    }
}