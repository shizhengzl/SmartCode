using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    /// <summary>
    /// 属性扩展
    /// </summary>
    public static class PropertyExtension
    {
        /// <summary>
        /// 获取对象所有属性
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static List<String> GetPropertyList(this object objects)
        {
            PropertyInfo[] propertys = objects.GetType().GetProperties();

            return propertys.Select(x => x.Name).ToList<string>();
        }

        /// <summary>
        /// 根据属性名称设置属性值
        /// </summary>
        /// <param name="instance">设置对象</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="value">要设置的值</param>
        public static void SetPropertyValue(this object instance, string propertyName, object value)
        {
            var propertyInfos = instance.GetType().GetProperties().ToList();
            var property = (propertyInfos.FirstOrDefault(x => x.Name == propertyName));
            if (property != null)
            {
                if (IsNullableType(property.PropertyType))
                    property.SetValue(instance, value, null);
                else
                    property.SetValue(instance, Convert.ChangeType(value, property.PropertyType), null);
            } 
        }

        /// <summary>
        /// 判定是否为可空类型
        /// </summary>
        /// <param name="type">属性类型</param>
        /// <returns></returns>
        private static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }
    }
}
