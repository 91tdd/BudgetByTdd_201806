using System;

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

        public decimal OverlappingDays(Budget budget)
        {
            if (HasNoOverlap(budget))
            {
                return 0;
            }

            var overlapStart = Start;
            var overlapEnd = End < budget.LastDay
                ? End
                : budget.LastDay;

            return (overlapEnd - overlapStart).Days + 1;
        }

        private bool HasNoOverlap(Budget budget)
        {
            return End < budget.FirstDay || Start > budget.LastDay;
        }
    }
}