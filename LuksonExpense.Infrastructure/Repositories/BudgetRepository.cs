using LuksonExpense.Domain.Models;
using LuksonExpense.Infrastructure.Database;
using LuksonExpense.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LuksonExpense.Infrastructure.Repositories
{
    public sealed class BudgetRepository(ApplicationDbContext context) : IBudgetRepository
    {
        public async Task<Budget> Add(Budget budget)
        {
            try
            {
                EntityEntry<Budget> entry = await context.Budgets.AddAsync(budget);
                await context.SaveChangesAsync();

                return entry.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
