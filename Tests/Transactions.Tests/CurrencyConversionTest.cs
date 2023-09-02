using Transactions.Domain.Enums;
using Transactions.Domain.Logics;

namespace Transactions.Tests
{
    public class CurrencyConversionTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCaseSource(nameof(Currency_Conversion_Cases))]
        public void Test_Currency_Conversion(decimal amount, CurrencyEnum fromCurrency, CurrencyEnum toCurrency, decimal expectedAmount)
        {
            var actualAmount = CurrencyKnowledgeBase.ConvertCurrency(amount, fromCurrency, toCurrency);

            Assert.That(actualAmount, Is.EqualTo(expectedAmount));
        }

        private static IEnumerable<TestCaseData> Currency_Conversion_Cases()
        {
            yield return new TestCaseData(10m, CurrencyEnum.USD, CurrencyEnum.USD, 10m);
            yield return new TestCaseData(10m, CurrencyEnum.USD, CurrencyEnum.SAR, 37.04m);
            yield return new TestCaseData(10m, CurrencyEnum.SAR, CurrencyEnum.USD, 2.7m);
            yield return new TestCaseData(10m, CurrencyEnum.SAR, CurrencyEnum.SAR, 10m);
        }
    }
}