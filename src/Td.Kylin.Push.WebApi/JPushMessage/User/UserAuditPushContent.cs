using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Td.Kylin.Push.WebApi.JPushMessage.User
{
	public class UserAuditPushContent
	{
		/// <summary>
		/// 用户ID
		/// </summary>
		public long UserID
		{
			get;
			set;
		}

		/// <summary>
		/// 审核状态
		/// </summary>
		public int AuditStatus
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