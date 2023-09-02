using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Transactions.Domain.Enums;

namespace Transactions.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        [Required]
        public string TransactionId { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public TransactionTypeEnum TransactionType { get; set; }
        
        [Required]
        public TransactionStatusEnum TransactionStatus { get; set; }

        [Required]
        public CurrencyEnum Currency { get; set; }
        
        [Required]
        [Range(0, 1000000)]
        public double Amount { get; set; }

        [Required]
        [StringLength(maximumLength:32)]
        public string IBAN { get; set; }

        [Required]
        [StringLength(maximumLength: 32)]
        public string BBAN { get; set; }
    }
}
