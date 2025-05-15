using LuksonExpense.Domain.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuksonExpense.Domain.Models
{
    [Table("Expenses")]
    public sealed class Expense : DatabaseModel<Guid>
    {
        [Required]
        [StringLength(80)]
        public string Name { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [ForeignKey("BudgetId")]
        public Guid BudgetId { get; set; }
        public Budget Budget { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
