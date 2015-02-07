using miniLib.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miniLib
{
    public partial class ChangeUserInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string UserName=Session["Name"].ToString();
            miniLib.Model.User model = new UserBLL().GetByLoginName(UserName);
            txtAdress.Text = model.Address;
            txtEmail.Text = model.Mail;
            txtPhone.Text = model.Phone;
            if (model.Gender == "男")
            {
                RadioMan.Checked = true;
            }
            else {
                RadioWoman.Checked = true;
            }
            if (model.UserRoleId == 1) {
                LbCategeory.Text = "管理员";
            }
            else if (model.UserRoleId == 2)
            {
                LbCategeory.Text = "Vip用户";
            }
            else {
                LbCategeory.Text = "普通用户";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //*************************取消操作*****************************
            Response.Redirect("~/Default.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            miniLib.Model.User model = new Model.User();
            model.LoginName = LabelName.Text;
            model.Address = txtAdress.Text;
            model.Phone = txtPhone.Text;
            model.Mail = txtEmail.Text;
            if (RadioMan.Checked)
            {
                model.Gender = "男";
            }
            else {
                model.Gender = "女";
            }
            if (LbCategeory.Text == "管理员") {
                model.UserRoleId = 1;
            }
            else if (LbCategeory.Text == "Vip用户")
            {
                model.UserRoleId = 2;
            }
            else {
                model.UserRoleId = 3;                                  //普通用户
            }
            int update=new UserBLL().Update(model);
            if (update > 0)
            {
                Common.CommonCode.ShowMessage(this.Page, "修改成功！");
                Response.Redirect("~/ChangeUserInformation.aspx");
            }
            else {
                Common.CommonCode.ShowMessage(this.Page,"修改失败~~~~~~请与管理员联络！");
                return;
            }
        }
    }
}