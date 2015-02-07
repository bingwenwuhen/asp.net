using log4net;
using miniLib.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miniLib
{
    public partial class Register : System.Web.UI.Page
    {
        private static ILog logger = LogManager.GetLogger(typeof(Register));
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            string LoginName = TxtUser.Text;
            string LoginPwd = TxtPwd.Text;
            string ConfirmPwd = TxtConfirmPwd.Text;
            if (string.IsNullOrEmpty(LoginPwd)) {
                Response.Write("<script>alert('密码不能为空！')</script>");
                return;
            }
            if (string.IsNullOrEmpty(ConfirmPwd)) {
                Response.Write("<script>alert('重复的密码不能为空！')</script>");
                return;
            }
            if (LoginPwd != ConfirmPwd) {
                Response.Write("<script>alert('两次输入的密码不相同！')</script>");
                return;
            }
            string Email = TxtEmail.Text;
            string Address = TxtAddress.Text;
            string Phone = TxtPhone.Text;
            string vCode=Session["vCode"].ToString();
            if (vCode != TxtvCode.Text) {
                Response.Write("<script>alert('验证码不正确！')</script>");
                return;
            }
            miniLib.Model.User model = new Model.User();
            model.LoginName = LoginName;
            model.LoginPwd = LoginPwd;
            if (RadioMan.Checked == true)
            {
                model.Gender = "男";
            }
            else {
                model.Gender = "女";
            }
            model.Mail = Email;
            model.Phone = Phone;
            model.Address = Address;
            model.UserRoleId = 3;
            UserBLL bll = new UserBLL();
            bll.Add(model);
            Response.Write("<script>alert('注册成功！')</script>");
            logger.Debug("有新用户注册"+model.LoginName);
            Session["Name"] = model.LoginName;
            Response.Redirect("BorrowBook.aspx");
        }
    }
}