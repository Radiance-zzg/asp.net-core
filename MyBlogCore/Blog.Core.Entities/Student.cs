using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{

    /// <summary>
    /// 
    ///</summary>
    [SugarTable("Student")]
    public class Student
    {
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "ID", IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "StudentName")]
        public string StudentName { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "IDCard")]
        public string IDCard { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "Sex")]
        public bool? Sex { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "BirthDay")]
        public DateTime? BirthDay { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "UserPic")]
        public string UserPic { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "NativePlace")]
        public int? NativePlace { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "Education")]
        public int Education { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "WorkAge")]
        public int? WorkAge { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "IntoDate")]
        public DateTime? IntoDate { get; set; }
        /// <summary>
        /// 工作单位 
        ///</summary>
        [SugarColumn(ColumnName = "WorkUnit")]
        public string WorkUnit { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "UpdateTime")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "Email")]
        public string Email { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "PhoneNum")]
        public string PhoneNum { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "Occupation")]
        public string Occupation { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "DataSource")]
        public int? DataSource { get; set; }

    }
}
