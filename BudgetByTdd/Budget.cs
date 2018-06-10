using System;

namespace BudgetByTdd
{
    public class Budget
    {
        public string YearMonth { get; set; }
        public int Amount { get; set; }

        public DateTime FirstDay
        {
            get
            {
                return DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);
            }
        }

        public DateTime LastDay
        {
            get
            {
                var daysInMonth = DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);
                return DateTime.ParseExact(YearMonth + daysInMonth, "yyyyMMdd", null);
            }
        }
    }
}