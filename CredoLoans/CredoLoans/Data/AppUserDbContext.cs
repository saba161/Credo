using CredoLoans.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredoLoans.Data
{
    public class AppUserDbContext : IdentityDbContext<AppUser>
    {
        public AppUserDbContext(DbContextOptions options)
            :base(options)
            
        {

        }
    }
}
