using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Td.Kylin.WebApi;
using Td.Kylin.WebApi.Filters;
using Td.Kylin.Push.Messages.B2C;

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
		[HttpPost("deliver")]
		[ApiAuthorization]
		public IActionResult OrderDeliver(B2COrderDeliverPushContent content)
		{
			var request = new PushRequest
			{
				//				PushCode = content.UserID,
				DataType = PushDataType.YuYueOrderCreate,
				Parameters = content,
				Message = string.Format("订单已发货！(订单号：{0})", content.OrderCode)
			};

			// 推送给用户端。
			var response = PushProviderFactory.UserClient.Send(request);

			return Success(response.Success);
		}
	}
}
