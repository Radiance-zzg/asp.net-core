using Blog.Core.JWT.Authorization.Center.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Core.JWT.Authorization.Center.Utility
{
    public interface IJWTService
    {
        public JWTModel GetToken(UserRequestModel user);
    }
}
