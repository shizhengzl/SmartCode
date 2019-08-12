using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tools
{
    public class DefaultColumns
    {
        /// <summary>
        /// 列名称
        /// </summary>
        public String ColumnName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public String Description { get; set; }

        public String DataType { get; set; }


        public Int64 MaxLength { get; set; }
    }
}
