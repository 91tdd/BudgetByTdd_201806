using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace BudgetByTdd
{
    [TestClass]
    public class AccountingTests
    {
        [TestMethod]
        public void no_budgets()
        {
            var budgetRepository = Substitute.For<IBudgetRepository>();
            var accounting = new Accounting(budgetRepository);
            var start = new DateTime(2018, 6, 1);
            var end = new DateTime(2018, 6, 1);
            var totalAmount = accounting.TotalAmount(start, end);
            Assert.AreEqual(0m, totalAmount);
        }
    }
}