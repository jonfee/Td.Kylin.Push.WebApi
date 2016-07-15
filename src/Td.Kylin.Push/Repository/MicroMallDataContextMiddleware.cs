
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Td.Kylin.EnumLibrary;

namespace Td.Kylin.Push.Data.Context
{
    internal sealed class MicroMallDataContextMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _connectionString;
        private readonly SqlProviderType _sqlType;

        public MicroMallDataContextMiddleware(RequestDelegate next, string connectionString,SqlProviderType sqlType)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(next));
            }
            _connectionString = connectionString;
            _sqlType = sqlType;
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            ConfigRoot.SqlConnctionString = _connectionString;
            ConfigRoot.SqlType = _sqlType;

            return _next(context);
        }
    }
}
