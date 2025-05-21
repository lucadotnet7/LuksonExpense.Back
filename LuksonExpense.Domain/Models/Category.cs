using LuksonExpense.Domain.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuksonExpense.Domain.Models
{
    [Table("Categories")]
    public sealed class Category : DatabaseModel<int>
    {
        [Required]
        [StringLength(80)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [Column(TypeName = "text")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [ForeignKey("ExpenseId")]
        public Guid ExpenseId { get; set; }
        public Expense? Expense { get; set; }
    }
}
