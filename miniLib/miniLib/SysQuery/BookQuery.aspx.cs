using log4net;
using miniLib.BLL;
using miniLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miniLib.SysQuery
{
    public partial class BookQuery : System.Web.UI.Page
    {
        ILog logger = LogManager.GetLogger(typeof(BookQuery));
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "图书档案查询界面";
            logger.Debug(Session["Name"].ToString()+"进入了图书档案查询界面");
        }

        protected void gvBookInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBookInfo.PageIndex = e.NewPageIndex;
            GVBind();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            GVBind();
        }

        private void GVBind() {
            IEnumerable<Book> list=new List<Book>();
            int intCondition = ddlCondition.SelectedIndex;
            if (txtCondition.Text == "")
            {
                list = new BookBLL().GetAll();
            }
            else {
                switch (intCondition) { 
                    case 0:
                        int Id = Convert.ToInt32(txtCondition.Text);
                        list = new BookBLL().GetByBookId(Id);
                        break;
                    case 1:
                        string bookName = txtCondition.Text;
                        list = new BookBLL().GetByBookName(bookName);
                        break;
                    case 2:
                        string Type = txtCondition.Text;
                        list = new BookBLL().GetByBookType(Type);
                        break;
                    case 3:
                        string Author = txtCondition.Text;
                        list = new BookBLL().GetByBookAuthor(Author);
                        break;
                    case 4:
                        string PubName = txtCondition.Text;
                        list = new BookBLL().GetBookByPubName(PubName);
                        break;
                    case 5:
                        string BookCase = txtCondition.Text;
                        list = new BookBLL().GetBookByBookCase(BookCase);
                        break;
                }
            }
            gvBookInfo.DataSource = list;
            gvBookInfo.DataBind();
        }
    }
}