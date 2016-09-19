using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Td.Kylin.WebApi;
using Td.Kylin.WebApi.Filters;
using Td.Kylin.Push.Messages.Topic;
using Td.Kylin.Push.WebApi.Messages.Topic;

namespace Td.Kylin.Push.WebApi.Controllers
{
	[Route("v1/topic")]
	public class TopicController : BaseController
	{
        /**
		 * @apiVersion 1.0.0
		 * @apiDescription 帖子置顶推送。
		 * @api {post} /v1/topic/top 帖子置顶推送
		 * @apiSampleRequest /v1/topic/top
		 * @apiName TopicTop
		 * @apiGroup Topic
		 * @apiPermission All
		 *
		 * @apiParam {long} TopicID 帖子ID
		 * @apiParam {long} UserID 用户id
		 * @apiParam {string} PushCode 推送号
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
        /// 帖子置顶推送
        /// </summary>
        /// <returns></returns>
        [HttpPost("top")]
		[ApiAuthorization]
		public IActionResult TopicTop(TopicTopPushContent content)
		{
			var request = new PushRequest
			{
				PushCode = content.PushCode,
				DataType = PushDataType.SendOrder,
				Parameters = content,
                Message = content.Content
			};

			// 推送给用户端。
			var response = PushProviderFactory.UserClient.Send(request);

			return Success(response.Success);
		}
	}
}
