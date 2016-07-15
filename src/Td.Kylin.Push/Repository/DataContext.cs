
using Microsoft.EntityFrameworkCore;
using Td.Kylin.Entity;


namespace Td.Kylin.Push.Data.Context
{
    public abstract class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigRoot.SqlConnctionString);
        }

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Legwork_Order>().HasKey(t => t.OrderID);

        }
        #endregion

        #region Dbset
        public DbSet<Legwork_Order> Legwork_Order { get; set; }
        #endregion
    }
}