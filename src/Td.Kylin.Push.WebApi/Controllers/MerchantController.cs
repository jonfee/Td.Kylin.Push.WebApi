using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Td.Kylin.WebApi;
using Td.Kylin.WebApi.Filters;
using Td.Kylin.Push.Messages.Merchant;

namespace Td.Kylin.Push.WebApi.Controllers
{
	[Route("v1/merchant")]
	public class MerchantController : BaseController
	{
		/**
		 * @apiVersion 1.0.0
		 * @apiDescription 商家审核结果。
		 * @api {post} /v1/merchant/audit 商家审核结果
		 * @apiSampleRequest /v1/merchant/audit
		 * @apiName MerchantAudit
		 * @apiGroup Merchant
		 * @apiPermission All
		 *
		 * @apiParam {long} MerchantID 商家ID
		 * @apiParam {int} AuditStatus 审核状态
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
		/// 商家审核结果（推送给商家端）
		/// </summary>
		/// <returns></returns>
		[HttpPost("audit")]
		[ApiAuthorization]
		public IActionResult MerchantAudit(MerchantAuditPushContent content)
		{
			var request = new PushRequest
			{
//				PushCode = content.PushCode,
				DataType = PushDataType.MerchantAudit,
				Parameters = content,
				Message = content.Contents
			};

			// 推送给商家端。
			var response = PushProviderFactory.MerchantClient.Send(request);

			return Success(response.Success);
		}
	}
}
