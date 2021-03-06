﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Td.Kylin.WebApi;
using Td.Kylin.WebApi.Filters;
using Td.Kylin.Push.Messages.Merchant;
using Td.Kylin.Push.WebApi.Messages.Merchant;

namespace Td.Kylin.Push.WebApi.Controllers
{
    [Route("v1/merchant")]
    [Obsolete("商家相关业务搁置，直接忽略")]
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

        /**
		 * @apiVersion 1.0.0
		 * @apiDescription 用户催单推送给商家端
		 * @api {post} v1/merchant/msgbuy 用户催单推送给商家端
		 * @apiSampleRequest v1/merchant/msgbuy
		 * @apiName MessageBuy
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
        /// 用户催单推送给商家端
        /// </summary>
        /// <returns></returns>
        [HttpPost("msgbuy")]
        [ApiAuthorization]
        public IActionResult MessageBuy(UserMessageBuyContent content)
        {
            //content = new UserMessageBuyContent()
            //{
            //    PushCode = "ABA716DD6A03418B",
            //    OrderID = 6306769615716417538,
            //    CreateTime = DateTime.Now,
            //    OrderCode = "216071319270969293",
            //    Contents = "用户催单"
            //};
            var request = new PushRequest
            {
                PushCode = content.PushCode,
                DataType = PushDataType.UserMessageBuy,
                Parameters = content,
                Message = "用户催单：订单编号【" + content.OrderCode + "】"
            };



            // 推送给商家端。
            var response = PushProviderFactory.MerchantClient.Send(request);

            return Success(response.Success);
        }
    }
}
