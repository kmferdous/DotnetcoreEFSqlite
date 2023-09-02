using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Transactions.Domain.Entities;
using Transactions.Domain.Enums;
using Transactions.Domain.Logics;
using Transactions.Infrastructure.Configs;
using Transactions.Infrastructure.DbContexts;
using Transactions.Infrastructure.Interfaces;

namespace Transactions.Infrastructure.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        private readonly AppDbContext dbContext;

        public TransactionRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this.dbContext = appDbContext;
        }

        public Task<Transaction?> GetByTransactionIdAsync(string transactionId)
        {
            return dbContext.Transactions.AsQueryable()
                .Where(d => d.TransactionId == transactionId).FirstOrDefaultAsync();
        }

        public Task<int> SuccessfulTransactionsCountAsync()
        {
            return dbContext.Transactions.CountAsync(d => d.TransactionStatus == TransactionStatusEnum.Completed);
        }

        public Task<decimal> SuccessfulTransactionsAmountAsync(CurrencyEnum toCurrency)
        {
            var data = dbContext.Transactions.Where(d => d.TransactionStatus == TransactionStatusEnum.Completed)
                .Select(d => new { Amount = d.Amount, Currency = d.Currency })
                .AsEnumerable();

            return Task.FromResult(data.Sum(d => CurrencyKnowledgeBase.ConvertCurrency((decimal)d.Amount, d.Currency, toCurrency)));
        }
    }
}
