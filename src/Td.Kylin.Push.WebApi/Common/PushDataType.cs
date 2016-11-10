namespace Td.Kylin.Push
{
	/// <summary>
	/// 推送的数据类型
	/// </summary>
	public enum PushDataType
	{
		/// <summary>
		/// 用户信息
		/// </summary>
		User = 1,

		/// <summary>
		/// 商户信息
		/// </summary>
		Merchant = 2,

		/// <summary>
		/// 服务人员信息
		/// </summary>
		Worker = 3,

		/// <summary>
		/// 社区帖子
		/// </summary>
		ForumPost = 4,

		/// <summary>
		/// 商城商品
		/// </summary>
		MallProduct = 5,

		/// <summary>
		/// 商城订单状态变更
		/// </summary>
		MallOrderChange = 6,

		/// <summary>
		/// 商户福利
		/// </summary>
		MerchantWelfare = 7,

		/// <summary>
		/// 福利中奖结果
		/// </summary>
		WelfareWinResult = 8,

		/// <summary>
		/// 福利领取
		/// </summary>
		WelfareDraw = 9,

		/// <summary>
		/// 优惠券福利已使用
		/// </summary>
		WelfareCouponUsed = 10,

		/// <summary>
		/// 商家商品
		/// </summary>
		MerchantGoods = 11,

		/// <summary>
		/// 商家服务
		/// </summary>
		MerchantService = 12,

		/// <summary>
		/// 商家商品订单下单
		/// </summary>
		MerchantGoodsOrderCreate = 13,

		/// <summary>
		/// 商家商品订单状态变更
		/// </summary>
		MerchantGoodsOrderChange = 14,

		/// <summary>
		/// 上门服务订单下单
		/// </summary>
		ShangMenOrderCreate = 15,

		/// <summary>
		/// 预约服务订单下单
		/// </summary>
		YuYueOrderCreate = 16,

		/// <summary>
		/// 上门预约订单状态变更
		/// </summary>
		AppointOrderChange = 17,

		/// <summary>
		/// 广告
		/// </summary>
		AD = 18,

		/// <summary>
		/// 系统通知
		/// </summary>
		SystemNotice = 19,

		/// <summary>
		/// 求职简历
		/// </summary>
		Resume = 20,

		/// <summary>
		/// 工作机会
		/// </summary>
		Job = 21,

		/// <summary>
		/// 认证审核结果
		/// </summary>
		CertificateResult = 22,

		/// <summary>
		/// 资金变动
		/// </summary>
		FundsChange = 23,

		/// <summary>
		/// 上门预约订单指派
		/// </summary>
		AppointOrderAllot = 24,

		/// <summary>
		/// IM消息
		/// </summary>
		IM = 25,

		/// <summary>
		/// 公司邀请员工加入
		/// </summary>
		MerchantInviteWorker = 26,

		/// <summary>
		/// 员工申请加入公司
		/// </summary>
		WorkerJoinMerchant = 27,

		/// <summary>
		/// 用户支付成功
		/// </summary>
		PayOrder = 28,

		/// <summary>
		/// 商家发货
		/// </summary>
		SendOrder = 29,

		/// <summary>
		/// 用户确认收货
		/// </summary>
		Confirm = 30,

		/// <summary>
		/// 福利审核
		/// </summary>
		WelfareAudit = 31,

		/// <summary>
		/// 商家审核
		/// </summary>
		MerchantAudit = 32,



		/// <summary>
		/// 活动帖子删除
		/// </summary>
		TopicDelete = 34,

		/// <summary>
		/// B2C订单发货
		/// </summary>
		B2COrderDeliver = 35,

		/// <summary>
		/// 跑腿业务：指派订单给工作人员。
		/// </summary>
		Legwork_AssignOrder = 36,

		/// <summary>
		/// 跑腿业务：订单报价给用户。
		/// </summary>
		Legwork_OrderOffer = 37,

		/// <summary>
		/// 跑腿业务：用户接受报价，将结果推送给工作人员。
		/// </summary>
		Legwork_OrderConfirm = 38,

		/// <summary>
		/// 跑腿业务：工作端确认送达(取送物品)及工作端选择线下支付时(购买物品)，推送给用户。
		/// </summary>
		Legwork_OrderDelivery = 39,

		/// <summary>
		/// 跑腿业务：工作端选择线上支付,推送给用户端。
		/// </summary>
		Legwork_RequestPayment = 40,

		/// <summary>
		/// 跑腿业务：用户端线上支付成功,推送给工作端。
		/// </summary>
		Legwork_PaymentComplete = 41,

		/// <summary>
		/// 提醒购买
		/// </summary>
		Legwork_MessageBuy = 42,
		/// <summary>
		/// 用户催单
		/// </summary>
		UserMessageBuy = 43,
		/// <summary>
		/// B2C下单走跑腿流程推送给工作端
		/// </summary>
		MallLegworkerPush = 44,
		/// <summary>
		/// 用户审核通过
		/// </summary>
		UserAudit = 33,
		/// <summary>
		/// 用户审核失败
		/// </summary>
		UserAuditFail = 45,
		/// <summary>
		/// 申请跑腿业务通过
		/// </summary>
		LegworkAudit = 46,
		/// <summary>
		/// 申请跑腿业务失败
		/// </summary>
		LegworkAuditFail = 47,
		/// <summary>
		/// 取消订单
		/// </summary>
		B2CCancelOrder = 48,
		/// <summary>
		/// 单点登录
		/// </summary>
		SingleLogin = 49
	}
}