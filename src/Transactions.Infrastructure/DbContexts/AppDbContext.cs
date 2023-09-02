using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Transactions.Domain.Entities;
using Transactions.Infrastructure.Configs;

namespace Transactions.Infrastructure.DbContexts
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public AppDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(configuration.GetConnectionString("TransactionDatabase"));

            base.OnConfiguring(optionsBuilder); 
        }

        public void MigrateDatabase()
        {
            this.Database.Migrate();
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
