using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Domain.Enums;

namespace Transactions.Application.Responses
{
    public class SumUpTransactionResponse
    {
        public int Count { get; set; }
        public List<SumUpAmount> SumUpAmounts { get; set; }
    }

    public class SumUpAmount
    {
        public decimal Amount { get; set; }

        public CurrencyEnum Currency { get; set; }
    }
}
