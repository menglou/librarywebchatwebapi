using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryManagerWebChatForWebApi.Controllers
{
     
    public class BooksController : ApiController
    {
        [HttpPost]
        public string AddNewBooks()
        {
            return "添加成功";
        }
    }
}
