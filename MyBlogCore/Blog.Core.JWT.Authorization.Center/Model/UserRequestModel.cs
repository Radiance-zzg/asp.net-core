using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.JWT.Authorization.Center.Model
{
    /// <summary>
    /// 请求Model
    /// </summary>
    public class UserRequestModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string UserPassWord { get; set; }

    }
}
