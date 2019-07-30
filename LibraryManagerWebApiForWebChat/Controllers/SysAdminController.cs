using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entity;
using BLL;
using System.Web.Security;

namespace LibraryManagerWebApiForWebChat.Controllers
{
    /// <summary>
    /// 用户登录模块
    /// </summary>
    public class SysAdminController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        public string SysAdminLogin(Entity.SysAdmin sysadmin)
        {
            Common.JsonResultData<string> jsonresult = new Common.JsonResultData<string>();

            SysAdmin admininfo = new BLL.SysAdminBLL().Login(sysadmin);

            if(admininfo==null)
            {
               
                jsonresult.Code = -1;
                jsonresult.Msg = "登录失败";

                return Newtonsoft.Json.JsonConvert.SerializeObject(jsonresult);
            }
            else
            {
                string jsonsysadmin = Newtonsoft.Json.JsonConvert.SerializeObject(admininfo);

                FormsAuthenticationTicket usertick = new FormsAuthenticationTicket(0, sysadmin.AdminId.ToString(), DateTime.Now, DateTime.Now.AddHours(1.0), false, jsonsysadmin, FormsAuthentication.FormsCookiePath);

                jsonresult.Code = 1;
                jsonresult.Msg = "登录成功";

                jsonresult.Data = FormsAuthentication.Encrypt(usertick);

                return Newtonsoft.Json.JsonConvert.SerializeObject(jsonresult);
            }
        }
    }
}
