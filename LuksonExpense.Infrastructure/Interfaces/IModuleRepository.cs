using LuksonExpense.Domain.Models;

namespace LuksonExpense.Infrastructure.Interfaces
{
    public interface IModuleRepository
    {
        Task<IEnumerable<Module>> List();

        Task<Module?> GetByName(string name);

        Task<Module> Add(Module module);
    }
}
