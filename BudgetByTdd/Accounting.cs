using System;
using System.Linq;

namespace BudgetByTdd
{
    public class Period
    {
        public Period(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public int Days()
        {
            var days = (End - Start).Days + 1;
            return days;
        }
    }

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
                if (period.End < budgets[0].FirstDay)
                {
                    return 0;
                }

                return period.Days();
            }

            return 0;
        }
    }
}