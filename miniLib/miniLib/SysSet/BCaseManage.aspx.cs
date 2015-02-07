using log4net;
using miniLib.BLL;
using miniLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miniLib.SysSet
{
    public partial class BCaseManage : System.Web.UI.Page
    {
        ILog logger = LogManager.GetLogger(typeof(BCaseManage));
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "书架管理页面";
            BookCaseBind();
        }

        //*********************gvBCaseInfo绑定数据源************************
        private void BookCaseBind() {
            gvBCaseInfo.DataSource = new BookCaseBLL().GetAll();
            gvBCaseInfo.DataKeyNames = new string[] { "BookCaseId" };
            gvBCaseInfo.DataBind();
        }

        protected void gvBCaseInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBCaseInfo.EditIndex = -1;
            BookCaseBind();
        }

        protected void gvBCaseInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string BookCaseId = gvBCaseInfo.DataKeys[e.RowIndex].Value.ToString();
            int result=new BookCaseBLL().Delete(BookCaseId);
            if (result > 0)
            {
                Common.CommonCode.ShowMessage(this.Page, "删除成功");
                BookCaseBind();
            }
            else {
                Common.CommonCode.ShowMessage(this.Page,"删除失败，请与系统管理员联络！");
                logger.Error("系统出现异常~~~~~~删除失败");
                return;
            }
        }

        protected void gvBCaseInfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBCaseInfo.EditIndex = e.NewEditIndex;
            BookCaseBind();
        }

        protected void gvBCaseInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            BookCase model = new BookCase();
            model.BookCaseId = gvBCaseInfo.DataKeys[e.RowIndex].Value.ToString();
            model.Name = ((TextBox)(gvBCaseInfo.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
            int result = new BookCaseBLL().Update(model);
            if (result > 0)
            {
                gvBCaseInfo.EditIndex = -1;
                BookCaseBind();
                Common.CommonCode.ShowMessage(this.Page, "更新成功！");
            }
            else {
                Common.CommonCode.ShowMessage(this.Page,"更新失败~~~~~~~~~请与管理员联络！");
                logger.Error("系统异常~~~~~~书架更新失败");
                return;
            }
        }

        protected void gvBCaseInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBCaseInfo.PageIndex = e.NewPageIndex;
            BookCaseBind();
        }
    }
}