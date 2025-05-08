using LuksonExpense.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LuksonExpense.Infrastructure.Database
{
    internal class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Module>().HasData(new Module { Id = 1, Name = "Inicio", Description = "Página de inicio", IconName = "HomeIcon", Route = "" });
        }
    }
}
