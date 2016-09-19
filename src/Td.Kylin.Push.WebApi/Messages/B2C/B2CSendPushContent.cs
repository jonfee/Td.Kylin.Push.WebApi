using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Td.Kylin.Push.WebApi.Messages.B2C
{
    /// <summary>
    /// 6.	直营订单发货
    /// </summary>
    public class B2CSendPushContent
    {
        public string PushCode { get; set; }
        public long OrderID { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get { return DateTime.Now; } }
    }
}
