using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Infrastructure.Interfaces;
using Transactions.Application.DTOs;
using Transactions.Application.Exceptions;
using Transactions.Application.Interfaces;
using Transactions.Application.Mappers;
using Transactions.Application.Requests;
using Transactions.Application.Responses;
using Transactions.Domain.Enums;
using Transactions.Domain.Logics;

namespace Transactions.Application.Services
{
    public class TransactionService : BaseService, ITransactionService
    {
        private readonly ITransactionRepository transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            var transactions = await transactionRepository.GetAllAsync();

            return transactions.Select(d => d.MapToDto());
        }

        public async Task<Transaction> GetAsync(int id)
        {
            var transaction = await transactionRepository.GetAsync(id);

            return transaction.MapToDto();
        }

        public async Task<Transaction?> GetByTransactionIdAsync(string transactionId)
        {
            var transaction = await transactionRepository.GetByTransactionIdAsync(transactionId);

            return transaction?.MapToDto();
        }


        public async Task<Transaction> Create(TransactionCreateRequest request)
        {
            if ((await GetByTransactionIdAsync(request.TransactionId)) != null)
            {
                throw new CommonErrorException("Same transaction Id already exists.");
            }

            var transactionEntity = new Domain.Entities.Transaction
            {
                TransactionId = request.TransactionId,
                TransactionDate = DateTime.UtcNow,
                TransactionStatus = request.TransactionStatus,
                TransactionType = request.TransactionType,
                Amount = (double) Math.Round(request.Amount, 2),
                Currency = request.Currency,
                IBAN = request.IBAN,
                BBAN = request.BBAN,
                CreatedBy = "1",
                CreatedDate = DateTime.UtcNow,
            };

            

            var createdTransaction = await transactionRepository.SaveAsync(transactionEntity);

            return createdTransaction.MapToDto();
        }

        public async Task<SumUpTransactionResponse> GetSumUpTransactions()
        {
            var totalCount = await transactionRepository.SuccessfulTransactionsCountAsync();

            var amountInUSD = await transactionRepository.SuccessfulTransactionsAmountAsync(CurrencyEnum.USD);

            var sumUpAmounts = new List<SumUpAmount>();
            
            foreach (var currency in Enum.GetValues(typeof(CurrencyEnum)))
            {
                sumUpAmounts.Add(new SumUpAmount
                {
                    Currency = (CurrencyEnum)currency,
                    Amount = CurrencyKnowledgeBase.ConvertCurrency(amountInUSD, CurrencyEnum.USD,
                        (CurrencyEnum)currency),
                });
            }

            return new SumUpTransactionResponse
            {
                Count = totalCount,
                SumUpAmounts = sumUpAmounts,
            };
        }
    }
}
