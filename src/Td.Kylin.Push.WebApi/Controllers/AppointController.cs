using Microsoft.AspNet.Mvc;
using System;
using Td.Kylin.Push.WebApi.Core;
using Td.Kylin.Push.WebApi.JPushMessage.Merchant;
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
         * @api {get} /v1/appoint/pushshangmen 用户针对上门服务下单
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
        [HttpPost("pushshangmen")]
        [ApiAuthorization]
        public IActionResult PushShangMenOrder(ShangMenOrderCreateContent content)
        {
            bool success = false;

            try
            {
                //content = new ShangMenOrderCreateContent
                //{
                //    Address = "南山区蛇口网谷万维大楼203",
                //    BusinessID = 1241513214543,
                //    Number = 2,
                //    OrderID = 853249,
                //    ServiceName = "空调清洗",
                //    ServiceTime = DateTime.Now.AddDays(5),
                //    Unit = "台"
                //};

                JPushMessage.PushMessage message = new JPushMessage.PushMessage
                {
                    Content = content,
                    DataID = content.OrderID,
                    DataType = SysEnum.PushDataType.ShangMenOrderCreate,
                    FilterUsers = null,
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
         * @api {get} /v1/appoint/pushyuyue 用户针对上门服务下单
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
                    FilterUsers = new[] { content.MerchantID },//推送给指定商家
                    Title = string.Format("{0}({1}{2})", content.ServiceName, content.Number, content.Unit)
                };

                //推送给商家
                KylinPushContext merchantContext = new KylinPushContext(Configs.JPushConfigs.MerchantJPushConfig, message);
                var merchantResult = merchantContext.Send();

                success = true;
            }
            catch (Exception ex)
            {
                ExceptionLoger loger = new ExceptionLoger();
                loger.Write("推送上门订单时异常", ex);
            }

            return KylinOk(success);
        }
    }
}
