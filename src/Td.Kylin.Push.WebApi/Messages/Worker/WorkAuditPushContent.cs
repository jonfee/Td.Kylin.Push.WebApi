using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Td.Kylin.Push.WebApi.Messages.Worker
{
    /// <summary>
    /// 4.	工作人员申请跑腿业务推送
    /// </summary>
    public class WorkAuditPushContent
    {
        public string PushCode { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long WorkerID
        {
            get;
            set;
        }

        public string Contents
        {
            get;
            set;
        }
        public bool Status
        {
            get;
            set;
        }
        public DateTime CreateTime { get { return DateTime.Now; } }
    }
}
