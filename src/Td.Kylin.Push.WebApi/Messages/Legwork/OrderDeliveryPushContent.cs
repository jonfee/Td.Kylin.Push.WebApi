﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Td.Kylin.Push.Messages.Legwork
{
	/// <summary>
	/// 订单送达推送内容。
	/// </summary>
    public class OrderDeliveryPushContent
    {
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// 需要推送给用户端的推送号。
        /// </summary>
        public string PushCode
		{
			get;
			set;
		}

		/// <summary>
		/// 订单ID。
		/// </summary>
		public long OrderID
		{
			get;
			set;
		}

		/// <summary>
		/// 订单编号。
		/// </summary>
		public string OrderCode
		{
			get;
			set;
		}

		/// <summary>
		/// 工作人员名称。
		/// </summary>
		public string WorkerName
		{
			get;
			set;
		}

		/// <summary>
		/// 订单状态。
		/// </summary>
		public short OrderStatus
		{
			get;
			set;
		}
	}
}
