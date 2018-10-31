using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNSuny.Core.Mongo
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public abstract class MongoContext
    {
        /// <summary>
        /// mongodb配置
        /// </summary>
        protected readonly MongoOptions MongoOptions;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mongoOptions"></param>
        public MongoContext(MongoOptions mongoOptions)
        {
            MongoOptions = mongoOptions;

        }
        /// <summary>
        /// 获取数据库
        /// </summary>
        protected IMongoDatabase DataBase => Client.GetDatabase(MongoOptions.DataBase);
        /// <summary>
        /// 获取mongo客户端
        /// </summary>
        protected IMongoClient Client => new MongoClient(MongoOptions.ConnectionString);
    }
}
