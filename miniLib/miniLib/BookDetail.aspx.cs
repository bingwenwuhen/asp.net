using miniLib.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miniLib
{
    public partial class BookDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BookBind();
        }

        //************************************数据绑定*********************************************//
        private void BookBind() {
            string ISBN=Request["ISBN"];
            BookDetailsView.DataSource = new BookBLL().GetByISBN(ISBN);
            BookDetailsView.DataBind();
        }
    }
}