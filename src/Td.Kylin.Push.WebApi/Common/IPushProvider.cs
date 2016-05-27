using System;
using System.Collections.Generic;

namespace Td.Kylin.Push
{
    public interface IPushProvider
    {
	    string Name
	    {
		    get;
	    }

	    PushResponse Send(PushRequest message);
    }
}
