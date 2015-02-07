using log4net;
using miniLib.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace miniLib.ajax
{
    /// <summary>
    /// AddCategory 的摘要说明
    /// </summary>
    public class AddCategory : IHttpHandler, IRequiresSessionState
    {
        ILog  logger=LogManager.GetLogger(typeof(AddCategory));
        public void ProcessRequest(HttpContext context)
        {
            miniLib.Model.Category model=new Model.Category();
            model.Id=Convert.ToInt32(context.Request["number"]);
            model.Name=context.Request["name"];
            try{
                new CategoryBLL().Add(model);
                logger.Debug(context.Session["Name"].ToString()+"新增了"+model.Name+"这种图书类型");
                context.Response.Write("ok");
            }catch(Exception ex){
                logger.Error(context.Session["Name"].ToString()+"新增"+model.Name+"出错"+ex.Message);
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