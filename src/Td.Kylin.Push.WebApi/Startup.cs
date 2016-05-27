using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Td.Diagnostics;
using Td.Kylin.EnumLibrary;
using Td.Kylin.WebApi;
using Td.Web;

namespace Td.Kylin.Push.WebApi
{
	public class Startup
	{
		public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
		{
			// 启动应用程序。
            Application.Start(new ApplicationContext(env, appEnv), null);

			var builder = new ConfigurationBuilder().AddJsonFile("config.json").AddEnvironmentVariables();

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

				switch(sqltype.ToLower())
				{
					case "npgsql":
						return SqlProviderType.NpgSQL;
					case "mssql":
					default:
						return SqlProviderType.SqlServer;
				}
			}).Invoke();

			var connectionString = Configuration["Data:DefaultConnection:ConnectionString"];

			app.UseKylinWebApi(Configuration["ServerId"], connectionString, sqlType);

			// 注册推送提供程序。
			app.RegisterPushProvider(Configuration);

			app.UseIISPlatformHandler();

			app.UseStaticFiles();

			app.UseMvc();
		}

		// Entry point for the application.
		public static void Main(string[] args) => WebApplication.Run<Startup>(args);
	}
}