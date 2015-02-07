using miniLib.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miniLib
{
    public partial class ChanagePwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "更改口令页面";
            LabelName.Text = Session["Name"].ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string LoginName = Session["Name"].ToString();
            miniLib.Model.User model = new UserBLL().GetByLoginName(LoginName);
            if (model.LoginPwd == txtYPwd.Text)
            {
                model.LoginPwd = txtXPwd.Text;
                int update = new UserBLL().Update(model);
                if (update > 0)
                {
                    Response.Write("<script>alert('密码修改成功！');</script>");
                }
                System.Threading.Thread.Sleep(3000);
                Response.Redirect("~/BorrowBook.aspx");
            }
            else {
                Response.Write("<script>alert('密码错误！');</script>");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //**************************重置密码***********************************
            txtXPwd.Text = "";
            txtSXPwd.Text = "";
            txtYPwd.Text = "";
        }
    }
}