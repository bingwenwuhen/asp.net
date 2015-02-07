using log4net;
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
    public partial class ReturnBook : System.Web.UI.Page
    {
        ILog logger = LogManager.GetLogger(typeof(ReturnBook));
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "归还图书界面！";
            string name = Session["Name"].ToString();
            miniLib.Model.User model = new UserBLL().GetByLoginName(name);
            LbReaderID.Text =Convert.ToString(model.Id);
            LbReaderName.Text = model.LoginName;
            if (model.UserRoleId == 1) {
                LbReaderType.Text = "管理员";
            }
            else if (model.UserRoleId == 2)
            {
                LbReaderType.Text = "Vip";
            }
            else {
                LbReaderType.Text = "普通读者";
            }
            LbReaderCardNumber.Text = model.CardNumber;
            LbReaderEmail.Text = model.Mail;
            LbReaderGender.Text = model.Gender;
            LbReaderBorrnumber.Text = Convert.ToString(model.BorrowSum);
            BorrowBind();
        }

        protected void gvBorrowBook_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBorrowBook.PageIndex = e.NewPageIndex;
            BorrowBind();
        }

        protected void gvBorrowBook_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int Id = Convert.ToInt32(gvBorrowBook.DataKeys[e.RowIndex].Value.ToString());
            Borrow model = new BorrowBLL().GetById(Id);
            model.Status = "已归还";
            try
            {
                new BorrowBLL().Update(model);
            }
            catch (Exception ex) {
                Common.CommonCode.ShowMessage(this.Page,"归还失败！");
                logger.Error(Session["Name"].ToString()+"归还"+model.BookName+"失败："+ex.Message);
            }
        }

        private void BorrowBind()
        {
            string name = Session["Name"].ToString();
            miniLib.Model.User model = new UserBLL().GetByLoginName(name);
            gvBorrowBook.DataSource = new BorrowBLL().GetByBorrowStatus(model.Id);
            gvBorrowBook.DataKeyNames = new string[] { "Id" };
            gvBorrowBook.DataBind();

        }

    }
}