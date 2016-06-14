using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Td.Kylin.Entity;

namespace Td.Kylin.Push.Data.IServices
{
    public interface ILegworkOrderServices
    {
        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        Legwork_Order GetModel(long OrderID);
    }
}
