using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Transactions.Infrastructure.DbContexts;
using Transactions.Infrastructure.Interfaces;
using Transactions.Infrastructure.Repositories;

namespace Transactions.Infrastructure
{
    public static class DependencyInjection
    { 
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>();

            services.AddScoped<ITransactionRepository, TransactionRepository>();

            return services;
        }
    }
}
