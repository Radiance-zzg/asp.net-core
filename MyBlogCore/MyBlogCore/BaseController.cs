using Blog.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogCore
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public  IStudentService _studentService { get; set; }
        //public BaseController(IStudentService studentService)
        //{
        //    _studentService = studentService;
        //}

        [HttpGet]
        public string GetTest()
        {
            
            
            
            return _studentService.GetTest();
        }
      
    }
}
