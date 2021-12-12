using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogCore.Model
{
    public class ReturnModel<T>
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 返回数据类型
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// 自定义code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        public string Msg { get; set; }
    }
}
