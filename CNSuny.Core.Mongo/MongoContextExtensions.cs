using Microsoft.Extensions.DependencyInjection;

namespace CNSuny.Core.Mongo
{
    /// <summary>
    /// mongdb 扩展
    /// </summary>
    public static class MongoContextExtensions
    {
        /// <summary>
        /// IServiceCollection扩展注册mongodb单利服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        public static void AddCNSunyMongoContext<T>(this IServiceCollection services) where T : MongoContext
        {
            services.AddSingleton<T>();
        }
    }
}
