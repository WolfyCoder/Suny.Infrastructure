using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNSuny.Authorization.WeiXin
{
    /// <summary>
    /// 微信第三方登陆服务扩展
    /// </summary>
    public static class WeinXinServiceExtention
    {
        /// <summary>
        /// IServiceCollection扩展注册mongodb单利服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        public static void AddWeiXinAuthorization(this IServiceCollection services, Action<WeiXinOptions> options)
        {
            services.AddSingleton<WeiXinHttpClient>();
        }
    }
}
