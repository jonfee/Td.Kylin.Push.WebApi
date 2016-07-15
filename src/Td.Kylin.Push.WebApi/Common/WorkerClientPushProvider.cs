using System;
using System.Collections.Generic;

namespace Td.Kylin.Push
{
    public class WorkerClientPushProvider : PushProviderBase
    {
		#region 构造方法

	    public WorkerClientPushProvider(string key, string secret) : base("WorkerClient", key, secret)
	    {

	    }

	    #endregion
	}
}
