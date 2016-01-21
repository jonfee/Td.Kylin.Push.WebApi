using JPush.Api;
using JPush.Api.common;
using JPush.Api.common.resp;
using JPush.Api.push;
using JPush.Api.push.mode;
using Newtonsoft.Json;
using System;
using Td.Kylin.Push.WebApi.JPushMessage;
using Td.Kylin.Push.WebApi.Loger;
using Td.Kylin.Push.WebApi.SysEnum;

namespace Td.Kylin.Push.WebApi.JPushProvider
{
    /// <summary>
    /// 推送
    /// </summary>
    public class KylinPushContext
    {
        public KylinPushContext(JPushConfig config, PushMessage message)
        {
            this._apiKey = config.Key;
            this._apiSecret = config.Secret;
            this.KylinPushMessage = message;

            GetPushPayload();
        }

        #region 极光API Key及Secret

        /// <summary>
        /// Key
        /// </summary>
        private string _apiKey;

        /// <summary>
        /// Secret
        /// </summary>
        private string _apiSecret;

        #endregion

        /// <summary>
        /// 消息对象
        /// </summary>
        private PushMessage KylinPushMessage;

        /// <summary>
        /// 推送载体对象
        /// </summary>
        protected PushPayload CurrentPayload { get; private set; }

        #region 推送载体构造

        /// <summary>
        /// 获取推送载体对象
        /// </summary>
        private void GetPushPayload()
        {
            PushPayload payload = null;

            switch (KylinPushMessage.DataType)
            {
                case PushDataType.AD://广告
                case PushDataType.SystemNotice://系统通知
                case PushDataType.User://用户
                case PushDataType.Worker://服务人员
                case PushDataType.Merchant://商家
                case PushDataType.ForumPost://社区帖子
                case PushDataType.MallProduct://自营商城商品
                case PushDataType.MerchantGoods://商户商品
                case PushDataType.MerchantService://商户服务
                case PushDataType.MerchantWelfare://商家福利
                                                  //payload = GetNotificationPushPayload();
                                                  //break;
                case PushDataType.WelfareWinResult://福利活动中奖结果
                case PushDataType.WelfareCouponUsed://优惠券福利被使用
                case PushDataType.WelfareDraw://福利被领取                
                case PushDataType.CertificateResult://认证审核结果
                case PushDataType.FundsChange://资金变动
                case PushDataType.IM://IM消息
                case PushDataType.AppointOrderChange://上门预约订单状态变更
                case PushDataType.Job://工作机会
                case PushDataType.MallOrderChange://自营商城订单状态变更
                case PushDataType.MerchantGoodsOrderChange://商户商品订单状态变更
                case PushDataType.MerchantGoodsOrderCreate://商户商品订单下单 
                case PushDataType.Resume://简历
                case PushDataType.ShangMenOrderCreate://上门订单下单  
                case PushDataType.YuYueOrderCreate://预约订单下单              
                case PushDataType.AppointOrderAllot://上门预约订单被指派                
                    //payload = GetMessagePushPayload();
                    payload = GetNotificationPushPayload();
                    break;
            }

            this.CurrentPayload = payload;
        }

        /// <summary>
        /// 构造自定义消息载体
        /// </summary>
        private PushPayload GetMessagePushPayload()
        {
            if (null == this.KylinPushMessage) return null;

            //将内容数据对象序列化为JSON字符串表现形式
            string jsonContent = JsonConvert.SerializeObject(KylinPushMessage.Content);

            PushPayload pushPayload = new PushPayload();
            pushPayload.platform = Platform.all();//所有平台
            pushPayload.audience = Audience.all();//所有目标
            pushPayload.message = Message.content(jsonContent)
                                        .setTitle(KylinPushMessage.Title).AddExtras("datatype", KylinPushMessage.DataType.ToString("d"));
            if (null != KylinPushMessage.DataID)
            {
                pushPayload.message.AddExtras("dataid", KylinPushMessage.DataID.ToString());
            }
            if (null != KylinPushMessage.FilterUsers && KylinPushMessage.FilterUsers.Length > 0)
            {
                pushPayload.message.AddExtras("filter", string.Join(",", KylinPushMessage.FilterUsers));
            }

            return pushPayload;
        }

        /// <summary>
        /// 构造广播通知消息载体
        /// </summary>
        /// <returns></returns>
        private PushPayload GetNotificationPushPayload()
        {
            if (null == this.KylinPushMessage) return null;

            Type contentType = this.KylinPushMessage.Content.GetType();

            string content = string.Empty;

            if (contentType == typeof(string))
            {
                content = (string)KylinPushMessage.Content;
            }
            else
            {
                content = JsonConvert.SerializeObject(KylinPushMessage.Content);
            }

            PushPayload pushPayload = new PushPayload();
            pushPayload.platform = Platform.all();//所有平台
            pushPayload.audience = Audience.all();//所有目标
            pushPayload.notification = new Notification().setAlert(content).setAllAddExtra("datatype", KylinPushMessage.DataType.ToString("d"));
            if (null != KylinPushMessage.DataID)
            {
                pushPayload.notification.setAllAddExtra("dataid", KylinPushMessage.DataID.ToString());
            }
            if (null != KylinPushMessage.FilterUsers && KylinPushMessage.FilterUsers.Length > 0)
            {
                pushPayload.notification.setAllAddExtra("filter", string.Join(",", KylinPushMessage.FilterUsers));
            }

            return pushPayload;
        }

        #endregion

        /// <summary>
        /// 推送消息
        /// </summary>
        /// <returns></returns>
        public MessageResult Send()
        {
            MessageResult result = null;

            try
            {
                if (null == CurrentPayload) throw new Exception("推送的载体对象PushPayload不存在！");
                JPushClient client = new JPushClient(_apiKey, _apiSecret);
                result = client.SendPush(CurrentPayload);
            }
            catch (APIRequestException ex)
            {
                ExceptionLoger loger = new ExceptionLoger();
                loger.Write("服务器请求异常", ex);
            }
            catch (APIConnectionException ex)
            {
                ExceptionLoger loger = new ExceptionLoger();
                loger.Write("极光服务器连接异常", ex);
            }
            catch (Exception ex)
            {
                ExceptionLoger loger = new ExceptionLoger();
                loger.Write(ex.Message, ex);
            }

            return result;
        }
    }
}
