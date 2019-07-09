using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    /// <summary>
    /// 文件操作类
    /// </summary>
    public static class FileExtenstion
    {
        /// <summary>
        /// 根据路劲获取文件内容
        /// </summary>
        /// <param name="Paht">路劲</param>
        /// <returns></returns>
        public static string GetFileContext(this string Paht)
        {
            return File.ReadAllText(Paht, Encoding.UTF8);
        }
    }
}
