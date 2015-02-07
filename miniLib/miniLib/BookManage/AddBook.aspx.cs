using log4net;
using miniLib.BLL;
using miniLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miniLib.BookManage
{
    public partial class AddBook : System.Web.UI.Page
    {
        ILog logger = LogManager.GetLogger(typeof(AddBook));
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "增加图书页面";
            logger.Debug(Session["Name"].ToString()+"进入了新增图书界面");
            DdLTypeBind();
            DBookTypeBind();
            if (Request["ISBN"] == null)
            {
                btnSave.Enabled = false;
                btnSave.Visible = false;
                btnAdd.Enabled = true;
            }
            else {
                btnAdd.Visible = false;
                btnSave.Visible = true;
                btnSave.Enabled = true;
                string ISBN = Request["ISBN"].ToString();
                var model = new BookBLL().GetModelByISBN(ISBN);
                txtID.Text = Convert.ToString(model.Id);
                txtBName.Text = model.BookName;
                ddlBType.SelectedValue = model.Type;
                txtAuthor.Text = model.Author;
                txtISBN.Text = model.ISBN;
                txtPub.Text = model.PubName;
                txtPrice.Text =Convert.ToString( model.Price);
                txtPage.Text = Convert.ToString(model.Page);
                ddlBCase.SelectedValue = model.BookCase;
                txtContent.Text = model.ContentDescription;
                txtTOC.Text = model.TOC;
            }
        }

        private void DdLTypeBind() {
            ddlBCase.DataSource = new BookCaseBLL().GetAll();
            ddlBCase.DataTextField = "Name";
            ddlBCase.DataBind();
        }

        private void DBookTypeBind() {
            ddlBType.DataSource = new CategoryBLL().GetAll();
            ddlBType.DataTextField = "Name";
            ddlBType.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Book model = new Book();
            model.Id =Convert.ToInt32( txtID.Text);
            model.BookName = txtBName.Text;
            model.Type = ddlBType.SelectedValue;
            model.Author = txtAuthor.Text;
            model.ISBN = txtISBN.Text;
            model.PubName = txtPub.Text;
            model.Price =Convert.ToDecimal( txtPrice.Text);
            model.Page = Convert.ToInt32(txtPage.Text);
            model.BookCase = ddlBCase.SelectedValue;
            model.ContentDescription = txtContent.Text;
            model.TOC = txtTOC.Text;
            model.CategoryId = ddlBType.SelectedIndex;
            model.Borrownum = 0;
            try
            {
                new BookBLL().Add(model);
                Common.CommonCode.ShowMessage(this.Page,"新增成功！");
                logger.Debug(Session["Name"].ToString()+"新增了"+model.BookName+"这一本书籍");
                Response.Redirect("BookManage.aspx");
            }
            catch (Exception ex) {
                Common.CommonCode.ShowMessage(this.Page,"新增失败！");
                logger.Debug(Session["Name"].ToString()+"新增"+model.BookName+"时失败！"+ex.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Book model = new Book();
            model.Id = Convert.ToInt32(txtID.Text);
            model.BookName = txtBName.Text;
            model.Type = ddlBType.SelectedValue;
            model.Author = txtAuthor.Text;
            model.ISBN = txtISBN.Text;
            model.PubName = txtPub.Text;
            model.Price = Convert.ToDecimal(txtPrice.Text);
            model.Page = Convert.ToInt32(txtPage.Text);
            model.BookCase = ddlBCase.SelectedValue;
            model.ContentDescription = txtContent.Text;
            model.TOC = txtTOC.Text;
            try
            {
                new BookBLL().Update(model);
                logger.Debug(Session["Name"].ToString()+"修改了名为"+model.BookName+"编号为："+model.Id+"这一本书");
                Common.CommonCode.ShowMessage(this.Page,"修改成功!");
                Response.Redirect("BookManage.aspx");
            }
            catch (Exception ex) {
                Common.CommonCode.ShowMessage(this.Page,"修改失败！");
                logger.Error(Session["Name"].ToString() + "修改" + model.BookName + "编号为：" + model.Id + "这一本书失败"+ex.Message);
            }
        }
    }
}