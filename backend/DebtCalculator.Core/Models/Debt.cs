using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System;

namespace DebtCalculator.Core.Models
{
    public class Debt : BaseEntity
    {
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Modified { get; set; }
        public string Created { get; set; }

        public int UserId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual User User { get; set; }

        public int CreditorId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual User Creditor { get; set; }
    }
}
