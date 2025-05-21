using LuksonExpense.Domain.Models;
using LuksonExpense.Infrastructure.Database;
using LuksonExpense.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LuksonExpense.Infrastructure.Repositories
{
    public sealed class BudgetRepository(ApplicationDbContext context) : IBudgetRepository
    {
        public async Task<Budget?> GetById(Guid budgetId)
        {
            try
            {
                Budget? budget = await context.Budgets.FirstOrDefaultAsync(x => x.Id == budgetId);

                return budget;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Budget>> GetList()
        {
            try
            {
                return await context.Budgets.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Budget> Add(Budget budget)
        {
            try
            {
                EntityEntry<Budget> entry = await context.Budgets.AddAsync(budget);
                await context.SaveChangesAsync();

                return entry.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Budget> Update(Budget budget)
        {
            try
            {
                Budget? existBudget = await context.Budgets.FirstOrDefaultAsync(x => x.Id == budget.Id);

                if (budget is null)
                    throw new ArgumentNullException($"No existe un presupuesto con id {budget!.Id}");

                existBudget = budget;
                context.Budgets.Update(existBudget);
                await context.SaveChangesAsync();

                return existBudget;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Delete(Budget budget)
        {
            try
            {
                context.Remove(budget);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
