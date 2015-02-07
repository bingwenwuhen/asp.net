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
    public partial class BTypeManage : System.Web.UI.Page
    {
        ILog logger = LogManager.GetLogger(typeof(BTypeManage));
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "图书类型管理界面";
            logger.Debug(Session["Name"].ToString()+"进入了图书类型管理界面");
            GvTypeBind();
        }

        protected void gvBTypeInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBTypeInfo.PageIndex = e.NewPageIndex;
            GvTypeBind();
        }

        protected void gvBTypeInfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBTypeInfo.EditIndex = e.NewEditIndex;
            GvTypeBind();
        }

        protected void gvBTypeInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBTypeInfo.EditIndex = -1;
            GvTypeBind();
        }

        protected void gvBTypeInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvBTypeInfo.DataKeys[e.RowIndex].Value.ToString());
            var model = new CategoryBLL().GetById(id);
            string name = model.Name;
            model.Name = ((TextBox)gvBTypeInfo.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            try
            {
                new CategoryBLL().Update(model);
                logger.Debug(Session["Name"].ToString()+"修改"+name+"这种类型为"+model.Name);
                Common.CommonCode.ShowMessage(this.Page,"修改成功！");
            }
            catch (Exception ex) {
                logger.Error("修改"+name+"时出错"+ex.Message);
            }
        }

        protected void gvBTypeInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvBTypeInfo.DataKeys[e.RowIndex].Value.ToString());
            var model = new CategoryBLL().GetById(id);
            try
            {
                new CategoryBLL().Delete(id);
                logger.Debug(Session["Name"].ToString()+"删除了"+model.Name+"这一种图书类型");
                Common.CommonCode.ShowMessage(this.Page,"删除成功！");
            }
            catch (Exception ex) {
                logger.Error("删除出错"+ex.Message);
            }
        }

        private void GvTypeBind() {
            gvBTypeInfo.DataSource = new CategoryBLL().GetAll();
            gvBTypeInfo.DataKeyNames = new string[] { "Id" };
            gvBTypeInfo.DataBind();
        }
    }
}