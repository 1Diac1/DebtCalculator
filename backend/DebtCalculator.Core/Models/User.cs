using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DebtCalculator.Core.Models
{
    public class User : IdentityUser<int>
    {
        [Key]
        public override int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Debt> Debts { get; set; } = new List<Debt>();
    }
}
