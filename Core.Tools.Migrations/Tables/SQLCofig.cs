using Core.UsuallyCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 


namespace Core.Tools
{
    /// <summary>
    /// 数据库配置累
    /// </summary>
    public class SQLConfig
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Int32 Id { get; set; }

        /// <summary>
        /// 数据库类别
        /// </summary>
        public DataBaseType Type { get; set; }

        /// <summary>
        /// 获取数据库SQL
        /// </summary>
        public string GetDataBaseSQL { get; set; }

        /// <summary>
        /// 获取表SQL
        /// </summary>
        public string GetTableSQL { get; set; }

        /// <summary>
        /// 获取列SQL
        /// </summary>
        public string GetColumnSQL { get; set; }

        /// <summary>
        /// 获取存储过程SQL
        /// </summary>
        public string GetProducuteSQL { get; set; }

        /// <summary>
        /// 获取视图SQL
        /// </summary>

        public string GetViewSQL { get; set; }

        /// <summary>
        /// 获取索引SQL
        /// </summary>

        public string GetIndexSQL { get; set; }

        /// <summary>
        /// 获取同义词SQL
        /// </summary>

        public string GetSYNONYMSQL { get; set; }
         
    }
}
