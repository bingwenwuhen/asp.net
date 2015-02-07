using log4net;
using miniLib.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miniLib.SortManage
{
    public partial class BookBorrowSort : System.Web.UI.Page
    {
        ILog logger = LogManager.GetLogger(typeof(BookBorrowSort));
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "图书借阅查询界面";
            logger.Debug(Session["Name"].ToString()+"进入了图书借阅排行界面");
            gvBind();
        }

        protected void gvBookSort_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBookSort.PageIndex = e.NewPageIndex;
            gvBind();
        }

        protected void gvBookSort_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1) {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }
        }

        private void gvBind() {
            gvBookSort.DataSource = new BookBLL().GetAllBookSort();
            gvBookSort.DataBind();
        }
    }
}