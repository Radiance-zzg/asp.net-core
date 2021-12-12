using Blog.Core.Entities;
using Blog.Core.Services.IServices;
using Blog.Core.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MyBlogCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogCore
{
    [AllowAnonymous]
    [Route("api/HomeCenter")]
    [ApiController]
    public class UserController : BaseController
    {
        private IHostEnvironment _Environment { get; set; }
        public IUserService _userService { get; set; }

        public UserController(IHostEnvironment host) : base(_basehostEnvironment)
        {
            _Environment = _basehostEnvironment;
        }
        #region 添加已测试
        /// <summary>
        /// 新增 已测试
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost, Route("AddUser")]
        public ReturnModel<bool> AddUser(User user)
        {
            var result = _userService.AddEntity(user);

            return new ReturnModel<bool> { Success = result, Msg = "" };
        }
        /// <summary>
        /// 新增 已测试
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost, Route("AddUserAsync")]
        public async Task<ReturnModel<bool>> AddUserAsync(User user)
        {
            var result = await _userService.AddEntityAsync(user);
            return new ReturnModel<bool> { Success = result, Msg = "" };
        }
        /// <summary>
        /// 批量新增 已测试
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [HttpPost, Route("BulkCopy")]
        public ReturnModel<bool> BulkCopy(List<User> entities)
        {
            var result = _userService.BulkCopy(entities);
            return new ReturnModel<bool> { Success = result, Msg = "" };
        }
        /// <summary>
        ///批量新增 已测试
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [HttpPost, Route("BulkCopyAsync")]
        public async Task<ReturnModel<bool>> BulkCopyAsync(List<User> entities)
        {
            var result = await _userService.BulkCopyAsync(entities);
            return new ReturnModel<bool> { Success = result, Msg = "" };
        }
        #endregion
        #region  删除已测试
        /// <summary>
        /// 根据实体删除 已测试
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("DeleteUser")]
        public ReturnModel<bool> DeleteUser()
        {
            var result = _userService.DeleteEntity(new User { Id = 25 });

            return new ReturnModel<bool> { Success = result, Msg = "" };
        }
        /// <summary>
        /// 根据表达式删除 已测试
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("DeleteUserByLambda")]
        public ReturnModel<bool> DeleteUserByLambda()
        {
            var result = _userService.DeleteEntityByWhere(x => x.Phone == "string");

            return new ReturnModel<bool> { Success = result, Msg = "" };
        }
        /// <summary>
        /// 根据表达式删除 已测试
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("DeleteBatchUser")]
        public ReturnModel<bool> DeleteBatchUser()
        {
            var result = _userService.DeleteEntityList(new List<User> { new User { Id = 19 }, new User { Id = 18 } });
            return new ReturnModel<bool> { Success = result, Msg = "" };
        }
        /// <summary>
        /// 根据Id逻辑删除 已测试
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("DeleteIsLogicEntityById")]
        public ReturnModel<bool> DeleteIsLogicEntityById()
        {
            var result = _userService.DeleteIsLogicEntityById(17);
            return new ReturnModel<bool> { Success = result, Msg = "" };
        }
        /// <summary>
        /// 根据表达式逻辑删除 已测试
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("DeleteIsLogicEntityByWhere")]
        public ReturnModel<bool> DeleteIsLogicEntityByWhere()
        {
            var result = _userService.DeleteIsLogicEntityByWhere(s => s.UserPwd == "1");
            return new ReturnModel<bool> { Success = result, Msg = "" };
        }

        #endregion
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("GetAllList")]
        public async Task<ReturnModel<List<User>>> GetAllList()
        {
            var result = await _userService.GetAllListAsync();
            return new ReturnModel<List<User>> { Success = true, Data = result };
        }
        /// <summary>
        /// 根据表达式获取
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("GetListByWhreAsync")]
        public async Task<ReturnModel<List<User>>> GetListByWhreAsync()
        {
            var result = await _userService.GetListByWhreAsync(S => S.IsDelete == true);
            return new ReturnModel<List<User>> { Success = true, Data = result };
        }
        /// <summary>
        /// 分页获取
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("GetListByWhreAsync")]
        public async Task<ReturnModel<List<User>>> GetListByWhreAsync()
        {
            var result = await _userService.GetPageAsync(1, 2, null, null);
            return new ReturnModel<List<User>> { Success = true, Data = result };
        }
    }
}
