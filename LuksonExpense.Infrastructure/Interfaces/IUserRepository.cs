using LuksonExpense.Domain.Models;

namespace LuksonExpense.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserById(Guid userId);
        Task<User?> GetUserByEmail(string email);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(User user);
    }
}
