using LuksonExpense.Domain.Models;

namespace LuksonExpense.Infrastructure.Interfaces
{
    public interface IBudgetRepository
    {
        Task<Budget> Add(Budget budget);
    }
}
