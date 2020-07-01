using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CredoLoans.Models
{
    public class AppUser : IdentityUser
    {
        public List<Loan> Loans { get; set; }
    }
}
