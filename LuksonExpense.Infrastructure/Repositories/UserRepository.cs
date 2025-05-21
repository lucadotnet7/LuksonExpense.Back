using LuksonExpense.Domain.Models;
using LuksonExpense.Infrastructure.Database;
using LuksonExpense.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LuksonExpense.Infrastructure.Repositories
{
    public sealed class UserRepository(
        ApplicationDbContext context) : IUserRepository
    {
        public async Task<User> CreateUser(User user)
        {
            try
            {
                EntityEntry<User> entry = await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
                return entry.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteUser(User user)
        {
            try
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            try
            {
                User? user = await context.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User?> GetUserById(Guid userId)
        {
            try
            {
                User? user = await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
