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
    }
}
