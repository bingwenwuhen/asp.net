using miniLib.BLL;
using miniLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miniLib
{
    public partial class BorrowBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "借书页面";
            gvInfoBookBind();
            gvBRBookBind();
            if (Session["role"].ToString() != "Admin") {
                btnSure.Enabled = false;
            }
            string name=Session["Name"].ToString();
            User model = new UserBLL().GetByLoginName(name);
            TxtUserNumber.Text =Convert.ToString(model.Id);
            LabName.Text = model.LoginName;
            LabGender.Text = model.Gender;
            if (Session["role"].ToString() == "Admin") {
                LabBorrowNumber.Text = Convert.ToString(25);
                LabReaderType.Text = "管理员";
            }
            else if (Session["role"].ToString() == "Vip")
            {
                LabBorrowNumber.Text = Convert.ToString(20);
                LabReaderType.Text = "Vip读者";
            }
            else
            {
                LabBorrowNumber.Text = Convert.ToString(12);
                LabReaderType.Text = "普通读者";
            }
            LabPhone.Text = model.Phone;
            LabAddress.Text = model.Address;
        }

        protected void btnSure_Click(object sender, EventArgs e)
        {
            string number = TxtUserNumber.Text;
            int UserId = Convert.ToInt32(number);
            User model = new UserBLL().GetById(UserId);
            TxtUserNumber.Text = Convert.ToString(model.Id);
            LabName.Text = model.LoginName;
            LabGender.Text = model.Gender;
            if (model.UserRoleId==1)
            {
                LabBorrowNumber.Text = Convert.ToString(25);
                LabReaderType.Text = "管理员";
            }
            else if (model.UserRoleId==2)
            {
                LabBorrowNumber.Text = Convert.ToString(20);
                LabReaderType.Text = "Vip读者";
            }
            else
            {
                LabBorrowNumber.Text = Convert.ToString(12);
                LabReaderType.Text = "普通读者";
            }
            LabPhone.Text = model.Phone;
            LabAddress.Text = model.Address;
        }

        protected void gvBorrowBook_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBorrowBook.PageIndex = e.NewPageIndex;
            gvInfoBookBind();
        }

        private void gvInfoBookBind() {
            gvBookInfo.DataSource = new BookBLL().GetAll();
            gvBookInfo.DataBind();
        }

        protected void gvBookInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gvBookInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBookInfo.PageIndex = e.NewPageIndex;
            gvInfoBookBind();
        }

        private void gvBRBookBind() {
            gvBorrowBook.DataSource = new BorrowBLL().GetAll();
            gvBorrowBook.DataBind();
        }

        protected void gvBookInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBorrow_Click(object sender, EventArgs e)
        {
            //string BookName = Request["Label1"].ToString();
            //Common.CommonCode.ShowMessage(Page,BookName);
        }
    }
}