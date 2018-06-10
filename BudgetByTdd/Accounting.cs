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
            if (budgets.Any())
            {
                var days = (end - start).Days + 1;
                return days;
            }
            return 0;
        }
    }
}