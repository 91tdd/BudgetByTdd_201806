using System.Collections.Generic;

namespace BudgetByTdd
{
    public interface IBudgetRepository
    {
        List<Budget> GetAll();
    }
}