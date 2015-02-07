using log4net;
using miniLib.BLL;
using miniLib.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miniLib
{
    public partial class AddReader : System.Web.UI.Page
    {
        ILog logger = LogManager.GetLogger(typeof(AddReader));
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "添加/修改读者界面";
            if (Request["readerid"] != null)
            {
                btnAdd.Visible = false;
                btnSave.Enabled = true;
                Model.User model = new Model.User();
                int id = Convert.ToInt32(Request["readerid"]);
                model = new UserBLL().GetById(id);
                LabelReaderId.Text = Convert.ToString(model.Id);
                txtReader.Text = model.LoginName;
                ddlSex.SelectedValue = model.Gender;
                if (model.UserRoleId == 1)
                {
                    ddlRType.SelectedValue = "管理员";
                }
                else if (model.UserRoleId == 2)
                {
                    ddlRType.SelectedValue = "读者";
                }
                else
                {
                    ddlRType.SelectedValue = "Vip";
                }
                TxtCardNumber.Text = model.CardNumber;
                txtTel.Text = model.Phone;
                TxtPwd.Text = model.LoginPwd;
                txtEmail.Text = model.Mail;
                txtDate.Text = Convert.ToString(model.CreateDate);
            }
            else {
                btnSave.Visible = false;
                btnAdd.Enabled = true;
                txtDate.Text = Convert.ToString(DateTime.Now.ToShortDateString());
                LabelReaderId.Text =Convert.ToString( new UserDAL().GetMaxId()+1);
            }
            logger.Debug(Session["Name"].ToString()+"进入了添加/修改读者界面");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //=========================选择取消操作========================
            Response.Redirect("AddReader.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //========================修改读者操作=========================
            Model.User model = new Model.User();
            model.Id =Convert.ToInt32( LabelReaderId.Text);
            model.LoginName = txtReader.Text;
            model.LoginPwd = TxtPwd.Text;
            model.Gender = ddlSex.SelectedValue;
            if (ddlRType.SelectedValue == "管理员") {
                model.UserRoleId = 1;
            }
            else if (ddlRType.SelectedValue == "读者") {
                model.UserRoleId = 3;
            }
            else if (ddlRType.SelectedValue == "Vip")
            {
                model.UserRoleId = 2;
            }
            else {
                model.UserRoleId = 4;
            }
            model.CardNumber = TxtCardNumber.Text;
            model.Phone = txtTel.Text;
            model.Mail = txtEmail.Text;
            model.CreateDate = Convert.ToDateTime(txtDate.Text);
            try
            {
                new UserBLL().Update(model);
                Common.CommonCode.ShowMessage(this.Page,"修改成功！");
                logger.Debug(Session["Name"].ToString()+"修改了"+model.LoginName+"的资料！");
                Response.Redirect("AddReader.aspx");
            }
            catch (Exception ex) {
                logger.Error(Session["Name"].ToString()+"修改"+model.LoginName+"时发生错误:"+ex.Message);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //============================添加读者界面=============================
            miniLib.Model.User model = new Model.User();
            model.LoginName = txtReader.Text;
            model.LoginPwd = TxtPwd.Text;
            model.Gender = ddlSex.SelectedValue;
            if (ddlRType.SelectedValue == "管理员") {
                model.UserRoleId = 1;
            }
            else if (ddlRType.SelectedValue == "Vip") {
                model.UserRoleId = 2;
            }
            else if (ddlRType.SelectedValue == "读者")
            {
                model.UserRoleId = 3;
            }
            else {
                model.UserRoleId = 4;
            }
            model.CardNumber = TxtCardNumber.Text;
            model.Phone = txtTel.Text;
            model.Mail = txtEmail.Text;
            model.CreateDate = DateTime.Now;
            try
            {
                new UserBLL().Add(model);
                logger.Debug(Session["Name"].ToString()+"添加了"+ddlRType.SelectedValue+"这一类型名为"+model.LoginName+"的这一个读者！");
                Common.CommonCode.ShowMessage(this.Page,"添加成功！");
            }
            catch (Exception ex) {
                logger.Error(Session["Name"].ToString()+"添加"+ddlRType.SelectedValue+"这一类型的读者时发生错误!");
                Common.CommonCode.ShowMessage(this.Page,"发生错误！");
            }
        }
    }
}