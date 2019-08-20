using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tools.Migrations.Tables
{

    /// <summary>
    /// 模板管理
    /// </summary>
    public class Snippet
    {
        [Key]
        public Int32 Id { get; set; }

        /// <summary>
        /// 模板名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        public Int32 ParentId { get; set; }
        /// <summary>
        /// 模板内容
        /// </summary>
        public string Context { get; set; }
        /// <summary>
        /// 生成路劲
        /// </summary>
        public string OutputPath { get; set; }
        /// <summary>
        /// 生成文件名
        /// </summary>
        public string GeneratorFileName { get; set; }
        /// <summary>
        /// 是否是文件夹
        /// </summary>
        public bool IsFloder { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// 是否合并
        /// </summary>
        public bool IsMergin { get; set; }
        /// <summary>
        /// 是否自动查找
        /// </summary>
        public bool IsAutoFind { get; set; }
        /// <summary>
        /// 是否选择生成
        /// </summary>
        public bool IsSelectGenerator { get; set; }
        /// <summary>
        /// 是否追加生成
        /// </summary>
        public bool IsAppendSnippet { get; set; }
    }
}
