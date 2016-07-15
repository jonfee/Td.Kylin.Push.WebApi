using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Td.Common;
using Td.Diagnostics;
using Td.Kylin.EnumLibrary;
using Td.Kylin.WebApi;
using Td.Kylin.Push.Data.Context;
using Td.Web;

namespace Td.Kylin.Push.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // 启动应用程序。
            Application.Start(new ApplicationContext(env), null);

            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("config.json").AddEnvironmentVariables();

            Configuration = builder.Build();

            WebRootPath = env.WebRootPath;
        }

        /// <summary>
        /// 网站根路径
        /// </summary>
        public static string WebRootPath
        {
            get;
            private set;
        }

        /// <summary>
        /// 配置读取
        /// </summary>
        public static IConfigurationRoot Configuration
        {
            get;
            private set;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // 添加异常拦截处理程序。
            ExceptionHandlerManager.Instance.Handlers.Add(new UnknownExceptionHandler());

            // 添加全局异常过滤器。
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new Td.Web.Filters.HandleExceptionFilter());
                options.Filters.Add(new Td.Kylin.WebApi.Filters.HandleArgumentFilter());
            });

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var sqlType = new Func<SqlProviderType>(() =>
            {
                string sqltype = Configuration["Data:SqlType"] ?? string.Empty;

                switch (sqltype.ToLower())
                {
                    case "npgsql":
                        return SqlProviderType.NpgSQL;
                    case "mssql":
                    default:
                        return SqlProviderType.SqlServer;
                }
            }).Invoke();
            Config.apnsProduction = Converter.ConvertValue<bool>(Configuration["Data:Environment"]);
            var connectionString = Configuration["Data:DefaultConnection:ConnectionString"];
            app.UsePushDataContext(connectionString, sqlType);
            app.UseKylinWebApi(Configuration["ServerId"], connectionString, sqlType);

            // 注册推送提供程序。
            app.RegisterPushProvider(Configuration);

            //app.UseIISPlatformHandler();

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
