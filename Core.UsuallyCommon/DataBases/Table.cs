﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    /// <summary>
    /// 表
    /// </summary>
    public class Table : DataBase
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 表描述
        /// </summary>
        public string TableDescription { get; set; }

        /// <summary>
        /// 列集合
        /// </summary>
        public List<Column> ListColumn { get; set; }
    }
}
