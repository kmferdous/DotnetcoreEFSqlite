using Microsoft.AspNetCore.Mvc;
using Transactions.Application.Interfaces;
using Transactions.Application.Responses;
using Transactions.Application.Services;

namespace Transactions.Api.Controllers
{
    [Route("api/reports")]
    public class ReportController : BaseController
    {
        private readonly ITransactionService transactionService;

        public ReportController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }


        [HttpGet("transactions/sumUpTransactions")]
        public async Task<ApiResponseModel<SumUpTransactionResponse>> GetSumUpTransactionsReport()
        {
            var transactions = await transactionService.GetSumUpTransactions();

            return new ApiResponseModel<SumUpTransactionResponse>(transactions);
        }
    }
}
