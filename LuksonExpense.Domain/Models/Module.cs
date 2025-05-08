using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LuksonExpense.Domain.Shared;

namespace LuksonExpense.Domain.Models
{
    [Table("Modules")]
    public class Module : DatabaseModel<int>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Description { get; set; }

        [StringLength(50)]
        public string? IconName { get; set; }

        [Required]
        [StringLength(100)]
        public string Route { get; set; } = string.Empty;
    }
}
