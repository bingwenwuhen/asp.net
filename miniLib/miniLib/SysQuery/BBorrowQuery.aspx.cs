using log4net;
using miniLib.BLL;
using miniLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miniLib.SysQuery
{
    public partial class BBorrowQuery : System.Web.UI.Page
    {
        private bool Result = false;
        ILog logger = LogManager.GetLogger(typeof(BBorrowQuery));
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "图书借阅查询界面";
            logger.Debug(Session["Name"].ToString()+"进入了借阅档案查询界面");
            GvBind();
        }

        protected void gvBorrowInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBorrowInfo.PageIndex = e.NewPageIndex;
            GvBind();
        }

        protected void ddlCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCondition.SelectedValue == "借阅时间")
            {
                Label1.Visible = Label2.Visible = Label3.Visible = txtFTime.Visible = txtTTime.Visible = true;
                txtCondition.Visible = false;
                Result = true;
            }
            else {
                Label1.Visible = Label2.Visible = Label3.Visible = txtFTime.Visible = txtTTime.Visible = false;
                txtCondition.Visible = true;
                Result = false;
            }
        }

        private void GvBind() { 
            IEnumerable<Borrow> list=new List<Borrow>();
            int Condition = ddlCondition.SelectedIndex;
            if (Condition <= 3)
            {
                if (txtCondition.Text == "")
                {
                    list = new BorrowBLL().GetAll();
                }
                else
                {
                    switch (Condition)
                    {
                        case 0:
                            int BookCode = Convert.ToInt32(txtCondition.Text);
                            list = new BorrowBLL().GetAllByBookCode(BookCode);
                            break;
                        case 1:
                            string BookName = txtCondition.Text;
                            list = new BorrowBLL().GetByBookName(BookName);
                            break;
                        case 2:
                            int UserId = Convert.ToInt32(txtCondition.Text);
                            list = new BorrowBLL().GetByUserId(UserId);
                            break;
                        case 3:
                            string UserName = txtCondition.Text;
                            var model = new UserBLL().GetByLoginName(UserName);
                            list = new BorrowBLL().GetByUserId(model.Id);
                            break;
                    }
                }
            }
            else {
                if (Result==false&&txtFTime.Text == "" && txtTTime.Text == "")
                {
                    Common.CommonCode.ShowMessage(this.Page, "请输入正确的借阅时间！");
                    Result = false;
                }
                else {
                    if (txtFTime.Text != "" && txtTTime.Text == "") {
                        DateTime BorrowTime = Convert.ToDateTime(txtFTime.Text);
                        list = new BorrowBLL().GetByBorrowTime(BorrowTime);
                    }
                    else if (txtFTime.Text == "" && txtTTime.Text != "")
                    {
                        DateTime ReturnTime = Convert.ToDateTime(txtTTime.Text);
                        list = new BorrowBLL().GetByReturnTime(ReturnTime);
                    }
                    else {
                        DateTime BorrowTime = Convert.ToDateTime(txtFTime.Text);
                        DateTime ReturnTime = Convert.ToDateTime(txtTTime.Text);
                        list = new BorrowBLL().GetByBorrowTimeAndReturnTime(BorrowTime,ReturnTime);
                    }
                }
            }
            gvBorrowInfo.DataSource = list;
            gvBorrowInfo.DataBind();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            GvBind();
        }
    }
}