using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNSuny.Authorization.WeiXin;
using CNSuny.Core.Mongo;
using CNSuny.Infrastructure.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebCore.Test
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddWeiXinAuthorization((options) =>
            {
                var weiXinOptions = Configuration.GetValue<WeiXinOptions>("WeiXinOptions");
                options.AppId = weiXinOptions.AppId;
                options.Secret = weiXinOptions.Secret;
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions((options) =>
            {

                options.SerializerSettings.Converters.Add(new UnixTimeMillisecondsConverter());
            });
            //注册Mongo
            services.Configure<MongoOptions>(Configuration.GetSection("MongoOptions"));
            services.AddCNSunyMongoContext<TestContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=values}/{action=get}/{id?}");
            });
        }
    }
}
