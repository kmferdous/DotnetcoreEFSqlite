using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Infrastructure.DbContexts;

namespace Transactions.Infrastructure
{
    public static class Initializer
    {
        public static void Initialize(IConfiguration configuration)
        {
            var dbContext = new AppDbContext(configuration);
            
            dbContext.MigrateDatabase();
        }
    }
}
