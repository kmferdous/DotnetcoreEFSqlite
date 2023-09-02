using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Application.Mappers
{
    public static class TransactionMapper
    {
        public static DTOs.Transaction MapToDto(this Domain.Entities.Transaction transaction)
        {
            return new DTOs.Transaction
            {
                Id = transaction.Id,
                TransactionId = transaction.TransactionId,
                TransactionDate = transaction.TransactionDate,
                TransactionStatus = transaction.TransactionStatus,
                TransactionType = transaction.TransactionType,
                Amount = (decimal)transaction.Amount,
                Currency = transaction.Currency,
                IBAN = transaction.IBAN,
                BBAN = transaction.BBAN,
            };
        }

        /*public static Domain.Entities.Transaction MapToDto(this DTOs.Transaction transaction)
        {
            return new Domain.Entities.Transaction
            {
                Id = transaction.Id,
                TransactionId = transaction.TransactionId,
                TransactionDate = transaction.TransactionDate,
                TransactionStatus = transaction.TransactionStatus,
                TransactionType = transaction.TransactionType,
                Amount = transaction.Amount,
                Currency = transaction.Currency,
                IBAN = transaction.IBAN,
                BBAN = transaction.BBAN,
            };
        }*/
    }
}
