using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public static class StringHelper
    {
        /// <summary>
        /// 生成订单号
        /// </summary>
        /// <param name="prefix">前缀</param>
        /// <param name="length">随机字符长度</param>
        /// <param name="format">日期格式化</param>
        /// <returns></returns>
        public static string GetOrderNumber(string prefix,int length,string format ="yyyymmddHHmm")
        {
            return $"{prefix}{DateTime.Now.ToString(format)}{GetRandomNumber(length)}";
        }

        /// <summary>
        /// 生成订单号
        /// </summary>
        /// <param name="prefix">前缀</param>
        /// <param name="length">随机字符长度</param>
        /// <param name="format">日期格式化</param>
        /// <returns></returns>
        public static string GetOrderString(string prefix, int length, string format = "yyyymmddHHmm")
        {
            return $"{prefix}{DateTime.Now.ToString(format)}{GetRandomString(length)}";
        }


        // <summary>
        /// 生成n位随机数
        /// </summary>
        /// <param name="length">随机字符长度</param>
        /// <returns>随机生成字符串</returns>
        public static string GetRandomNumber(int length)
        {
            string codes = "0123456789";
            string reValue = string.Empty;
            Random rd = new Random();
            while (reValue.Length < length)
            {
                string first = codes[rd.Next(0, codes.Length)].ToStringExtension();
                if (reValue.IndexOf(first) == -1)
                    reValue += first;
            }
            return reValue;
        }

        // <summary>
        /// 生成6位随机字符
        /// </summary>
        /// <param name="length">随机字符长度</param>
        /// <returns>随机生成字符串</returns>
        public static string GetRandomString(int length)
        {
            string codes = "0123456789abcdefghijklmnpqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ";
            string reValue = string.Empty;
            Random rd = new Random();
            while (reValue.Length < length)
            {
                string first = codes[rd.Next(0, codes.Length)].ToStringExtension();
                if (reValue.IndexOf(first) == -1)
                    reValue += first;
            }
            return reValue;
        }

    }
}
