using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Security;

namespace LibraryManagerWebApiForWebChat.Authorize
{
    /// <summary>
    /// 自定义身份验证
    /// </summary>
   public class RequestAuthorizeAttribute: AuthorizeAttribute
    {
        /// <summary>
        /// 身份验证
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //从http请求的头里面获取身份验证信息，验证是否是请求发起方的ticket
            var authorization = actionContext.Request.Headers.Authorization;
            if ((authorization != null) && (authorization.Parameter != null))
            {
                //解密用户ticket,并校验用户名密码是否匹配
                var encryptTicket = authorization.Parameter;
                if (ValidateTicket(encryptTicket))
                {
                    base.IsAuthorized(actionContext);
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
            //如果取不到身份验证信息，并且不允许匿名访问，则返回未验证401
            else
            {
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if (isAnonymous) base.OnAuthorization(actionContext);
                else HandleUnauthorizedRequest(actionContext);
            }
        }

        private bool ValidateTicket(string encryptTicket)
        {
            //解密Ticket
            var strTicket = FormsAuthentication.Decrypt(encryptTicket).UserData; //存储在票据中的信息
            var isexired = FormsAuthentication.Decrypt(encryptTicket).Expired; //获取一个值判断票据是否过期（布尔类型）
            //从Ticket里面获取用户名和密码
          

            //var sysadminobject = Newtonsoft.Json.JsonConvert.DeserializeObject<EntityModel.SysAdmin>(strTicket);

            //var index = strTicket.IndexOf("&");
            //string strUser = strTicket.Substring(0, index);
            //string strPwd = strTick`et.Substring(index + 1);
            //if(DateTime.Now<time)
            //{
            if (isexired)
            {
                //SysAdmin objsysadmin = new SysAdmin
                //{
                //    AdminName = sysadminobject.AdminName,
                //    LoginPwd = sysadminobject.LoginPwd
                //};

                //SysAdmin sysadminobj = new BLL.SysAdmin.SysAdminBLL().SelectSysAdminInfo(DAL.SQLID.SysAdmin.SysAdmin.select_sysadmin, objsysadmin);

                //if (!string.IsNullOrEmpty(sysadminobj.AdminId.ToString()))
                //{
                //    return true;
                //}

                //else
                //{
                //    return false;
                //}
                return true;
                //如上红色部分所示的是根据票据中存储的信息去数据中查询
            }
            else
            {
                return false;
            }
        }
    }
}
