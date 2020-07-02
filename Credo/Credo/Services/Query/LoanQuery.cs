using Credo.Data;
using Credo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Credo.Services.Query
{
    public class LoanQuery : ILoanQuery
    {
        private readonly ApplicationDbContext _context;

        public LoanQuery(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Loan> UserWithLoan(string userId)
        {
            var loan = _context.Loans
                .Where(x => x.AppUser == userId)
                .ToList();

            return loan;
        }
    }
}
