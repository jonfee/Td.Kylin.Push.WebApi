using Microsoft.AspNet.Builder;
using System;
using Td.Kylin.EnumLibrary;

namespace Td.Kylin.Push.Data.Context
{
    /// <summary>
    /// 注册PostgreSql
    /// </summary>
    public static class DataContextInjection
    {
        public static IApplicationBuilder UseMicroMallDataContext(this IApplicationBuilder builder, string connectionString, SqlProviderType sqlType)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.Use(next => new MicroMallDataContextMiddleware(next, connectionString, sqlType).Invoke);
        }
    }
}
