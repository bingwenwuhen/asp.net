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
    /// AddReader 的摘要说明
    /// </summary>
    public class AddReader : IHttpHandler, IRequiresSessionState
    {
        ILog logger = LogManager.GetLogger(typeof(AddReader));
        public void ProcessRequest(HttpContext context)
        {
            int ReaderNumber=Convert.ToInt32(context.Request["Readernumber"]);
            string Name=context.Request["Name"];
            int Number = Convert.ToInt32(context.Request["Number"]);
            UserRole model = new UserRole();
            model.Id = ReaderNumber;
            model.Name = Name;
            model.BookNumber = Number;
            try
            {
                int Add = new UserRoleBLL().Add(model);
                logger.Debug(context.Session["Name"].ToString()+"增加了"+model.Name+"这种类型的读者");
                context.Response.Write("ok");
            }
            catch (Exception ex) {
                logger.Error("出现错误"+ex.Message);
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