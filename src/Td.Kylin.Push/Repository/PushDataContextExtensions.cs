using System;
using Microsoft.AspNetCore.Builder;
using Td.Kylin.EnumLibrary;

namespace Td.Kylin.Push.Data.Context
{
    /// <summary>
    /// 推送数据上下文服务生成器
    /// </summary>
    public static class PushDataContextExtensions
    {
        public static void Factory(string connectionString, SqlProviderType sqlType)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            ConfigRoot.SqlConnctionString = connectionString;
            ConfigRoot.SqlType = sqlType;
        }
    }
}
