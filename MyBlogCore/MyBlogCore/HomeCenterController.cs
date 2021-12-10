using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogCore
{
    [Route("api/HomeCenter")]
    [ApiController]
    public class HomeCenterController : BaseController
    {
        /// <summary>
        /// 测试授权
        /// </summary>
        [Authorize]
        [HttpGet,Route("Getauth")   ]
        public string Getauth()
        {
            return "成功";
        }
    }
}
