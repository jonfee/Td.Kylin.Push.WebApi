using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Td.Kylin.Push.WebApi.Messages.Legwork
{
    public class MessageBuyPushContent
    {
        public string Title
        {
            get;
            set;
        }
        /// <summary>
		/// 需要推送给工作端的推送号。
		/// </summary>
		public string PushCode
        {
            get;
            set;
        }
        public long OrderID
        {
            get;
            set;
        }

        public DateTime CreateTime
        {
            get;
            set;
        }

        public string OrderCode
        {
            get;
            set;
        }
    }
}
