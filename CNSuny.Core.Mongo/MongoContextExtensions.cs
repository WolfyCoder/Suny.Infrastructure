using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNSuny.Core.Mongo
{
    /// <summary>
    /// mongo 扩展
    /// </summary>
    public static class MongoContextExtensions
    {
        /// <summary>
        /// 注册MongoContext服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        public static void AddCNSunyMongoContext<T>(this IServiceCollection services) where T : MongoContext
        {
            services.AddSingleton<T>();
        }
    }
}
