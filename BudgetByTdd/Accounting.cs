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
                var total = 0m;
                foreach (var budget in budgets)
                {
                    var overlapAmount = budget.OverlapAmount(period);
                    total += overlapAmount;
                }
                return total;
            }

            return 0;
        }
    }
}