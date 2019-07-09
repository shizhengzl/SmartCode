using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.UsuallyCommon;

namespace Core.Tools.LangaugeParser
{
    /// <summary>
    /// Csharp 字符串识别
    /// </summary>
    public class CsharpParser
    {
        /// <summary>
        /// 根据路劲
        /// </summary>
        /// <param name="Path"></param>
        public CsharpParser(string Path)
        {
            var context = Path.GetFileContext();
        }
    }
}
