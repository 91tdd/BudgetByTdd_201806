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
            var budgets = _budgetRepository.GetAll();
            var period = new Period(start, end);
            if (budgets.Any())
            {
                var budget = budgets[0];
                return period.OverlappingDays(new Period(budget.FirstDay, budget.LastDay)) * budget.DailyAmount();
            }

            return 0;
        }
    }
}