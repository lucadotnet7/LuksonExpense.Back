using LuksonExpense.Domain.Models;

namespace LuksonExpense.Application.DTOs.MappingDtos.Budgets
{
    public sealed record class BudgetDTO
    {
        public string BudgetName { get; set; } = string.Empty;
        public string? BudgetDescription { get; set; }
        public string Period { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
    }
}
