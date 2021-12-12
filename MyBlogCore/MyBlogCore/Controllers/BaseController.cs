using Blog.Core.Model;
using Blog.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace MyBlogCore
{
    [Route("api/Base")]
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
        
        public static IHostEnvironment _basehostEnvironment { get; set; }
        public BaseController(IHostEnvironment environment)
        {
            _basehostEnvironment = environment;
        }


    }
}
