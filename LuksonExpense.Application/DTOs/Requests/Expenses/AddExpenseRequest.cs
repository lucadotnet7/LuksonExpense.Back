namespace LuksonExpense.Application.DTOs.Requests.Expenses
{
    public record class AddExpenseRequest(string Name, string? Description, DateTime ExpenseDate, int CategoryId);
}
