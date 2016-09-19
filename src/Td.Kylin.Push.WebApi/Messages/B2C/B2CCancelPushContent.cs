using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Td.Kylin.Push.WebApi.Messages.B2C
{
    /// <summary>
    /// B2C取消订单推送
    /// </summary>
    public class B2CCancelPushContent
    {
        public string PushCode { get; set; }
        public long OrderID { get; set; }
        public string Content { get; set; }
        public  DateTime CreateTime { get { return  DateTime.Now;} }
    }
}
