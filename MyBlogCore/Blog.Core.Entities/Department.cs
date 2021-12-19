using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Blog.Core.Entities
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("Department")]
    public class Department
    {
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true ,IsIdentity = true  )]
         public int Id { get; set; }
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="DepartmentName"    )]
         public string DepartmentName { get; set; }
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="DepartmentCode"    )]
         public string DepartmentCode { get; set; }
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="Parent"    )]
         public int? Parent { get; set; }
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="Isdelete"    )]
         public bool? Isdelete { get; set; }
    }
}
