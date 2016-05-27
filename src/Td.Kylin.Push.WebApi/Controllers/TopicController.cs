using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Td.Kylin.WebApi;
using Td.Kylin.WebApi.Filters;
using Td.Kylin.Push.Messages.Topic;

namespace Td.Kylin.Push.WebApi.Controllers
{
	[Route("v1/topic")]
	public class TopicController : BaseController
	{
		/**
		 * @apiVersion 1.0.0
		 * @apiDescription 帖子删除推送。
		 * @api {post} /v1/topic/delete 帖子删除推送
		 * @apiSampleRequest /v1/topic/delete
		 * @apiName TopicDelete
		 * @apiGroup Topic
		 * @apiPermission All
		 *
		 * @apiParam {long} TopicID 帖子ID
		 * @apiParam {string} UserIDs 报名用户id集合，多个id使用","隔开
		 * @apiParam {string} Title 帖子标题
		 * @apiParam {string} AreaFormName 区域圈子名称
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
		[HttpPost("delete")]
		[ApiAuthorization]
		public IActionResult TopicDelete(TopicDeletePushContent content)
		{
			var request = new PushRequest
			{
				//				PushCode = content.PushCode,
				DataType = PushDataType.SendOrder,
				Parameters = content,
				Message = content.Contents
			};

			// 推送给用户端。
			var response = PushProviderFactory.UserClient.Send(request);

			return Success(response.Success);
		}
	}
}
