using Credo.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Credo.Models
{
    public class AppUser : IdentityUser
    {
        public List<Loan> Loans { get; set; }
    }
}
