using log4net;
using miniLib.BLL;
using miniLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miniLib.SysSet
{
    public partial class LibraryInfo : System.Web.UI.Page
    {
        ILog logger = LogManager.GetLogger(typeof(LibraryInfo));
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "图书馆信息界面";

            Library model = new LibraryBLL().Get();
            LbLibraryName.Text = model.LName;
            txtTel.Text = model.LPhone;
            txtCurator.Text = model.LCurator;
            txtAddress.Text = model.LAddress;
            txtEmail.Text = model.LEmail;
            txtIntroduce.Text = model.LIntroduce;
            txtUrl.Text = model.LSite;
            txtCDate.Text =Convert.ToString( model.LCreateTime);
            logger.Debug(Session["Name"].ToString()+"进入了图书馆信息界面");
        }
    }
}