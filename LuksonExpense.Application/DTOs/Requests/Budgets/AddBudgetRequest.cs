namespace LuksonExpense.Application.DTOs.Requests.Budgets
{
    public sealed class AddBudgetRequest
    {
        public string BudgetName { get; set; } = string.Empty;
        public string? BudgetDescription { get; set; }
        public DateOnly BudgetFrom { get; set; }
        public DateOnly BudgetTo { get; set; }
        public decimal Amount { get; set; }
    }
}
