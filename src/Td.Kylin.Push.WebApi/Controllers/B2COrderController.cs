using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Td.Kylin.WebApi;
using Td.Kylin.Push.WebApi.JPushProvider;
using Td.Kylin.Push.WebApi.Loger;
using Td.Kylin.Push.WebApi.Core;
using Td.Kylin.WebApi.Filters;
using Td.Kylin.Push.WebApi.JPushMessage.B2C;

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
			bool success = false;

			try
			{
				JPushMessage.PushMessage message = new JPushMessage.PushMessage
				{
					Content = content,
					DataID = content.OrderID,
					DataType = SysEnum.PushDataType.B2COrderDeliver,
					Title = string.Format("订单已发货！(订单号：{0})", content.OrderCode)
				};

				//推送给用户
				KylinPushContext context = new KylinPushContext(Configs.JPushConfigs.UserJPushConfig, message);
				var result = context.Send();

				success = true;
			}
			catch(Exception ex)
			{
				ExceptionLoger loger = new ExceptionLoger();
				loger.Write("订单已发货消息推送异常", ex);
			}

			return Success(success);
		}
	}
}
