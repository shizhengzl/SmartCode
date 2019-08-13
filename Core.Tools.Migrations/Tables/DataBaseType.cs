using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tools
{
    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DataBaseType
    {
        [Description("SQLServer")]
        SQLServer = 1,
        [Description("MySQL")]
        MySQL = 2,
        [Description("SQLite")]
        SQLite =3
    }
}
