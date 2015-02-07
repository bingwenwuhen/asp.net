using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace miniLib.Common
{
    public class CommonCode
    {
        /// <summary>
        /// 前台响应message函数
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        public static void ShowMessage(System.Web.UI.Page page, string msg) {
            //msg.Replace("\"","");
            //msg.Replace("'", "");
            //msg.Replace("\r","");
            //msg.Replace("\n","");
            //第一：对msg的内容进行过滤特殊字符如："\r,\n
            //第二：向前端加一个脚本
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), Guid.NewGuid().ToString(), "alert('" + msg + "')", true);
        }

        /// <summary>
        /// 向前端写script脚本
        /// </summary>
        /// <param name="page"></param>
        /// <param name="script"></param>
        public static void ScriptWrite(System.Web.UI.Page page, string script) {
            page.ClientScript.RegisterClientScriptBlock(page.GetType(),Guid.NewGuid().ToString(),script,true);
        }

        /// <summary>
        /// 将得到的密码进行MD5加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetMD5( string input) {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            StringBuilder s = new StringBuilder();
            foreach (byte b in bs) {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        } 
    }
}