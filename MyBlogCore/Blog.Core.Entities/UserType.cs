using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Blog.Core.Entities
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("UserType")]
    public class UserType
    {
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="TypeName"    )]
         public string TypeName { get; set; }
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="Level"    )]
         public int Level { get; set; }
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="UserId"    )]
         public string UserId { get; set; }
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="Isdelete"    )]
         public bool? Isdelete { get; set; }
    }
}
