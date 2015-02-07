using log4net;
using miniLib.BLL;
using miniLib.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miniLib.SysSet
{
    public partial class AdminManage : System.Web.UI.Page
    {
        ILog logger = LogManager.GetLogger(typeof(AdminManage));
        protected void Page_Load(object sender, EventArgs e)
        {
            logger.Debug(Session["Name"].ToString()+"进入了管理员管理界面！");
            GvAdminBind();
        }

        private void GvAdminBind() {
            //==============================加载数据================================
            gvAdminPurview.DataSource = new PurviewDAL().GetAll();
            gvAdminPurview.DataKeyNames = new string[] { "LoginName"};
            gvAdminPurview.DataBind();
        }

        protected void gvAdminPurview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAdminPurview.PageIndex = e.NewPageIndex;
            GvAdminBind();
        }

        protected void gvAdminPurview_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAdminPurview.EditIndex = -1;
            GvAdminBind();
        }

        protected void gvAdminPurview_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string name = gvAdminPurview.DataKeys[e.RowIndex].Value.ToString();
            if (name == "bingwen")
            {
                Common.CommonCode.ShowMessage(this.Page, "这个用户为root用户，不得修改");
            }
            else {
                try
                {
                    new UserBLL().DeleteByName(name);
                    new PurviewDAL().DeleteByLoginName(name);
                    Common.CommonCode.ShowMessage(this.Page,"删除成功！");
                    logger.Debug(Session["Name"].ToString()+"删除了"+name+"这一个管理员！");
                }
                catch (Exception ex) {
                    Common.CommonCode.ShowMessage(this.Page,"删除错误！");
                    logger.Debug(Session["Name"].ToString()+"删除"+name+"时出错！："+ex.Message);
                }
            }
            GvAdminBind();
        }

        protected void gvAdminPurview_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAdminPurview.PageIndex = e.NewEditIndex;
            GvAdminBind();
        }

        protected void gvAdminPurview_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string name = gvAdminPurview.DataKeys[e.RowIndex].Value.ToString();
            if (name == "bingwen")
            {
                Common.CommonCode.ShowMessage(this.Page, "root用户不能修改!");
            }
            else {
                Model.Purview model = new PurviewBLL().GetByLoginName(name);
                model.SysSet=((CheckBox)gvAdminPurview.Rows[e.RowIndex].Cells[1].Controls[0]).Checked;
                model.ReadSet = ((CheckBox)gvAdminPurview.Rows[e.RowIndex].Cells[2].Controls[0]).Checked;
                model.BookSet = ((CheckBox)gvAdminPurview.Rows[e.RowIndex].Cells[3].Controls[0]).Checked;
                model.BorrowBack = ((CheckBox)gvAdminPurview.Rows[e.RowIndex].Cells[4].Controls[0]).Checked;
                model.SysQuery = ((CheckBox)gvAdminPurview.Rows[e.RowIndex].Cells[5].Controls[0]).Checked;
                try
                {
                    new PurviewBLL().Update(model);
                    logger.Debug(Session["Name"].ToString()+"修改了"+model.LoginName);
                }
                catch (Exception ex) {
                    Common.CommonCode.ShowMessage(this.Page,"修改出错！");
                    logger.Error(Session["Name"].ToString()+"修改"+model.LoginName+"时出错："+ex.Message);
                }
                gvAdminPurview.EditIndex = -1;
                GvAdminBind();
            }
        }
    }
}