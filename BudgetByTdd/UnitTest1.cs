using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace BudgetByTdd
{
    [TestClass]
    public class AccountingTests
    {
        private IBudgetRepository _budgetRepository = Substitute.For<IBudgetRepository>();
        private Accounting _accounting;

        [TestInitialize]
        public void TestInit()
        {
            _accounting = new Accounting(_budgetRepository);
        }

        [TestMethod]
        public void no_budgets()
        {
            AmountShouldBe(0m, "20180601", "20180601");
        }

        private void AmountShouldBe(decimal expected, string startTime, string endTime)
        {
            DateTime start = DateTime.ParseExact(startTime, "yyyyMMdd", null);
            DateTime end = DateTime.ParseExact(endTime, "yyyyMMdd", null);
            Assert.AreEqual(expected, _accounting.TotalAmount(start, end));
        }
    }
}