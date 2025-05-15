using System.ComponentModel.DataAnnotations;

namespace LuksonExpense.Domain.Shared
{
    public class DatabaseModel<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
