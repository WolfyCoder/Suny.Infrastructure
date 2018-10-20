using MongoDB.Driver;
namespace CNSuny.Core.Mongo
{
    /// <summary>
    /// .Net Core Mongo数据库上下文
    /// </summary>
    public abstract class MongoContext
    {
        /// <summary>
        /// 数据库配置信息
        /// </summary>
        protected readonly MongoOptions _mongoOptions;
        /// <summary>
        /// 数据库
        /// </summary>
        protected IMongoDatabase DB { get; }
        /// <summary>
        /// mongo客户端
        /// </summary>
        protected IMongoClient Client { get; }
        /// <summary>
        /// 初始化mongo客户端
        /// </summary>
        /// <param name="mongoOptions"></param>
        public MongoContext(MongoOptions mongoOptions)
        {
            _mongoOptions = mongoOptions;
            Client = new MongoClient(_mongoOptions.MongoConnectionString);
            DB = Client.GetDatabase(_mongoOptions.DBName);
        }

    }
}
