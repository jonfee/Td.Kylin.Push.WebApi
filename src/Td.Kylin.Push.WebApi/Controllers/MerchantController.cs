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
using Td.Kylin.Push.WebApi.JPushMessage.Merchant;

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
			bool success = false;

			try
			{
				JPushMessage.PushMessage message = new JPushMessage.PushMessage
				{
					Content = content,
					DataID = content.MerchantID,
					DataType = SysEnum.PushDataType.MerchantAudit,
					Title = content.Contents
				};

				//推送给用户
				KylinPushContext context = new KylinPushContext(Configs.JPushConfigs.MerchantJPushConfig, message);
				var result = context.Send();

				success = true;
			}
			catch(Exception ex)
			{
				ExceptionLoger loger = new ExceptionLoger();
				loger.Write("商家审核结果推送异常", ex);
			}

			return Success(success);
		}
	}
}
