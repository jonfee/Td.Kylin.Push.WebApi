using System;
using System.Collections.Generic;
using System.Linq;

namespace Td.Kylin.Push
{
    public class UserClientPushProvider : PushProviderBase
    {
		#region 构造方法

		public UserClientPushProvider(string key, string secret) : base("UserClient", key, secret)
	    {

		}

		#endregion
	}
}
