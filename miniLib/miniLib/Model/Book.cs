using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniLib.Model
{
    [Serializable]
    public class Book
    {
        /// <summary>
        /// Book Id
        /// </summary>
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 书名
        /// </summary>
        string bookName;

        public string BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }

        /// <summary>
        /// 书籍类型
        /// </summary>
        string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// 作者
        /// </summary>
        string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        /// <summary>
        /// 出版社
        /// </summary>
        string pubName;

        public string PubName
        {
            get { return pubName; }
            set { pubName = value; }
        }

        /// <summary>
        /// 书籍页数
        /// </summary>
        int page;

        public int Page
        {
            get { return page; }
            set { page = value; }
        }

        /// <summary>
        /// 所在书架
        /// </summary>
        string bookCase;

        public string BookCase
        {
            get { return bookCase; }
            set { bookCase = value; }
        }

        /// <summary>
        /// 被借过次数
        /// </summary>
        int borrownum;

        public int Borrownum
        {
            get { return borrownum; }
            set { borrownum = value; }
        }

        /// <summary>
        /// 内容描述
        /// </summary>
        string contentDescription;

        public string ContentDescription
        {
            get { return contentDescription; }
            set { contentDescription = value; }
        }

        /// <summary>
        /// 章节描述
        /// </summary>
        string tOC;

        public string TOC
        {
            get { return tOC; }
            set { tOC = value; }
        }
        
        /// <summary>
        /// 类型Id
        /// </summary>
        int categoryId;

        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        /// <summary>
        /// 书籍价钱
        /// </summary>
        decimal price;

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        /// <summary>
        /// 书籍ISBN号
        /// </summary>
        string iSBN;

        public string ISBN
        {
            get { return iSBN; }
            set { iSBN = value; }
        }
    }
}