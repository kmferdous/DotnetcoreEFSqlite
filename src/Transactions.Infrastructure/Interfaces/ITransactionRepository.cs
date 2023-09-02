using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Domain.Entities;
using Transactions.Domain.Enums;

namespace Transactions.Infrastructure.Interfaces
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        Task<Transaction?> GetByTransactionIdAsync(string transactionId);

        Task<int> SuccessfulTransactionsCountAsync();

        Task<decimal> SuccessfulTransactionsAmountAsync(CurrencyEnum toCurrency);
    }
}
