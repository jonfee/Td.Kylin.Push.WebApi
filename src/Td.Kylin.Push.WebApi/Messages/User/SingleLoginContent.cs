using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Td.Kylin.Push.WebApi.Messages.User
{
    public class SingleLoginContent
   {
		public string PushCode
		{
			get;
			set;
		}
		public string Message
		{
			get;
			set;
		}
		public int Identity
		{
			get;
			set;
		}
	}
}
