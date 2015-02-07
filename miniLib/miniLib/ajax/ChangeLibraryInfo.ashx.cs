using log4net;
using miniLib.BLL;
using miniLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace miniLib.ajax
{
    /// <summary>
    /// ChangeLibraryInfo 的摘要说明
    /// </summary>
    public class ChangeLibraryInfo : IHttpHandler, IRequiresSessionState
    {
        ILog logger = LogManager.GetLogger(typeof(ChangeLibraryInfo));
        public void ProcessRequest(HttpContext context)
        {
            string LibraryName = context.Request["LibraryName"];
            string txtCurator = context.Request["txtCurator"];
            string txtTel=context.Request["txtTel"];
            string txtEmail=context.Request["txtEmail"];
            string txtAddress=context.Request["txtAddress"];
            string txtUrl=context.Request["txtUrl"];
            DateTime txtCDate = Convert.ToDateTime(context.Request["txtCDate"]);
            string txtIntroduce=context.Request["txtIntroduce"];
            Library model = new Library();
            model.LName = LibraryName;
            model.LCurator = txtCurator;
            model.LEmail = txtEmail;
            model.LPhone = txtTel;
            model.LAddress = txtAddress;
            model.LSite = txtUrl;
            model.LCreateTime = txtCDate;
            model.LIntroduce = txtIntroduce;
            try {
               new LibraryBLL().Update(model);
               context.Response.Write("ok");
               logger.Debug(context.Session["Name"].ToString()+"修改了图书馆信息！");
            }
            catch (Exception ex) {
                logger.Error(context.Session["Name"].ToString()+"修改图书馆信息时发生了错误:"+ex.Message);
                context.Response.Write("no-ok");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}