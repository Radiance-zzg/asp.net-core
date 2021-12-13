using Blog.Core.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repository.IRepository
{
    public interface IUserRepostirory
    {
        public List<ViewUser> GetUser();

    }
}
