using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibraryManagerWebApiForWebChat.Authorize;
using LibraryManagerWebApiForWebChat.Base;
using Entity;
using BLL;
using Common;

namespace LibraryManagerWebApiForWebChat.Controllers
{

    /// <summary>
    /// 图书模块
    /// </summary>
    [RequestAuthorize]
    public class BooksController :ApiController
    {
        /// <summary>
        /// 添加图书
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string AddNewBook(Books book)
        {
            JsonResultData<string> jsonresult = new JsonResultData<string>();

            int result = new BLL.BookBLL().AddNewBook(book);

            if(result==1)
            {
                jsonresult.Code = 1;
                jsonresult.Msg = "添加成功";
            }
            else
            {
                jsonresult.Code = -1;
                jsonresult.Msg = "添加失败";
            }

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(jsonresult);

            return json;
        }

        /// <summary>
        /// 更改图书信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string UpdateBookInfo(Books book)
        {
            JsonResultData<string> jsonresult = new JsonResultData<string>();

            int result = new BLL.BookBLL().UpdateBookInfo(book);

            if (result == 1)
            {
                jsonresult.Code = 1;
                jsonresult.Msg = "更改成功";
            }
            else
            {
                jsonresult.Code = -1;
                jsonresult.Msg = "更改失败";
            }

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(jsonresult);

            return json;
        }
    }
}
