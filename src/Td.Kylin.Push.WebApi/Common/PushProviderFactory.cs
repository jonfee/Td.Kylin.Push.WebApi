using System;
using System.Collections.Generic;
using System.Linq;

namespace Td.Kylin.Push
{
    public class PushProviderFactory
    {
		#region 私有字段

		private static object _lock = new object();
		private static Dictionary<string, IPushProvider> _providers = new Dictionary<string, IPushProvider>();

		#endregion

		#region 公共属性

		public static IPushProvider UserClient
	    {
		    get
		    {
			    return GetProvider("UserClient");
		    }
	    }

	    public static IPushProvider WorkerClient
	    {
		    get
		    {
				return GetProvider("WorkerClient");
		    }
	    }

	    public static IPushProvider MerchantClient
	    {
		    get
		    {
				return GetProvider("MerchantClient");
		    }
	    }

		#endregion

		#region 公共方法

		public static void Register(IPushProvider provider)
		{
			if(provider == null)
				throw new ArgumentNullException("provider");

			if(string.IsNullOrWhiteSpace(provider.Name))
				throw new ArgumentException("provider");

			_providers[provider.Name] = provider;
		}

		public static IPushProvider GetProvider(string name)
	    {
			lock(_lock)
			{
				if(_providers.ContainsKey(name))
				{
					return _providers[name];
				}
			}

			return null;
	    }

	    #endregion
	}
}