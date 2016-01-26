using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections;
using Td.Kylin.Push.WebApi.Core;
using Td.Kylin.Push.WebApi.JPushMessage.Merchant;
using Td.Kylin.Push.WebApi.JPushMessage.User;
using Td.Kylin.Push.WebApi.JPushMessage.Worker;
using Td.Kylin.Push.WebApi.JPushProvider;
using Td.Kylin.Push.WebApi.Loger;
using Td.Kylin.WebApi;
using Td.Kylin.WebApi.Filters;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Td.Kylin.Push.WebApi.Controllers
{
    [Route("v1/appoint")]
    public class AppointController : BaseController
    {
        /**
         * @apiVersion 1.0.0
         * @apiDescription 此接口在用户针对上门服务下单成功后推送给相关业务的商家或个人服务人员
         * @api {post} /v1/appoint/pushshangmen 用户上门服务下单
         * @apiSampleRequest /v1/appoint/pushshangmen
         * @apiName PushShangMenOrder
         * @apiGroup Appoint
         * @apiPermission All
         *
         * @apiParam {long} OrderID 上门订单ID
         * @apiParam {long} UserID 下单的用户ID
         * @apiParam {string} UserName 下单的用户昵称
         * @apiParam {long} BusinessID 订单所属服务的业务ID
         * @apiParam {string} ServiceName 订单所属服务或业务的名称
         * @apiParam {int} Number 数量
         * @apiParam {string} Unit 单位(如：小时)
         * @apiParam {string} Address 上门服务的地址
         * @apiParam {datetime} ServiceTime 服务时间
         * @apiParam {datetime} CreateTime 下单时间
         *
         * @apiSuccessExample 正常输出：
         * 推送结果[Boolean]，True表示推送成功，Flase表示失败
         *
         * @apiErrorExample 错误输出:
         * {
         *          "Code":错误代号,
         *          "Message":"错误标题",
         *          "Content":"错误详细信息"
         * }
         */
        /// <summary>
        /// 上门订单推送
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpGet("pushshangmen")]
        [ApiAuthorization]
        public IActionResult PushShangMenOrder(ShangMenOrderCreateContent content)
        {
            bool success = false;

            try
            {
                content = new ShangMenOrderCreateContent
                {
                    Address = "南山区蛇口网谷万维大楼203",
                    BusinessID = 1241513214543,
                    Number = 2,
                    OrderID = 853249,
                    ServiceName = "空调清洗",
                    ServiceTime = DateTime.Now.AddDays(5),
                    Unit = 1,
                };

                JPushMessage.PushMessage message = new JPushMessage.PushMessage
                {
                    Content = content,
                    DataID = content.OrderID,
                    DataType = SysEnum.PushDataType.ShangMenOrderCreate,
                    Filter = new { BusinessID = content.BusinessID },//当前订单的业务ID
                    Title = string.Format("{0}({1}{2})", content.ServiceName, content.Number, content.Unit)
                };

                //推送给商家
                KylinPushContext merchantContext = new KylinPushContext(Configs.JPushConfigs.MerchantJPushConfig, message);
                var merchantResult = merchantContext.Send();

                //推送给个人服务者
                KylinPushContext workerContext = new KylinPushContext(Configs.JPushConfigs.WorkerJPushConfig, message);
                var workerResult = workerContext.Send();

                success = true;
            }
            catch (Exception ex)
            {
                ExceptionLoger loger = new ExceptionLoger();
                loger.Write("推送上门订单时异常", ex);
            }

            return KylinOk(success);
        }

        /**
         * @apiVersion 1.0.0
         * @apiDescription 此接口在用户针对商家服务预约下单成功后推送给预约的商家
         * @api {post} /v1/appoint/pushyuyue 用户预约服务下单
         * @apiSampleRequest /v1/appoint/pushyuyue
         * @apiName PushYuYueOrder
         * @apiGroup Appoint
         * @apiPermission All
         *
         * @apiParam {long} OrderID 上门订单ID
         * @apiParam {long} UserID 下单的用户ID
         * @apiParam {string} UserName 下单的用户昵称
         * @apiParam {long} MerchantID 预约的商家ID
         * @apiParam {long} BusinessID 订单所属服务的业务ID
         * @apiParam {string} ServiceName 订单所属服务或业务的名称
         * @apiParam {int} Number 数量
         * @apiParam {string} Unit 单位(如：小时)
         * @apiParam {string} Address 上门服务的地址
         * @apiParam {datetime} ServiceTime 服务时间
         * @apiParam {datetime} CreateTime 下单时间
         *
         * @apiSuccessExample 正常输出：
         * 推送结果[Boolean]，True表示推送成功，Flase表示失败
         *
         * @apiErrorExample 错误输出:
         * {
         *          "Code":错误代号,
         *          "Message":"错误标题",
         *          "Content":"错误详细信息"
         * }
         */
        /// <summary>
        /// 预约订单推送
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost("pushyuyue")]
        [ApiAuthorization]
        public IActionResult PushYuYueOrder(YuYueOrderCreateContent content)
        {
            bool success = false;

            try
            {
                JPushMessage.PushMessage message = new JPushMessage.PushMessage
                {
                    Content = content,
                    DataID = content.OrderID,
                    DataType = SysEnum.PushDataType.YuYueOrderCreate,
                    Filter = new { MerchantID = content.MerchantID },//推送给指定的商户
                    Title = string.Format("有新的订单！{0}({1}{2})", content.ServiceName, content.Number, content.Unit)
                };

                //推送给商家
                KylinPushContext context = new KylinPushContext(Configs.JPushConfigs.MerchantJPushConfig, message);
                var result = context.Send();

                success = true;
            }
            catch (Exception ex)
            {
                ExceptionLoger loger = new ExceptionLoger();
                loger.Write("推送预约订单时异常", ex);
            }

            return KylinOk(success);
        }

        /**
         * @apiVersion 1.0.0
         * @apiDescription 此接口用于商户指派订单给工作人员时使用
         * @api {post} /v1/appoint/allot 上门订单指派
         * @apiSampleRequest /v1/appoint/allot
         * @apiName OrderAllot
         * @apiGroup Appoint
         * @apiPermission All
         *
         * @apiParam {long} OrderID 上门订单ID
         * @apiParam {long} UserID 下单的用户ID
         * @apiParam {string} UserName 下单的用户昵称
         * @apiParam {long} MerchantID 预约的商家ID
         * @apiParam {string} MerchantName 预约的商家名称
         * @apiParam {long} WorkerID 被指派的工作人员ID
         * @apiParam {long} BusinessID 订单所属服务的业务ID
         * @apiParam {string} ServiceName 订单所属服务或业务的名称
         * @apiParam {int} Number 数量
         * @apiParam {string} Unit 单位(如：小时)
         * @apiParam {string} Address 上门服务的地址
         * @apiParam {datetime} ServiceTime 服务时间 
         * @apiParam {datetime} AllotTime 指派时间
         *
         * @apiSuccessExample 正常输出：
         * 推送结果[Boolean]，True表示推送成功，Flase表示失败
         *
         * @apiErrorExample 错误输出:
         * {
         *          "Code":错误代号,
         *          "Message":"错误标题",
         *          "Content":"错误详细信息"
         * }
         */
        /// <summary>
        /// 订单指派
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost("allot")]
        [ApiAuthorization]
        public IActionResult OrderAllot(AppointOrderAllotContent content)
        {
            bool success = false;

            try
            {
                JPushMessage.PushMessage message = new JPushMessage.PushMessage
                {
                    Content = content,
                    DataID = content.OrderID,
                    DataType = SysEnum.PushDataType.AppointOrderAllot,
                    Filter = new { WorkerID = content.WorkerID },//推送给指定服务人员
                    Title = string.Format("订单：{0}({1}{2})已指派给您", content.ServiceName, content.Number, content.Unit)
                };

                //推送给服务人员
                KylinPushContext context = new KylinPushContext(Configs.JPushConfigs.WorkerJPushConfig, message);
                var result = context.Send();

                success = true;
            }
            catch (Exception ex)
            {
                ExceptionLoger loger = new ExceptionLoger();
                loger.Write("指派订单时异常", ex);
            }

            return KylinOk(success);
        }

        /**
         * @apiVersion 1.0.0
         * @apiDescription 此接口用于用户上门或预约订单被接时推送消息给下单用户
         * @api {post} /v1/appoint/accept 订单已被接单
         * @apiSampleRequest /v1/appoint/accept
         * @apiName OrderAccept
         * @apiGroup Appoint
         * @apiPermission All
         *
         * @apiParam {long} OrderID 上门订单ID
         * @apiParam {long} UserID 下单的用户ID
         * @apiParam {string} UserName 下单的用户昵称
         * @apiParam {int} AcceptType 接单方类型（1为商户，2为个人服务者）
         * @apiParam {long} AcceptAccountID 接单方的账号ID（商户时为商户ID，个人服务者时为服务人员ID）
         * @apiParam {string} AcceptName 接单方的名称（商户名称或服务人员名称）
         * @apiParam {long} BusinessID 订单所属服务的业务ID
         * @apiParam {string} ServiceName 订单所属服务或业务的名称
         * @apiParam {int} Number 数量
         * @apiParam {string} Unit 单位(如：小时)
         * @apiParam {string} Address 上门服务的地址
         * @apiParam {datetime} ServiceTime 服务时间 
         * @apiParam {datetime} AcceptTime 接单时间
         *
         * @apiSuccessExample 正常输出：
         * 推送结果[Boolean]，True表示推送成功，Flase表示失败
         *
         * @apiErrorExample 错误输出:
         * {
         *          "Code":错误代号,
         *          "Message":"错误标题",
         *          "Content":"错误详细信息"
         * }
         */
        /// <summary>
        /// 用户订单被接
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost("accept")]
        [ApiAuthorization]
        public IActionResult OrderAccept(AppointOrderAcceptContent content)
        {
            bool success = false;

            try
            {
                JPushMessage.PushMessage message = new JPushMessage.PushMessage
                {
                    Content = content,
                    DataID = content.OrderID,
                    DataType = SysEnum.PushDataType.AppointOrderChange,
                    Filter = new { UserID = content.UserID },//推送给下单用户
                    Title = string.Format("订单：{0}({1}{2})已被接单", content.ServiceName, content.Number, content.Unit)
                };

                //推送给服务人员
                KylinPushContext context = new KylinPushContext(Configs.JPushConfigs.UserJPushConfig, message);
                var result = context.Send();

                success = true;
            }
            catch (Exception ex)
            {
                ExceptionLoger loger = new ExceptionLoger();
                loger.Write("接单后推送消息给下单人员时异常", ex);
            }

            return KylinOk(success);
        }
    }
}
