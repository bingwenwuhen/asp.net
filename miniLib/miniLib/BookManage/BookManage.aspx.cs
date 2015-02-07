using log4net;
using miniLib.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miniLib.BookManage
{
    public partial class BookManage : System.Web.UI.Page
    {
        private ILog logger = LogManager.GetLogger(typeof(BookManage));
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "图书管理界面";
            BookBind();
            logger.Debug(Session["Name"].ToString()+"进入了图书管理界面");
        }

        protected void gvBookInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBookInfo.PageIndex = e.NewPageIndex;
            BookBind();
        }

        protected void gvBookInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ISBN =gvBookInfo.DataKeys[e.RowIndex].Value.ToString();
            var model = new BookBLL().GetModelByISBN(ISBN);
            try
            {
                new BookBLL().DeleteById(model.Id);
                logger.Debug(Session["Name"].ToString()+"删除了"+model.BookName+"这一本书");
                Common.CommonCode.ShowMessage(this.Page,"删除成功！");
            }
            catch (Exception ex) {
                logger.Error(Session["Name"].ToString()+"删除"+model.BookName+"时出错"+ex.Message);
            }
        }

        private void BookBind() {
            gvBookInfo.DataSource = new BookBLL().GetAll();
            gvBookInfo.DataKeyNames = new string[] { "ISBN" };
            gvBookInfo.DataBind();
        }
    }
}