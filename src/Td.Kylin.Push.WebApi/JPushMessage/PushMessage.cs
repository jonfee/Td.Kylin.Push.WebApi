using System.Collections;
using Td.Kylin.Push.WebApi.Core;
using Td.Kylin.Push.WebApi.SysEnum;

namespace Td.Kylin.Push.WebApi.JPushMessage
{
    /// <summary>
    /// 消息基类
    /// </summary>
    public class PushMessage
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public long MessageID { get { return IDProvider.NewId(); } }

        /// <summary>
        /// 消息标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 消息内容数据对象
        /// </summary>
        public object Content { get; set; }

        /// <summary>
        /// 数据ID
        /// </summary>
        public object DataID { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public PushDataType DataType { get; set; }

        /// <summary>
        /// 筛选条件
        /// </summary>
        public object Filter { get; set; }
    }
}
