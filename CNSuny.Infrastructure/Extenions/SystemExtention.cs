using CNSuny.Infrastructure.Uitls;
using Newtonsoft.Json;

namespace System
{
    /// <summary>
    /// 日期类型扩展
    /// </summary>
    public static class SystemExtention
    {
        /// <summary>
        /// 将时间类型转换为时间戳
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static long ToUnixTimeMilliseconds(this DateTime self)
        {
            return new DateTimeOffset(self).ToUnixTimeMilliseconds();
        }
        /// <summary>
        /// 将时间戳转换为时间
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static DateTime ToLocalDateTimeTime(this long self)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(self).DateTime;
        }
        /// <summary>
        /// 将对象转换为json
        /// </summary>
        /// <param name="input"></param>
        /// <param name="jsonSerializerSettings">序列化配置</param>
        /// <returns></returns>
        public static string ToJson(this object input, JsonSerializerSettings jsonSerializerSettings = null)
        {
            CheckUtil.ThrowIfNull(input, nameof(input));
            return JsonConvert.SerializeObject(input, jsonSerializerSettings);
        }
        /// <summary>
        /// 将字符串转换为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="jsonSerializerSettings"></param>
        /// <returns></returns>
        public static T ToEntity<T>(this string input, JsonSerializerSettings jsonSerializerSettings = null) where T : class, new()
        {
            CheckUtil.ThrowIfNullOrWhiteSpace(input, nameof(input));
            return JsonConvert.DeserializeObject<T>(input, jsonSerializerSettings);
        }
    }
}
