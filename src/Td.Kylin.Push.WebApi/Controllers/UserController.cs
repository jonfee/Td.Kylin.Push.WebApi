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
using Td.Kylin.Push.WebApi.JPushMessage.User;

namespace Td.Kylin.Push.WebApi.Controllers
{
	[Route("v1/user")]
	public class UserController : BaseController
	{
		/**
		 * @apiVersion 1.0.0
		 * @apiDescription 用户审核结果。
		 * @api {post} /v1/user/audit 用户审核结果
		 * @apiSampleRequest /v1/user/audit
		 * @apiName UserAudit
		 * @apiGroup User
		 * @apiPermission All
		 *
		 * @apiParam {long} UserID 用户ID
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
		/// 用户审核结果（推送给用户端）
		/// </summary>
		/// <returns></returns>
		[HttpPost("audit")]
		[ApiAuthorization]
		public IActionResult UserAudit(UserAuditPushContent content)
		{
			bool success = false;

			try
			{
				JPushMessage.PushMessage message = new JPushMessage.PushMessage
				{
					Content = content,
					DataID = content.UserID,
					DataType = SysEnum.PushDataType.UserAudit,
					Title = content.Contents
				};

				//推送给用户
				KylinPushContext context = new KylinPushContext(Configs.JPushConfigs.UserJPushConfig, message);
				var result = context.Send();

				success = true;
			}
			catch(Exception ex)
			{
				ExceptionLoger loger = new ExceptionLoger();
				loger.Write("用户审核结果推送异常", ex);
			}

			return Success(success);
		}
	}
}
