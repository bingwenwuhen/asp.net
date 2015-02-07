using log4net;
using miniLib.BLL;
using miniLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miniLib.ReaderManage
{
    public partial class RTypeManage : System.Web.UI.Page
    {
        ILog logger = LogManager.GetLogger(typeof(RTypeManage));
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "读者类型管理页面";
            GvrTypeInfoBind();
        }

        private void GvrTypeInfoBind() {
            gvRTypeInfo.DataSource = new UserRoleBLL().GetAll();
            gvRTypeInfo.DataKeyNames = new string[] { "Id" };
            gvRTypeInfo.DataBind();
        }

        protected void gvRTypeInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRTypeInfo.PageIndex = e.NewPageIndex;
            GvrTypeInfoBind();
        }

        protected void gvRTypeInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvRTypeInfo.EditIndex = -1;
            GvrTypeInfoBind();
        }

        protected void gvRTypeInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            UserRole model = new UserRole();
            model.Id = Convert.ToInt32(gvRTypeInfo.DataKeys[e.RowIndex].Value.ToString());
            new UserRoleBLL().Delete(model.Id);
            model = new UserRoleBLL().GetById(model.Id);
            Common.CommonCode.ShowMessage(this.Page,"删除成功！");
            logger.Debug(Session["Name"].ToString()+"正在删除 "+model.Name+"读者类型");
        }

        protected void gvRTypeInfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvRTypeInfo.EditIndex = e.NewEditIndex;
            GvrTypeInfoBind();
        }

        protected void gvRTypeInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            UserRole model = new UserRole();
            model.Id = Convert.ToInt32(gvRTypeInfo.DataKeys[e.RowIndex].Value.ToString());
            model.Name=((TextBox)(gvRTypeInfo.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
            model.BookNumber = Convert.ToInt32(((TextBox)(gvRTypeInfo.Rows[e.RowIndex].Cells[2].Controls[0])).Text);
            new UserRoleBLL().Update(model);
            gvRTypeInfo.EditIndex = -1;
            logger.Debug(Session["Name"].ToString()+"修改了"+model.Name+"这种读者类型的资料");
        }
    }
}