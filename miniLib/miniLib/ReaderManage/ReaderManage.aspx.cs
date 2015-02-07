using log4net;
using miniLib.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miniLib.ReaderManage
{
    public partial class ReaderManage : System.Web.UI.Page
    {
        ILog logger = LogManager.GetLogger(typeof(ReaderManage));
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "读者档案管理界面";
            logger.Debug(Session["Name"].ToString()+"进入了读者档案管理界面！");
            ReadBind();
        }

        protected void gvReaderInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id =Convert.ToInt32( gvReaderInfo.DataKeys[e.RowIndex].Value.ToString());
            try
            {
                new UserBLL().DeleteById(Id);
            }
            catch (Exception ex) {
                logger.Debug("删除读者档案信息发生异常!"+ex.Message);
            }
            miniLib.Model.User model = new UserBLL().GetById(Id);
            logger.Debug(Session["Name"].ToString()+"删除了"+model.LoginName);
            ReadBind();
        }

        protected void gvReaderInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReaderInfo.PageIndex = e.NewPageIndex;
            ReadBind();
        }

        private void ReadBind() {

            //============================绑定数据=============================

            gvReaderInfo.DataSource = new UserBLL().GetAll();
            gvReaderInfo.DataKeyNames = new string[] { "Id" };
            gvReaderInfo.DataBind();
        }
    }
}