using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    /// <summary>
    /// Csharp数据类型转换扩展
    /// </summary>
    public static class CsharpDataTypeExtension
    {
        /// <summary>
        /// 字符串扩展方法
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static string ToStringExtension(this object objects)
        {
            string result = string.Empty;
            if (objects != null)
                result = objects.ToString();
            return result;
        }

        /// <summary>
        /// Int16扩展方法
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static Int16 ToInt16(this object objects)
        {
            Int16 result = 0;
            if (objects == null)
                return result;
            Int16.TryParse(objects.ToStringExtension(), out result);
            return result;
        }

        /// <summary>
        /// Int32扩展方法
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static Int32 ToInt32(this object objects)
        {
            Int32 result = 0;
            if (objects == null)
                return result;
            Int32.TryParse(objects.ToStringExtension(), out result);
            return result;
        }


        /// <summary>
        /// Int64扩展方法
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static Int64 ToInt64(this object objects)
        {
            Int64 result = 0;
            if (objects == null)
                return result;
            Int64.TryParse(objects.ToStringExtension(), out result);
            return result;
        }

        /// <summary>
        /// Boolean扩展方法
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static bool ToBoolean(this object objects)
        {
            bool result = false;
            if (objects == null)
                return result;
            bool.TryParse(objects.ToStringExtension(), out result);
            return result;
        }

        /// <summary>
        /// Decimal扩展方法
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static Decimal ToDecimal(this object objects)
        {
            Decimal result = 0;
            if (objects != null)
                Decimal.TryParse(objects.ToString(), out result);
            return result;
        }

        /// <summary>
        /// DateTime扩展方法
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object objects)
        {
            DateTime result = DateTime.MaxValue;
            if (objects != null)
                DateTime.TryParse(objects.ToString(), out result);
            return result;
        }
    }
}
