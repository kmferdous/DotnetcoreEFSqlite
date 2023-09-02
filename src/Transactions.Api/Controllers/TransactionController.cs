using Microsoft.AspNetCore.Mvc;
using Transactions.Application.DTOs;
using Transactions.Application.Interfaces;
using Transactions.Application.Requests;
using Transactions.Application.Responses;
using Transactions.Application.Services;

namespace Transactions.Api.Controllers
{
    [Route("api/transactions")]
    public class TransactionController : BaseController
    {
        private readonly ITransactionService transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponseModel<Transaction>> GetAsync(int id)
        {
            var transaction = await transactionService.GetAsync(id);

            return new ApiResponseModel<Transaction>(transaction);
        }

        [HttpGet("transactionId={transactionId}")]
        public async Task<ApiResponseModel<Transaction>> GetByTransactionIdAsync(string transactionId)
        {
            var transaction = await transactionService.GetByTransactionIdAsync(transactionId);

            return new ApiResponseModel<Transaction>(transaction);
        }

        [HttpGet]
        public async Task<ApiResponseModel<IEnumerable<Transaction>>> GetAllAsync()
        {
            var transactions = await transactionService.GetAllAsync();

            return new ApiResponseModel<IEnumerable<Transaction>>(transactions);
        }

        [HttpPost]
        public async Task<ApiResponseModel<Transaction>> Create(TransactionCreateRequest request)
        {
            var transaction = await transactionService.Create(request);

            return new ApiResponseModel<Transaction>(transaction);
        }

        
    }
}
