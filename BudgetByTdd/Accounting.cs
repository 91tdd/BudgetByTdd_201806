using System;
using System.Linq;

namespace BudgetByTdd
{
    public class Accounting
    {
        private readonly IBudgetRepository _budgetRepository;

        public Accounting(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public decimal TotalAmount(DateTime start, DateTime end)
        {
            var period = new Period(start, end);
            return _budgetRepository.GetAll().Sum(b => b.OverlapAmount(period));
        }
    }
}