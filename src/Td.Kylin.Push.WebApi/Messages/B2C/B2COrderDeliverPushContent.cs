using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Td.Kylin.Push.Messages.B2C
{
	public class B2COrderDeliverPushContent
	{
		/// <summary>
		/// 订单ID
		/// </summary>
		public long OrderID
		{
			get;
			set;
		}

		/// <summary>
		/// 订单编号
		/// </summary>
		public string OrderCode
		{
			get;
			set;
		}

		/// <summary>
		/// 运营商ID
		/// </summary>
		public long OperatorID
		{
			get;
			set;
		}

		/// <summary>
		/// 运营商名称
		/// </summary>
		public string OperatorName
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