using miniLib.BLL;
using miniLib.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miniLib
{
    public partial class Front : System.Web.UI.MasterPage
    {
        private OperatorClass operatorclass=new OperatorClass();
        UserBLL bll = new UserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"].ToString() == "Reader" || Session["role"].ToString() == "Vip")
            {
                menuNav.Items[1].Enabled = false;
                menuNav.Items[2].Enabled = false;
                menuNav.Items[3].Enabled = false;
                menuNav.Items[5].Enabled = false;
            }
            else {
                labDate.Text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日";
                labXQ.Text = operatorclass.getWeek();
                labAdmin.Text = Session["Name"].ToString();
                miniLib.Model.User model = bll.GetByLoginName(Session["Name"].ToString());
                string ReaderID =Convert.ToString( model.Id);

            }
        }

        protected void menuNav_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (menuNav.SelectedValue == "退出系统") {
                Response.Write("<script>window.close();</script>");
            }
        }
    }
}