using Microsoft.EntityFrameworkCore;
using Uploader.Model;

namespace Uploader.Services
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        { }

        public DbSet<Investment> Investments { get; set; }
        public DbSet<InvestmentTotal> InvestmentTotals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=Investment;Integrated Security=True");
            }
        }
    }
}
