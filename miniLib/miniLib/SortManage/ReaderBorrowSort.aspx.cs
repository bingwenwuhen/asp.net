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
    public partial class ReaderBorrowSort : System.Web.UI.Page
    {
        ILog logger = LogManager.GetLogger(typeof(ReaderBorrowSort));
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "读者借阅排行榜";
            logger.Debug(Session["Name"].ToString()+"进入了读者借阅排行榜界面");
            GvUserBind();
        }

        protected void gvReaderSort_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReaderSort.PageIndex = e.NewPageIndex;
            GvUserBind();
        }

        protected void gvReaderSort_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1) {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }
        }

        private void GvUserBind() {
            gvReaderSort.DataSource = new UserBLL().GetUserSort();
            gvReaderSort.DataBind();
        }
    }
}