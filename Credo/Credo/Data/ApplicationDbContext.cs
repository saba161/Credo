using System;
using System.Collections.Generic;
using System.Text;
using Credo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Credo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Loan> Loans { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
