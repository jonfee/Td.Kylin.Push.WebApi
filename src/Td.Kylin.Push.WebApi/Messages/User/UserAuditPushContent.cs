using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Td.Kylin.Push.Messages.User
{
	public class UserAuditPushContent
	{
        public string PushCode { get; set; }
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