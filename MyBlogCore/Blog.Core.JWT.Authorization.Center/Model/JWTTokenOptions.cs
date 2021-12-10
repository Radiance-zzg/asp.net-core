using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Core.JWT.Authorization.Center.Model
{
    public class JWTTokenOptions
    {
        public string Audience { get; set; }
        public string IisUer { get; set; }
        public string SecretKey { get; set; }
    }
}
