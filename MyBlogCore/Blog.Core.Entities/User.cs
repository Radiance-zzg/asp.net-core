using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Blog.Core.Entities
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("User")]
    public class User
    {
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true ,IsIdentity = true  )]
         public int Id { get; set; }
        /// <summary>
        /// 用户名
        ///</summary>
         [SugarColumn(ColumnName="UserName"    )]
         public string UserName { get; set; }
        /// <summary>
        ///  密码
        ///</summary>
         [SugarColumn(ColumnName="UserPwd"    )]
         public string UserPwd { get; set; }
        /// <summary>
        ///  手机号
        ///</summary>
         [SugarColumn(ColumnName="Phone"    )]
         public string Phone { get; set; }
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="IsDelete"    )]
         public bool IsDelete { get; set; }
    }
}
