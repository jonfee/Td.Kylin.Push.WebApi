using System;
using System.IO;
using Td.Kylin.Push.WebApi.JPushProvider;

namespace Td.Kylin.Push.WebApi.Core
{
    /// <summary>
    /// 配置文件
    /// </summary>
    public class Configs
    {
        /// <summary>
        /// 服务区号
        /// </summary>
        public static uint District
        {
            get
            {
                return uint.Parse(Startup.Configuration["District"]);
            }
        }

        /// <summary>
        /// 平台号
        /// </summary>
        public static uint Platform
        {
            get
            {
                return uint.Parse(Startup.Configuration["Platform"]);
            }
        }

        /// <summary>
        /// 错误日志的文件地址
        /// </summary>
        public static string ErrorLogFilePath
        {
            get
            {
                string folder = Startup.Configuration["ErrorLogFolder"];

                return Path.Combine(folder, DateTime.Now.ToString("yyyy"));
            }
        }

        #region 极光推送API各APP端配置
        public static class JPushConfigs
        {
            /// <summary>
            /// 用户端极光接口API配置
            /// </summary>
            public static JPushConfig UserJPushConfig
            {
                get
                {
                    return new JPushConfig
                    {
                        Key = Startup.Configuration["JPush:UserClient:ApiKey"],
                        Secret = Startup.Configuration["JPush:UserClient:ApiSecret"]
                    };
                }
            }

            /// <summary>
            /// 商户端极光接口API配置
            /// </summary>
            public static JPushConfig MerchantJPushConfig
            {
                get
                {
                    return new JPushConfig
                    {
                        Key = Startup.Configuration["JPush:MerchantClient:ApiKey"],
                        Secret = Startup.Configuration["JPush:MerchantClient:ApiSecret"]
                    };
                }
            }

            /// <summary>
            /// 员工端极光接口API配置
            /// </summary>
            public static JPushConfig WorkerJPushConfig
            {
                get
                {
                    return new JPushConfig
                    {
                        Key = Startup.Configuration["JPush:WorkerClient:ApiKey"],
                        Secret = Startup.Configuration["JPush:WorkerClient:ApiSecret"]
                    };
                }
            }
        }
        #endregion
    }
}
