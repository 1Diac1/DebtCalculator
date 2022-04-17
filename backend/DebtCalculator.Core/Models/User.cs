using System.Collections.Generic;

namespace DebtCalculator.Core.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Debt> Debts { get; set; } = new List<Debt>();
    }
}
