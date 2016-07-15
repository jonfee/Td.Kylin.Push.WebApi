using System;
using Microsoft.AspNetCore.Builder;
using Td.Kylin.EnumLibrary;

namespace Td.Kylin.Push.Data.Context
{
    /// <summary>
    /// 注册PostgreSql
    /// </summary>
    public static class DataContextInjection
    {
        public static IApplicationBuilder UsePushDataContext(this IApplicationBuilder builder, string connectionString, SqlProviderType sqlType)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.Use(next => new MicroMallDataContextMiddleware(next, connectionString, sqlType).Invoke);
        }
    }
}
