using Blog.Core.Entities;
using Blog.Core.Model.ViewModel;
using Blog.Core.Repository.Base;
using Blog.Core.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repository.Repository
{
    public class UserRepository : BaseRepositroy<User>, IUserRepostirory
    {

        public List<ViewUser> GetUser()
        {
            //var query = Db.Queryable<User>()
            //            .LeftJoin<UserType>((u, t) => u.Id.ToString() == t.UserId)
            //            .LeftJoin<Department>((u, t, d) => u.DepartmentId == d.Id)
            //            .Select((u, t) => new ViewUser { Name = u.UserName, Phone = u.Phone, Level = t.Level }).ToPageListAsync(1, 1,);
            return new List<ViewUser>();
        }
    }
}
