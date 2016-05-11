using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Td.Kylin.Push.WebApi.JPushMessage.Topic
{
	public class TopicDeletePushContent
	{
		/// <summary>
		/// 帖子ID
		/// </summary>
		public long TopicID
		{
			get;
			set;
		}

		/// <summary>
		/// 报名用户id集合，多个id使用","隔开
		/// </summary>
		public string UserIDs
		{
			get;
			set;
		}

		/// <summary>
		/// 帖子标题
		/// </summary>
		public string Title
		{
			get;
			set;
		}

		/// <summary>
		/// 区域圈子名称
		/// </summary>
		public string AreaFormName
		{
			get;
			set;
		}

		public string Contents
		{
			get;
			set;
		}
	}
}