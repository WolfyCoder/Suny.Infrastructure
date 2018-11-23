using System;
using System.Collections.Generic;
using System.Text;

namespace CNSuny.Infrastructure.Uitls
{
    /// <summary>
    /// 对象空值校验
    /// </summary>
    public class NullUtil
    {
        /// <summary>
        /// 对象null值检查，如果为null抛出异常ArgumentNullException
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        public static void ThrowIfNull<TObject>(TObject value, string name) where TObject : class
        {
            if (value == null)
            {
                throw new ArgumentNullException($"{name} is null");
            }

            if (string.IsNullOrWhiteSpace(value as string))
            {
                throw new ArgumentNullException($"{name} is Null or Empty or white-space.");
            }
        }
        /// <summary>
        /// 如果为空，返回一个新对象
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TObject ReturnEmptyInstanceIfNull<TObject>(TObject value) where TObject : class, new()
        {
            if (value == null)
            {
                return new TObject();
            }
            return value;
        }

        /// <summary>
        /// 如果是null,empty,white-space则返回空字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        public static string ReturnEmptyIfNullOrWhiteSpace(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }
            return value;
        }
    }
}
