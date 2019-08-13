using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tools
{
    [NotMapped]
    /// <summary>
    /// 数据库
    /// </summary>
    public class DataBase : DataBaseAddress
    {
        /// <summary>
        /// 数据库名称
        /// </summary>
        public String DataBaseName { get; set; }

        /// <summary>
        /// 数据库描述
        /// </summary>
        public String DataBaseDescription { get; set; }

        /// <summary>
        /// 表集合
        /// </summary>
        public List<Table> Tables { get; set; }
    }
}
