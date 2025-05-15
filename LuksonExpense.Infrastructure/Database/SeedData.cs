using LuksonExpense.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LuksonExpense.Infrastructure.Database
{
    internal class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Module>().HasData(new Module { Id = 1, Name = "Inicio", Description = "Página de inicio", IconName = "HomeIcon", Route = "" });
            modelBuilder.Entity<Module>().HasData(new Module { Id = 2, Name = "Presupuestos", Description = "Sección donde se administran los presupuestos.", IconName = "AccountBalanceWalletIcon", Route = "/budgets" });
            modelBuilder.Entity<Module>().HasData(new Module { Id = 3, Name = "Gastos", Description = "Sección donde se administran los gastos", IconName = "CompareArrowsIcon", Route = "/expenses" });
            modelBuilder.Entity<Module>().HasData(new Module { Id = 4, Name = "Categorías", Description = "Sección donde se administran las categorías", IconName = "AutoAwesomeMosaicIcon", Route = "/categories" });
        }
    }
}
