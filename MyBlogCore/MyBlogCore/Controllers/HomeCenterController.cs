using Blog.Core.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogCore
{
    [Route("api/HomeCenter")]
    [ApiController]
    [AllowAnonymous]
    public class HomeCenterController : BaseController
    {
        private IHostEnvironment _Environment { get; set; }
        public UserService _userService { get; set; }
        public HomeCenterController(IHostEnvironment host) : base(_basehostEnvironment)
        {
            _Environment = _basehostEnvironment;
        }
        /// <summary> 
        /// 测试授权
        /// </summary>
        [HttpGet, Route("Getauth")]
        public string Getauth()
        {
            return "成功";
        }
    }
}
