using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Domain.Enums;

namespace Transactions.Domain.Logics
{
    public static class CurrencyKnowledgeBase
    {
        private static readonly Dictionary<CurrencyEnum, decimal> CurrencyRatesToUsd = new();

        static CurrencyKnowledgeBase()
        {
            CurrencyRatesToUsd.Add(CurrencyEnum.USD, 1);
            CurrencyRatesToUsd.Add(CurrencyEnum.SAR, 0.27m);
        }

        public static decimal ConvertCurrency(decimal amount, CurrencyEnum fromCurrency, CurrencyEnum toCurrency)
        {
            if (fromCurrency == toCurrency)
            {
                return Math.Round(amount, 2);
            }

            if (CurrencyRatesToUsd.TryGetValue(fromCurrency, out var fromCurrencyRateToUSD) == false)
            {
                throw new ArgumentOutOfRangeException($"Currency conversion rate not found for {fromCurrency.ToString()}");
            }

            if (CurrencyRatesToUsd.TryGetValue(toCurrency, out var toCurrencyRateToUSD) == false)
            {
                throw new ArgumentOutOfRangeException($"Currency conversion rate not found for {fromCurrency.ToString()}");
            }

            return Math.Round(amount * fromCurrencyRateToUSD / toCurrencyRateToUSD, 2);
        }
    }
}

