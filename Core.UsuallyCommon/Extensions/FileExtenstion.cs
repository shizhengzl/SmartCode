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
            return File.ReadAllText(Paht, Encoding.Default);
        }

        /// <summary>  
        /// 向文本文件中写入内容  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>  
        /// <param name="content">写入的内容</param>          
        public static void WriteText(this string filePath, string content)
        {
            //向文件写入内容  
            File.WriteAllText(filePath, content,Encoding.Default);
        }
    }
}
