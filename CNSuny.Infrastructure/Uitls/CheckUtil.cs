using System;
using System.Collections.Generic;
using System.Text;

namespace CNSuny.Infrastructure.Uitls
{
    /// <summary>
    /// 对象空值校验
    /// </summary>
    public class CheckUtil
    {
        /// <summary>
        /// 对象null值检查，如果为null抛出异常ArgumentNullException
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        public static void ThrowIfNull(object value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"{name} is null");
            }
        }

        /// <summary>
        /// 如果是null,empty,white-space则抛出异常ArgumentNullException
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        public static void ThrowIfNullOrWhiteSpace(string value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException($"{name} is Null or Empty or white-space.");
            }
        }
        /// <summary>
        /// 如果是null,empty,white-space则返回空字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        public static string ReturnEmptyIfNullOrWhiteSpace(string value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }
            return value;
        }
    }
}
