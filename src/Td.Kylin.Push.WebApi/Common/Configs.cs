using System;
using System.Reflection;
using Td.Common;
using Td.Kylin.Push.WebApi;
using Td.Kylin.Push.WebApi.Controllers;
using Td.Resources;

namespace Td.Kylin.Push
{
    /// <summary>
    /// 配置文件
    /// </summary>
    public class Configs
    {
		#region 私有字段

		private static Assembly _assembly = typeof(Configs).GetAssembly();

		#endregion

		#region 公共属性

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

		#endregion

		#region 公共方法

		public static string GetResource(string text)
		{
			return ResourceUtility.GetString(text, _assembly);
		}

	    public static string GetResource(string text, params object[] args)
	    {
			return ResourceUtility.GetString(text, _assembly, args);
		}

	    #endregion
	}
}
