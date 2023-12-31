﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Domain.Enums;

namespace Transactions.Application.DTOs
{
    public class Transaction
    {
        public int Id { get; set; }

        public string TransactionId { get; set; }

        public DateTime TransactionDate { get; set; }
        
        public TransactionTypeEnum TransactionType { get; set; }
        
        public TransactionStatusEnum TransactionStatus { get; set; }
        
        public CurrencyEnum Currency { get; set; }
        
        public decimal Amount { get; set; }
        
        public string IBAN { get; set; }
        
        public string BBAN { get; set; }
    }
}
