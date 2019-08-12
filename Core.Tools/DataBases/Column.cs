using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tools
{
    /// <summary>
    /// 列
    /// </summary>
    public class Column : Table
    {
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 列描述
        /// </summary>
        public string ColumnDescription { get; set; }
        /// <summary>
        /// Csharp类型
        /// </summary>
        public string CSharpType { get; set; }
        /// <summary>
        /// 是否自增
        /// </summary>
        public bool IsIdentity { get; set; }
        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsPrimarykey { get; set; }
        /// <summary>
        /// 长度
        /// </summary>
        public int? MaxLength { get; set; }
        /// <summary>
        /// 是否必填
        /// </summary>
        public bool IsRequire { get; set; }
        /// <summary>
        /// 长度
        /// </summary>
        public byte Scale { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public string SQLType { get; set; }
    }
}
