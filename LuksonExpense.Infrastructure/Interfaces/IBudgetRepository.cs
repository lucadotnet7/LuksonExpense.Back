using LuksonExpense.Domain.Models;

namespace LuksonExpense.Infrastructure.Interfaces
{
    public interface IBudgetRepository
    {
        Task<Budget> Add(Budget budget);
        Task<Budget?> GetById(Guid budgetId, Guid userId);
        Task<IEnumerable<Budget>> GetList(Guid userId);
        Task<Budget> Update(Budget budget);
        Task Delete(Budget budget);
    }
}
