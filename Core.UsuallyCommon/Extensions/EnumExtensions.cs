using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    /// <summary>
    /// 枚举扩展
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// 获取枚举列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<EnumClass> GetEnumClasses<T>() where T : struct
        {
            List<EnumClass> list = new List<EnumClass>();
            try
            {
                foreach (int i in Enum.GetValues(typeof(T)))
                {
                    var name = Enum.GetName(typeof(T), i);
                    var key = i;

                    FieldInfo field = i.ToString().ToEnum<T>().GetType().GetField(name);

                    DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(System.ComponentModel.DescriptionAttribute)) as System.ComponentModel.DescriptionAttribute;

                    var description = attribute == null ? key.ToString() : attribute.Description;

                    list.Add(new EnumClass() { Key=i, Name= name,  Description = description});
                }
            }
            catch (Exception)
            {
                 
            }
            return list;
        }

        /// <summary>
        /// 获取枚举值或者枚举名称获取枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value) where T : struct
        {
            return ToEnum<T>(value, false);
        }

        /// <summary>
        /// 获取枚举值或者枚举名称获取枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(string value, bool ignoreCase) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enum type.");
            }

            var result = (T)Enum.Parse(typeof(T), value, ignoreCase);
            return result;
        }


        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }


        /// <summary>
        /// 枚举转List
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<string> EnumToList(this Type type)
        {
            List<string> list = new List<string>();
            foreach (int i in Enum.GetValues(type))
            {
                list.Add(Enum.GetName(type, i));
            }
            return list;
        }

        /// <summary>
        /// 枚举转换字典
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Dictionary<string, string> EnumToDictionaryReverse(this Type enumType)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            foreach (int i in Enum.GetValues(enumType))
            {
                list.Add(Enum.GetName(enumType, i), i.ToString());
            }
            return list;
        }

    }


    public class EnumClass
    {
        /// <summary>
        /// 枚举键
        /// </summary>
        public Int64 Key { get; set; }

        /// <summary>
        /// 枚举名字
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 枚举描述
        /// </summary>
        public String Description { get; set; }
    }
}
