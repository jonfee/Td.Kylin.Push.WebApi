﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Td.Kylin.Push.WebApi.Messages.Worker;
using Td.Kylin.WebApi;
using Td.Kylin.WebApi.Filters;

namespace Td.Kylin.Push.WebApi.Controllers
{
    [Route("v1/worker")]
    public class WorkerController : BaseController
    {
        /**
		 * @apiVersion 1.0.0
		 * @apiDescription 跑腿业务审核结果。
		 * @api {post} /v1/user/audit 跑腿业务审核结果
		 * @apiSampleRequest /v1/user/audit
		 * @apiName UserAudit
		 * @apiGroup User
		 * @apiPermission All
		 *
		 * @apiParam {long} UserID 用户ID
		 * @apiParam {string} PushCode 推送号
		 * @apiParam {string} Contents 内容
		 * @apiParam {bool} Status True为通过False为未通过
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
        public IActionResult UserAudit(WorkAuditPushContent content)
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
                DataType = content.Status ? PushDataType.LegworkAudit : PushDataType.LegworkAuditFail,
                Parameters = content,
                Message = content.Contents
            };

            // 推送给用户端。
            var response = PushProviderFactory.WorkerClient.Send(request);

            return Success(response.Success);
        }
    }
}
