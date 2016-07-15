using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Td.Kylin.Push.Data.Context
{
    public sealed class PostgreSqlDataContext : DataContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(ConfigRoot.SqlConnctionString);
        }
    }
}
