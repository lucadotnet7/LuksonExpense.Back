using LuksonExpense.Domain.Models;
using LuksonExpense.Infrastructure.Database;
using LuksonExpense.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LuksonExpense.Infrastructure.Repositories
{
    public sealed class ModuleRepository(ApplicationDbContext context) : IModuleRepository
    {
        public async Task<IEnumerable<Module>> List()
        {
            IEnumerable<Module> modules = await context.Modules.ToListAsync();

            return modules;
        }

        public async Task<Module?> GetByName(string name) 
        {
            Module? module = await context.Modules.FirstOrDefaultAsync(m => m.Name.Equals(name));

            return module;
        }

        public async Task<Module> Add(Module module)
        {
            try
            {
                EntityEntry<Module> entry = await context.Modules.AddAsync(module);
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
