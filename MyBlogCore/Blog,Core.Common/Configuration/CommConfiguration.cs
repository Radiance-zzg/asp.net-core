using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Core.Common.Configuration
{
    public class CommConfiguration
    {

        public static IConfiguration _configuration { get; set; }
        //public CommConfiguration(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public static string GetConnetionStr(string NodeName)
        {
            return _configuration.GetConnectionString(NodeName);
        }
    }
}
