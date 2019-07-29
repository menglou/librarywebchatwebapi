using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibraryManagerWebApiForWebChat.Authorize;

namespace LibraryManagerWebApiForWebChat.Controllers
{
    /// <summary>
    /// 图书模块
    /// </summary>
    public class BooksController : ApiController
    {
        /// <summary>
        /// 添加图书
        /// </summary>
        /// <returns></returns>
        [RequestAuthorize]
        [HttpPost]
        public string AddNewBook()
        {
            return "添加成功";
        }
    }
}
