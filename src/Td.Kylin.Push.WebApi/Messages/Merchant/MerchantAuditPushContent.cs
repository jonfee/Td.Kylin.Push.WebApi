using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Td.Kylin.EnumLibrary;

namespace Td.Kylin.Push.Messages.Merchant
{
	public class MerchantAuditPushContent
	{
		/// <summary>
		/// 商家ID
		/// </summary>
		public long MerchantID
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