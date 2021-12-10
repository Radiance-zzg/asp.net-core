using Blog.Core.JWT.Authorization.Center.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Blog.Core.JWT.Authorization.Center.Utility;

namespace Blog.Core.JWT.Authorization.Center.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class AuthorizationCenterController : Controller
    {
        private IJWTService _jWTService { get; }
        public AuthorizationCenterController(IJWTService jWTService)
        {
            _jWTService = jWTService;
        }
        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("GetToken")]
        public IActionResult GetToken(UserRequestModel user)
        {
            var result = _jWTService.GetToken(user);
            return Json(new { success = result.Success, msg = result.Success ? "获取Token成功" : "系统内部异常", data = result.Toekn });
        }

    }
}
