using System;
using Microsoft.AspNetCore.Mvc;
using Td.Kylin.Push.Messages.Merchant;
using Td.Kylin.Push.Messages.User;
using Td.Kylin.Push.Messages.Worker;
using Td.Kylin.WebApi;
using Td.Kylin.WebApi.Filters;

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
        [HttpPost("pushshangmen")]
        [ApiAuthorization]
        public IActionResult PushShangMenOrder(ShangMenOrderCreateContent content)
        {
	        var request = new PushRequest
	        {
				DataType = PushDataType.ShangMenOrderCreate,
				Parameters = content,
				Message = string.Format("{0}({1}{2})", content.ServiceName, content.Number, content.Unit)
			};

			// 推送给商家端。
	        var response = PushProviderFactory.MerchantClient.Send(request);

			// 推送给工作端
	        var response1 = PushProviderFactory.WorkerClient.Send(request);

            return Success(response.Success && response1.Success);
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
			var request = new PushRequest
			{
//				PushCode = content.MerchantID,
				DataType = PushDataType.YuYueOrderCreate,
				Parameters = content,
				Message = string.Format("有新的订单！{0}({1}{2})", content.ServiceName, content.Number, content.Unit)
			};

			// 推送给商家端。
			var response = PushProviderFactory.MerchantClient.Send(request);

            return Success(response.Success);
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
			var request = new PushRequest
			{
				//				PushCode = content.WorkerID,
				DataType = PushDataType.YuYueOrderCreate,
				Parameters = content,
				Message = string.Format("订单：{0}({1}{2})已指派给您", content.ServiceName, content.Number, content.Unit)
			};

			// 推送给工作端。
			var response = PushProviderFactory.WorkerClient.Send(request);

			return Success(response.Success);
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
			var request = new PushRequest
			{
				//				PushCode = content.UserID,
				DataType = PushDataType.YuYueOrderCreate,
				Parameters = content,
				Message = string.Format("订单：{0}({1}{2})已被接单", content.ServiceName, content.Number, content.Unit)
			};

			// 推送给用户端。
			var response = PushProviderFactory.UserClient.Send(request);

			return Success(response.Success);
        }
    }
}
