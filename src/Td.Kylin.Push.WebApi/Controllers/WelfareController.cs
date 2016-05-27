using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Td.Kylin.Push.Messages.User;
using Td.Kylin.Push.Messages.Merchant;
using Td.Kylin.WebApi;
using Td.Kylin.WebApi.Filters;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Td.Kylin.Push.WebApi.Controllers
{
    [Route("v1/welfare")]
    public class WelfareController : BaseController
    {
        /**
         * @apiVersion 1.0.0
         * @apiDescription 此接口在用户针对上门服务下单成功后推送给相关业务的商家或个人服务人员
         * @api {post} /v1/welfare/lottery 用户上门服务下单
         * @apiSampleRequest /v1/welfare/lottery
         * @apiName LotteryResult
         * @apiGroup Welfare
         * @apiPermission All
         *
         * @apiParam {long} Welfare 福利ID
         * @apiParam {int} WelfareType 福利类型
         * @apiParam {long} WelfarePhaseID 福利活动ID
         * @apiParam {string} WelfareName 福利名称
         * @apiParam {long} MerchantID 福利提供商ID
         * @apiParam {string} MerchantName 福利提供商名称
         * @apiParam {long[]} UserIDs 中奖用户ID
         * @apiParam {datetime} LooeryTime 中奖时间
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
	    /// 福利开奖结果推送（推送给中奖用户）
	    /// </summary>
	    /// <returns></returns>
	    [HttpPost("lottery")]
	    [ApiAuthorization]
	    public IActionResult LotteryResult(WelfareWinnerContent content)
	    {
		    var request = new PushRequest
		    {
			    //				PushCode = content.PushCode,
			    DataType = PushDataType.WelfareWinResult,
				Parameters = content,
				Message = string.Format("参与的福利活动中奖啦！(奖品：{0})", content.WelfareName)
		    };

		    // 推送给用户端。
		    var response = PushProviderFactory.UserClient.Send(request);

		    return Success(response.Success);
	    }

	    /**
         * @apiVersion 1.0.0
         * @apiDescription 福利审核结果。
         * @api {post} /v1/welfare/audit 福利审核结果
         * @apiSampleRequest /v1/welfare/audit
         * @apiName WelfareAudit
         * @apiGroup Welfare
         * @apiPermission All
         *
         * @apiParam {long} MerchantID 商家ID
		 * @apiParam {long} WelfareID  福利ID
		 * @apiParam {string} WelfareName 福利名称
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
		/// 福利审核结果（推送给商家端）
		/// </summary>
		/// <returns></returns>
		[HttpPost("audit")]
		[ApiAuthorization]
		public IActionResult WelfareAudit(WelfareAuditPushContent content)
	    {
			var request = new PushRequest
			{
				//				PushCode = content.PushCode,
				DataType = PushDataType.WelfareAudit,
				Parameters = content,
				Message = content.Contents
			};

			// 推送给用户端。
			var response = PushProviderFactory.MerchantClient.Send(request);

			return Success(response.Success);
		}
    }
}
