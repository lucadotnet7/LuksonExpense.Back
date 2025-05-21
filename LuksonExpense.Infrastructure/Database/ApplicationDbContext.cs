using LuksonExpense.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LuksonExpense.Infrastructure.Database
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<Module> Modules { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData.Seed(modelBuilder);
        }
    }
}
