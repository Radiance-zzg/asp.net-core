using Blog.Core.Model;
using Blog.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogCore
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public IStudentService _studentService { get; set; }
        //public BaseController(IStudentService studentService)
        //{
        //    _studentService = studentService;
        //}
        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetTest()
        {

            return "QWE0";

            //return _studentService.GetTest();
        }
        [HttpPost]
        /// <summary>
        /// Post 请求
        /// </summary>
        /// <param name="model"></param>
        public void PostTest(TestModel model)
        {

        }

    }
}
