using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Td.Kylin.Push.WebApi.JPushMessage.User;
using Td.Kylin.Push.WebApi.JPushProvider;
using Td.Kylin.Push.WebApi.Core;
using Td.Kylin.Push.WebApi.Loger;
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
         * @api {get} /v1/appoint/pushshangmen 用户上门服务下单
         * @apiSampleRequest /v1/appoint/pushshangmen
         * @apiName PushShangMenOrder
         * @apiGroup Appoint
         * @apiPermission All
         *
         * @apiParam {long} OrderID 上门订单ID
         * @apiParam {long} UserID 下单的用户ID
         * @apiParam {string} UserName 下单的用户昵称
         * @apiParam {long} BusinessID 订单所属服务的业务ID
         * @apiParam {string} ServiceName 订单所属服务或业务的名称
         * @apiParam {int} Number 数量
         * @apiParam {string} Unit 单位(如：小时)
         * @apiParam {string} Address 上门服务的地址
         * @apiParam {datetime} ServiceTime 服务时间
         * @apiParam {datetime} CreateTime 下单时间
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
        [HttpGet("lottery")]
        [ApiAuthorization]
        public IActionResult LotteryResult(WelfareWinnerContent content)
        {
            bool success = false;

            try
            {
                JPushMessage.PushMessage message = new JPushMessage.PushMessage
                {
                    Content = content,
                    DataID = content.WelfarePhaseID,
                    DataType = SysEnum.PushDataType.WelfareWinResult,
                    FilterUsers = content.UserIDs,
                    Title = string.Format("参与的福利活动中奖啦！(奖品：{0})", content.WelfareName)
                };

                //推送给用户
                KylinPushContext context = new KylinPushContext(Configs.JPushConfigs.UserJPushConfig, message);
                var result = context.Send();

                success = true;
            }
            catch (Exception ex)
            {
                ExceptionLoger loger = new ExceptionLoger();
                loger.Write("福利中奖消息推送异常", ex);
            }

            return KylinOk(success);
        }
    }
}
