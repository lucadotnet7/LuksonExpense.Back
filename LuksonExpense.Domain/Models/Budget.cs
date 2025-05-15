using LuksonExpense.Domain.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuksonExpense.Domain.Models
{
    [Table("Budgets")]
    public sealed class Budget : DatabaseModel<Guid>
    {
        [Required]
        [StringLength(80)]
        public string Name { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateOnly FromDate { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateOnly ToDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public ICollection<Expense> Expenses { get; set; }
    }
}
