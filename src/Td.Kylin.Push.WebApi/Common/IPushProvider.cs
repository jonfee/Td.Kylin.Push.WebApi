using System;
using System.Collections.Generic;

namespace Td.Kylin.Push
{
    public interface IPushProvider
    {
        string Name
        {
            get;
        }

        /// <summary>
        /// 推送
        /// </summary>
        /// <param name="request">自定义推送请求</param>
        /// <param name="pushIfPushCodeNull">推送号为null时是否继续推送</param>
        /// <param name="apnsProduction">是否非生产环境</param>
        /// <returns></returns>
        PushResponse Send(PushRequest message, bool pushIfPushCodeNull = false, bool apnsProduction = false);
    }
}
