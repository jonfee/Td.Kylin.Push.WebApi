namespace Td.Kylin.Push.WebApi.SysEnum
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
        WorkerJoinMerchant = 27
    }
}
