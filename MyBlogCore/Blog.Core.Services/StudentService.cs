using Blog.Core.Entities;
using Blog.Core.Repository;
using Blog.Core.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        public  StudentRepository studentRepostitory { get; set; }
        public string GetTest()
        {
            var resul = studentRepostitory.AddEntity(new Student { StudentName = "SqlSuger", IDCard = "test", UserPic = "test" });
            return studentRepostitory.GetTest();
        }
    }
}
