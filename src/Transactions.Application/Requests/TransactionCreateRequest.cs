using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Domain.Enums;

namespace Transactions.Application.Requests
{
    public class TransactionCreateRequest
    {
        public string TransactionId { get; set; }

        public TransactionTypeEnum TransactionType { get; set; }

        public TransactionStatusEnum TransactionStatus { get; set; }

        public CurrencyEnum Currency { get; set; }

        public decimal Amount { get; set; }

        public string IBAN { get; set; }

        public string BBAN { get; set; }
    }
}
