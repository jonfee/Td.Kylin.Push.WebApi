using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Td.Kylin.Push.WebApi.Messages.Topic
{
    /// <summary>
    /// 帖子置顶推送实体
    /// </summary>
    public class TopicTopPushContent
    {

        public long TopicID { get; set; }
        public long UserID { get; set; }
        public string PushCode { get; set; }
        public string Content { get; set; }
        public int TopicType { get; set; }
        public DateTime CreateTime { get { return DateTime.Now; } }
    }
}
