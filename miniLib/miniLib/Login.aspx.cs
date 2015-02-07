using log4net;
using miniLib.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using miniLib.Common;

namespace miniLib
{
    public partial class Login : System.Web.UI.Page
    {
       private static  ILog logger = LogManager.GetLogger(typeof(Login));
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Minlib登录页面";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //==========================登录============================



            if (string.IsNullOrEmpty(txtUser.Text) ||string.IsNullOrEmpty(txtPwd.Text)) {
                Response.Write("<script>alert('用户名或密码不能为空！')</script>");
                return;
            }
            if (string.IsNullOrEmpty(txtCode.Text)) {
                Response.Write("<script>alert('验证码不能为空！')</script>");
                return;
            }
            if (txtCode.Text != Session["vCode"].ToString()) {
                Response.Write("<script>alert('验证码错误！')</script>");
                return;
            }
            string LoginName = txtUser.Text;
            string LoginPwd = txtPwd.Text;
            miniLib.Model.User model = new UserBLL().GetByLoginName(LoginName);
            if (LoginPwd == model.LoginPwd) {
                logger.Debug("有用户登录"+model.LoginName);
                Session["Name"] = model.LoginName;
                if (model.UserRoleId == 1) {
                    Session["role"] = "Admin";
                }
                else if (model.UserRoleId == 2)
                {
                    Session["role"] = "Vip";
                }
                else {
                    Session["role"] = "Reader";
                }
                
                Response.Redirect("~/BorrowBook.aspx");
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //===============================取消登录====================================
            txtUser.Text = "";
            txtPwd.Text = "";
            txtCode.Text = "";
        }
    }
}