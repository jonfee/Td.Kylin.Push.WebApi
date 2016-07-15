using System;
using System.Collections;

namespace Td.Kylin.Push
{
	/// <summary>
	/// 表示一个标准的推送请求。
	/// </summary>
	public class PushRequest
	{
		#region 私有字段

		private bool _autoBadge = true;								// 自动增长角标
		private PushType _pushType = PushType.Notification;			// 默认推送类型为通知

		#endregion

		#region 公共属性

		/// <summary>
		/// 消息接收者的推送号，不填则为推送给所有人。
		/// </summary>
		public string PushCode
		{
			get;
			set;
		}

		/// <summary>
		/// 推送类型，可以选择为通知或者消息。
		/// </summary>
		public PushType PushType
		{
			get
			{
				return _pushType;
			}
			set
			{
				_pushType = value;
			}
		}

		/// <summary>
		/// 客户端用于识别的的业务数据类型。
		/// </summary>
		public PushDataType DataType
		{
			get;
			set;
		}

		/// <summary>
		/// 消息标题(仅针对Android有效)
		/// </summary>
		public string Title
		{
			get;
			set;
		}

		/// <summary>
		/// 消息内容。
		/// </summary>
		public string Message
		{
			get;
			set;
		}

		/// <summary>
		/// 是否自动增长角标(仅针对IOS有效)
		/// </summary>
		public bool AutoBadge
		{
			get
			{
				return _autoBadge;
			}
			set
			{
				_autoBadge = value;
			}
		}

		/// <summary>
		/// 消息内容数据对象
		/// </summary>
		public object Parameters
		{
			get;
			set;
		}

		#endregion
	}
}