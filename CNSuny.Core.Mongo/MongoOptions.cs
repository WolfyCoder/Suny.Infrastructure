using System;
using System.Collections.Generic;
using System.Text;

namespace CNSuny.Core.Mongo
{
    /// <summary>
    /// mongo数据库配置
    /// </summary>
    public class MongoOptions
    {
        /// <summary>
        /// mongo数据库连接字符串
        /// </summary>
        public string MongoConnectionString { set; get; }
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DBName { set; get; }
    }
}
