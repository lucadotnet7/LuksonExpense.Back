using LuksonExpense.Domain.Shared;

namespace LuksonExpense.Domain.Models
{
    public sealed class User : DatabaseModel<Guid>
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool EmailVerified { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; } = false;
        public IEnumerable<Budget> Budgets { get; set; } = new List<Budget>();
    }
}
