using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public static class DateTimeExtension
    {

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

        /// <summary>
        /// 去除时分秒
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime ToShortDate(this DateTime dateTime)
        {
            return dateTime.ToShortDateString().ToDateTime();
        }
    }
}
