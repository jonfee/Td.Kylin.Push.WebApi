using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Td.Kylin.WebApi;
using Td.Kylin.WebApi.Filters;
using Td.Kylin.Push.Messages.User;

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
		    //content = new UserAuditPushContent()
		    //{
      //          PushCode = "021E6DD4C21330EB",
      //          UserID=123456,
      //          AuditStatus = 1,
      //          Contents = "测试"
      //      };

			var request = new PushRequest
			{
				PushCode = content.PushCode,
				DataType = PushDataType.UserAudit,
				Parameters = content,
				Message = content.Contents
			};

			// 推送给用户端。
			var response = PushProviderFactory.UserClient.Send(request);

			return Success(response.Success);
		}
	}
}
