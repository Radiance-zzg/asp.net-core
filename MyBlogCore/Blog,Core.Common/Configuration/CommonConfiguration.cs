using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Core.Common.Configuration
{
    public class CommonConfiguration
    {
        private readonly IConfiguration _configuration;
        public CommonConfiguration()
        {
        }
        public CommonConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConnectionStr(string Name)
        {
            return _configuration.GetConnectionString(Name);
        }

    }
}
