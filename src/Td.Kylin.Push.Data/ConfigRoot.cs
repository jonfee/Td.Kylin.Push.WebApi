using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Td.Kylin.EnumLibrary;
using Td.Kylin.Push.Data.Context;

namespace Td.Kylin.Push.Data
{
    public sealed class ConfigRoot
    {
        /// <summary>
        /// 数据库提供者类型
        /// </summary>
        public static SqlProviderType SqlType { get; set; }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string SqlConnctionString { get; set; }
    }
}
