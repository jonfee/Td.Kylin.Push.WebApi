﻿using System;

namespace Td.Kylin.Push.WebApi.JPushMessage.Merchant
{
    /// <summary>
    /// 预约订单下单内容
    /// </summary>
    public class YuYueOrderCreateContent
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public long OrderID { get; set; }

        /// <summary>
        /// 下单用户ID
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// 下单用户昵称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 预约的商户ID
        /// </summary>
        public long MerchantID { get; set; }

        /// <summary>
        /// 业务ID
        /// </summary>
        public long BusinessID { get; set; }

        /// <summary>
        /// 服务/业务名称
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// 服务内容数量（如：2）
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 单位（如：台）
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 服务地点
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 服务时间
        /// </summary>
        public DateTime ServiceTime { get; set; }
    }
}
