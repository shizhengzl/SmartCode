using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tools.Migrations
{
    public class DataTypeConfig
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Int32 Id { get; set; }
        /// <summary>
        /// SQLServer类型
        /// </summary>
        public string SQLServerType { get; set; }
        /// <summary>
        /// MySql类型
        /// </summary>
        public string MySqlType { get; set; }
        /// <summary>
        /// Oracle类型
        /// </summary>
        public string OracleType { get; set; }
        /// <summary>
        /// SQLite类型
        /// </summary>
        public string SQLiteType { get; set; }
        /// <summary>
        /// Cshapr类型
        /// </summary>
        public string CSharpType { get; set; }

        /// <summary>
        /// SQLDBType
        /// </summary>
        public string SQLDBType { get; set; }


    }
}
