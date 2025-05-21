using LuksonExpense.Domain.Models;

namespace LuksonExpense.Infrastructure.Interfaces
{
    public interface IBudgetRepository
    {
        Task<Budget> Add(Budget budget);
        Task<Budget?> GetById(Guid budgetId);
        Task<IEnumerable<Budget>> GetList();
        Task<Budget> Update(Budget budget);
        Task Delete(Budget budget);
    }
}
