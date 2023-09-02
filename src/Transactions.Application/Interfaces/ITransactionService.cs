using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Application.DTOs;
using Transactions.Application.Requests;
using Transactions.Application.Responses;

namespace Transactions.Application.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetAllAsync();

        Task<Transaction> GetAsync(int id);

        Task<Transaction?> GetByTransactionIdAsync(string transactionId);

        Task<Transaction> Create(TransactionCreateRequest request);

        Task<SumUpTransactionResponse> GetSumUpTransactions();
    }
}
