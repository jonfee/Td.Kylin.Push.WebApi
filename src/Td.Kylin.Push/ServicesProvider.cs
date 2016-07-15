using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Td.Kylin.EnumLibrary;
using Td.Kylin.Push.Data.Context;
using Td.Kylin.Push.Data.IServices;
using Td.Kylin.Push.Data.Services;

namespace Td.Kylin.Push.Data
{
    public class ServicesProvider
    {
        private static readonly object myLock = new object();
        private static ServicesProvider _service;
        public ServicesProvider()
        {
            switch (ConfigRoot.SqlType)
            {
                case SqlProviderType.SqlServer:
                    InitServices<SqlServerDataContext>();
                    break;
                case SqlProviderType.NpgSQL:
                    InitServices<PostgreSqlDataContext>();
                    break;
                default:
                    break;
            }
        }
        public static ServicesProvider Items
        {
            get
            {
                if (_service == null)
                {
                    lock (myLock)
                    {
                        if (_service == null)
                        {
                            _service = new ServicesProvider();
                        }
                    }
                }
                return _service;
            }
        }


        public ILegworkOrderServices LegworkOrderServices { get; set; }

        private void InitServices<T>() where T : DataContext, new()
        {
            LegworkOrderServices = new LegworkOrderServices<T>();
        }
    }
}
