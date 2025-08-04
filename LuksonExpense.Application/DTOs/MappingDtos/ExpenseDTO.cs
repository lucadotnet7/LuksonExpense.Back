using LuksonExpense.Domain.Models;

namespace LuksonExpense.Application.DTOs.MappingDtos
{
    public sealed record class ExpenseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public Budget? Budget { get; set; }
        public Category? Category { get; set; }
    }
}
