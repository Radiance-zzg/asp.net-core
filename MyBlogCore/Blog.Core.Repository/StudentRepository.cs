using Blog.Core.Entities;
using Blog.Core.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repository
{
    public class StudentRepository : BaseRepositroy<Student>, IStudentRepostitory
    {

        //public StudentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        //{

        //}

        public string GetTest()
        {
         
            return "成功";
        }
    }
}
