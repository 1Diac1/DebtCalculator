using System.ComponentModel.DataAnnotations;

namespace DebtCalculator.Core.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
