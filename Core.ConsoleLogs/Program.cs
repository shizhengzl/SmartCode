using Core.UsuallyCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ConsoleLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = EnumExtensions.GetEnumClasses<AuditStatus>();

            var b = "1".ToEnum<AuditStatus>();
            var c = b.GetDescription();
        }
    }
}
