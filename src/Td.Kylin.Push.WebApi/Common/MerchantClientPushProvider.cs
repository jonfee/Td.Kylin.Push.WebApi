using System;
using System.Collections.Generic;

namespace Td.Kylin.Push
{
    public class MerchantClientPushProvider : PushProviderBase
	{
		#region 构造方法

		public MerchantClientPushProvider(string key, string secret) : base("MerchantClient", key, secret)
	    {

		}

		#endregion
	}
}
