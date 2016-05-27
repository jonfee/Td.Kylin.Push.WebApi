﻿using System;
using Microsoft.AspNet.Mvc;
using Td.Kylin.WebApi;
using Td.Kylin.WebApi.Filters;
using Td.Kylin.Push.Messages.Legwork;

namespace Td.Kylin.Push.WebApi.Controllers
{
	[Route("v1/legwork")]
	public class LegworkController : BaseController
	{
		/**
         * @apiVersion 1.0.0
         * @apiDescription 用户下单后，系统将订单指派给相关的工作人员。
         * @api {post} /v1/legwork/assign_order 订单指派
         * @apiSampleRequest /v1/legwork/assign_order
         * @apiName AssignOrder
         * @apiGroup Legwork
         * @apiPermission All
         *
         * @apiParam {string} PushCode 需要推送给工作端的推送号。
         * @apiParam {long} OrderID 订单ID。
         * @apiParam {string} OrderCode 订单编号。
		 * @apiParam {short} OrderType 订单类型。
         *
         * @apiSuccessExample 正常输出：
         * {
		 *	  "Code": 0,
		 *	  "Message": null,
		 *	  "IsError": false,
		 *	  "Content": true
		 * }
         *
         * @apiErrorExample 错误输出:
         * {
         *    "Code":错误代号,
         *    "Message":"错误标题",
         *    "Content":"错误详细信息"
         * }
         */
		[HttpPost("assign_order")]
		[ApiAuthorization]
		public IActionResult AssignOrder(AssignOrderPushContent content)
		{
			var request = new PushRequest
			{
				PushCode = content.PushCode,
				PushType = PushType.Notification,
				DataType = PushDataType.Legwork_AssignOrder,
				Parameters = content,
				Message = Configs.GetResource("${Legwork.AssignOrder.Message}")
			};

			// 推送给工作端。
			var response = PushProviderFactory.WorkerClient.Send(request);

			return Success(response.Success);
		}

		/**
         * @apiVersion 1.0.0
         * @apiDescription 工作人员报价后，将报价结果推送给指定的用户。
         * @api {post} /v1/legwork/order_offer 订单报价
         * @apiSampleRequest /v1/legwork/order_offer
         * @apiName OrderOffer
         * @apiGroup Legwork
         * @apiPermission All
         *
         * @apiParam {string} PushCode 需要推送给用户端的推送号。
         * @apiParam {long} OrderID 订单ID。
         * @apiParam {string} OrderCode 订单编号。
		 * @apiParam {decimal} Charge 服务费用。
		 * @apiParam {long} WorkerID 服务人员ID。
		 * @apiParam {string} WorkerName 服务人员名称。
		 * @apiParam {double} Distance 服务员距离取货地或收货地的距离。
         *
         * @apiSuccessExample 正常输出：
         * {
		 *	  "Code": 0,
		 *	  "Message": null,
		 *	  "IsError": false,
		 *	  "Content": true
		 * }
         *
         * @apiErrorExample 错误输出:
         * {
         *    "Code":错误代号,
         *    "Message":"错误标题",
         *    "Content":"错误详细信息"
         * }
         */
		[HttpPost("order_offer")]
		[ApiAuthorization]
		public IActionResult OrderOffer(OrderOfferPushContent content)
		{
			var request = new PushRequest
			{
				PushCode = content.PushCode,
				PushType = PushType.Notification,
				DataType = PushDataType.Legwork_OrderOffer,
				Parameters = content,
				Message = Configs.GetResource("${Legwork.OrderOffer.Message}")
			};

			// 推送给用户端。
			var response = PushProviderFactory.UserClient.Send(request);

			return Success(response.Success);
		}

		/**
         * @apiVersion 1.0.0
         * @apiDescription 用户接受报价后，将结果推送给指定的工作人员。
         * @api {post} /v1/legwork/order_confirm 订单报价确认
         * @apiSampleRequest /v1/legwork/order_confirm
         * @apiName OrderConfirm
         * @apiGroup Legwork
         * @apiPermission All
         *
         * @apiParam {string} PushCode 需要推送给用户端的推送号。
         * @apiParam {long} OrderID 订单ID。
         * @apiParam {string} OrderCode 订单编号。
		 * @apiParam {short} OrderStatus 订单状态。
         *
         * @apiSuccessExample 正常输出：
         * {
		 *	  "Code": 0,
		 *	  "Message": null,
		 *	  "IsError": false,
		 *	  "Content": true
		 * }
         *
         * @apiErrorExample 错误输出:
         * {
         *    "Code":错误代号,
         *    "Message":"错误标题",
         *    "Content":"错误详细信息"
         * }
         */
		[HttpPost("order_confirm")]
		[ApiAuthorization]
		public IActionResult OrderConfirm(OrderConfirmPushContent content)
		{
			var request = new PushRequest
			{
				PushCode = content.PushCode,
				PushType = PushType.Notification,
				DataType = PushDataType.Legwork_OrderConfirm,
				Parameters = content,
				Message = Configs.GetResource("${Legwork.OrderConfirm.Message}")
			};

			// 推送给工作端。
			var response = PushProviderFactory.WorkerClient.Send(request);

			return Success(response.Success);
		}

		/**
         * @apiVersion 1.0.0
         * @apiDescription 工作人员确认送达(取送物品)及工作人员选择线下支付时(购买物品)，推送给用户。
         * @api {post} /v1/legwork/order_delivery 物品送达
         * @apiSampleRequest /v1/legwork/order_delivery
         * @apiName OrderDelivery
         * @apiGroup Legwork
         * @apiPermission All
         *
         * @apiParam {string} PushCode 需要推送给用户端的推送号。
         * @apiParam {long} OrderID 订单ID。
         * @apiParam {string} OrderCode 订单编号。
		 * @apiParam {string} WorkerName 工作人员名称。
		 * @apiParam {short} OrderStatus 订单状态。
         *
         * @apiSuccessExample 正常输出：
         * {
		 *	  "Code": 0,
		 *	  "Message": null,
		 *	  "IsError": false,
		 *	  "Content": true
		 * }
         *
         * @apiErrorExample 错误输出:
         * {
         *    "Code":错误代号,
         *    "Message":"错误标题",
         *    "Content":"错误详细信息"
         * }
         */
		[HttpPost("order_delivery")]
		[ApiAuthorization]
		public IActionResult OrderDelivery(OrderDeliveryPushContent content)
		{
			var request = new PushRequest
			{
				PushCode = content.PushCode,
				PushType = PushType.Notification,
				DataType = PushDataType.Legwork_OrderDelivery,
				Parameters = content,
				Message = Configs.GetResource("${Legwork.OrderDelivery.Message}", content.WorkerName ?? "跑腿小哥")
			};

			// 推送给用户端。
			var response = PushProviderFactory.UserClient.Send(request);

			return Success(response.Success);
		}

		/**
         * @apiVersion 1.0.0
         * @apiDescription 工作人员选择线上支付,推送给用户端，请求用户支付。
         * @api {post} /v1/legwork/request_payment 请求支付
         * @apiSampleRequest /v1/legwork/request_payment
         * @apiName RequestPayment
         * @apiGroup Legwork
         * @apiPermission All
         *
         * @apiParam {string} PushCode 需要推送给用户端的推送号。
         * @apiParam {long} OrderID 订单ID。
         * @apiParam {string} OrderCode 订单编号。
		 * @apiParam {decimal} GoodsAmount 商品费用。
		 * @apiParam {decimal} ServiceCharge 服务费用。
		 * @apiParam {decimal} ActualAmount 实际总额。
		 * @apiParam {short} OrderStatus 订单状态。
         *
         * @apiSuccessExample 正常输出：
         * {
		 *	  "Code": 0,
		 *	  "Message": null,
		 *	  "IsError": false,
		 *	  "Content": true
		 * }
         *
         * @apiErrorExample 错误输出:
         * {
         *    "Code":错误代号,
         *    "Message":"错误标题",
         *    "Content":"错误详细信息"
         * }
         */
		[HttpPost("request_payment")]
		[ApiAuthorization]
		public IActionResult RequestPayment(RequestPaymentPushContent content)
		{
			var request = new PushRequest
			{
				PushCode = content.PushCode,
				PushType = PushType.Notification,
				DataType = PushDataType.Legwork_RequestPayment,
				Parameters = content,
				Message = Configs.GetResource("${Legwork.RequestPayment.Message}")
			};

			// 推送给用户端。
			var response = PushProviderFactory.UserClient.Send(request);

			return Success(response.Success);
		}

		/**
         * @apiVersion 1.0.0
         * @apiDescription 用户线上支付成功,推送给工作人员。
         * @api {post} /v1/legwork/payment_complete 支付完成
         * @apiSampleRequest /v1/legwork/payment_complete
         * @apiName PaymentComplete
         * @apiGroup Legwork
         * @apiPermission All
         *
         * @apiParam {string} PushCode 需要推送给用户端的推送号。
         * @apiParam {long} OrderID 订单ID。
         * @apiParam {string} OrderCode 订单编号。
		 * @apiParam {string} UserName 用户昵称。
		 * @apiParam {decimal} Amount 支付金额。
         *
         * @apiSuccessExample 正常输出：
         * {
		 *	  "Code": 0,
		 *	  "Message": null,
		 *	  "IsError": false,
		 *	  "Content": true
		 * }
         *
         * @apiErrorExample 错误输出:
         * {
         *    "Code":错误代号,
         *    "Message":"错误标题",
         *    "Content":"错误详细信息"
         * }
         */
		[HttpPost("payment_complete")]
		[ApiAuthorization]
		public IActionResult PaymentComplete(PaymentCompletePushContent content)
		{
			var request = new PushRequest
			{
				PushCode = content.PushCode,
				PushType = PushType.Notification,
				DataType = PushDataType.Legwork_PaymentComplete,
				Parameters = content,
				Message = Configs.GetResource("${Legwork.PaymentComplete.Message}")
			};

			// 推送给工作端。
			var response = PushProviderFactory.WorkerClient.Send(request);

			return Success(response.Success);
		}
	}
}