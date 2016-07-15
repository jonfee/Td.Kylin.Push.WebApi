using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Td.Kylin.Entity;
using Td.Kylin.Push.Data.IServices;
using Td.Kylin.Push.Data.Context;

namespace Td.Kylin.Push.Data.Services
{
    public class LegworkOrderServices<DbContext> : ILegworkOrderServices where DbContext : DataContext, new()
    {
        public Legwork_Order GetModel(long OrderID)
        {
            using (var db = new DbContext())
            {
                return db.Legwork_Order.FirstOrDefault(q => q.OrderID == OrderID);
            }
        }

    }
}
