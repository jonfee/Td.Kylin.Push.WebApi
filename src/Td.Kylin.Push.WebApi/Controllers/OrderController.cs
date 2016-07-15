using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Td.Kylin.WebApi;
using Td.Kylin.WebApi.Filters;
using Td.Kylin.Push.Messages.Merchant;

namespace Td.Kylin.Push.WebApi.Controllers
{
    [Route("v1/order")]
    public class OrderController : BaseController
    {
        /**
        * @apiVersion 1.0.0
        * @apiDescription 此接口在商家订单-用户支付成功-推送商家端
        * @api {post} /v1/order/pay 商家订单-用户支付成功-推送商家端
        * @apiSampleRequest /v1/order/pay
        * @apiName PayOrder
        * @apiGroup Order
        * @apiPermission All
        *
        * @apiParam {long} OrderID 福利ID
        * @apiParam {string} OrderCode 订单编号
        * @apiParam {long} MerchantID 商家ID
        * @apiParam {decimal} ActualOrderAmount 实际订单总金额
        * @apiParam {long} UserID 买家用户ID
        * @apiParam {string} UserName 用户名称
        * @apiParam {datetime} PayTime 付款时间
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
        /// 商家订单-用户支付成功-推送商家端
        /// </summary>
        /// <returns></returns>
        [HttpPost("pay")]
        [ApiAuthorization]
        public IActionResult PayOrder(PayMerchantOrderContent content)
        {
			var request = new PushRequest
			{
							PushCode = content.PushCode,
				DataType = PushDataType.PayOrder,
				Parameters = content,
				Message = string.Format("用户已经下单付款！(订单号：{0})", content.OrderCode)
			};

			// 推送给商家端。
			var response = PushProviderFactory.MerchantClient.Send(request);

			return Success(response.Success);
        }

		/**
        * @apiVersion 1.0.0
        * @apiDescription 此接口在商家发货-推送用户端
        * @api {post} /v1/order/send 商家发货-推送用户端
        * @apiSampleRequest /v1/order/send
        * @apiName PayOrder
        * @apiGroup Order
        * @apiPermission All
        *
        * @apiParam {long} OrderID 订单ID
        * @apiParam {string} OrderCode 订单编号
        * @apiParam {long} MerchantID 商家ID
        * @apiParam {decimal} ActualOrderAmount 实际订单总金额
        * @apiParam {long} UserID 买家用户ID
        * @apiParam {string} UserName 用户名称
        * @apiParam {datetime} SendTime 发货时间
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
		/// 商家发货-推送用户端
		/// </summary>
		/// <returns></returns>
		[HttpPost("send")]
		[ApiAuthorization]
		public IActionResult SendOrder(SendMerchantOrderContent content)
        {
			var request = new PushRequest
			{
				PushCode = content.PushCode,
				DataType = PushDataType.SendOrder,
				Parameters = content,
				Message = string.Format("订单已发货！(订单号：{0})", content.OrderCode)
			};

			// 推送给用户端。
			var response = PushProviderFactory.UserClient.Send(request);

			return Success(response.Success);
		}

        /// <summary>
        /// 用户确认收货-推送商家端
        /// </summary>
        /// <returns></returns>
        [HttpGet("confirm")]
        public IActionResult ConfirmOrder()
        {
            var x = 19;
            //var request = new PushRequest
            //{
            //    PushCode = content.PushCode,
            //    DataType = PushDataType.SendOrder,
            //    Parameters = content,
            //    Message = string.Format("订单已发货！(订单号：{0})", content.OrderCode)
            //};

            // 推送给用户端。
            //var response = PushProviderFactory.UserClient.Send(request);
            return Success("");
        }
    }
}
