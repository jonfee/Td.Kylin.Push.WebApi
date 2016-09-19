using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Td.Kylin.WebApi;
using Td.Kylin.WebApi.Filters;
using Td.Kylin.Push.Messages.B2C;
using Td.Kylin.Push.WebApi.Messages.B2C;

namespace Td.Kylin.Push.WebApi.Controllers
{
    [Route("v1/b2c_order")]
    public class B2COrderController : BaseController
    {
        /**
        * @apiVersion 1.0.0
        * @apiDescription 此接口在B2C订单发货-推送用户端
        * @api {post} /v1/b2c_order/deliver B2C订单发货-推送用户端
        * @apiSampleRequest /v1/b2c_order/deliver
        * @apiName OrderDeliver
        * @apiGroup B2C_Order
        * @apiPermission All
        *
        * @apiParam {long} OrderID 订单ID
        * @apiParam {string} PushCode 推送号
		* @apiParam {string} Content 内容
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
        /// B2C订单发货-推送用户端
        /// </summary>
        /// <returns></returns>
        [HttpPost("deliver")]
        [ApiAuthorization]
        public IActionResult OrderDeliver(B2CSendPushContent content)
        {
            var request = new PushRequest
            {
                PushCode = content.PushCode,
                DataType = PushDataType.B2COrderDeliver,
                Parameters = content,
                Message = content.Content
            };

            // 推送给用户端。
            var response = PushProviderFactory.UserClient.Send(request);

            return Success(response.Success);
        }

        /**
        * @apiVersion 1.0.0
        * @apiDescription 此接口在B2C取消订单-推送用户端
        * @api {post} /v1/b2c_order/cancel B2C取消订单-推送用户端
        * @apiSampleRequest /v1/b2c_order/cancel
        * @apiName OrderDeliver
        * @apiGroup B2C_Order
        * @apiPermission All
        *
        * @apiParam {long} OrderID 订单ID
        * @apiParam {string} OrderCode 订单编号
        * @apiParam {long} OperatorID 运营商ID
		* @apiParam {string} OperatorName 运营商名称
		* @apiParam {string} Contents 内容
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
        /// B2C订单发货-推送用户端
        /// </summary>
        /// <returns></returns>
        [HttpPost("cancel")]
        [ApiAuthorization]
        public IActionResult CancelOrder(B2CCancelPushContent content)
        {
            var request = new PushRequest
            {
                PushCode = content.PushCode,
                DataType = PushDataType.B2CCancelOrder,
                Parameters = content,
                Message = content.Content
            };

            // 推送给用户端。
            var response = PushProviderFactory.UserClient.Send(request);

            return Success(response.Success);
        }
    }
}
