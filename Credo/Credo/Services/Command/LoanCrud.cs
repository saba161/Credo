using Credo.Data;
using Credo.Models;
using Credo.Models.Enums;
using System;
using System.Linq;

namespace Credo.Services
{
    public class LoanCrud : ILoanCrud
    {
        private readonly ApplicationDbContext _context;

        public LoanCrud(ApplicationDbContext context)
        {
            _context = context;
        }

        public string AddLoan(Loan loan)
        {
            _context.Loans.Add(
                new Loan
                {
                    Amount = loan.Amount,
                    AppUser = loan.AppUser,
                    Currency = loan.Currency,
                    LoanStatus = LoanStatus.Forwarded,
                    LoanType = loan.LoanType,
                    Period = loan.Period
                });

            _context.SaveChanges();

            return "Added";
        }

        public string Edit(Loan loan, int loanId)
        {
            var currentLoan = _context.Loans.Where(x => x.Id == loanId).FirstOrDefault();

            if (currentLoan.LoanStatus == LoanStatus.Approved)
            {
                return "can't edit this loan";
            }

            if (currentLoan.LoanStatus == LoanStatus.Rejected)
            {
                return "can't edit this loan";
            }

            currentLoan.Amount = loan.Amount;
            currentLoan.Currency = loan.Currency;
            currentLoan.LoanType = loan.LoanType;
            currentLoan.Period = loan.Period;

            _context.SaveChanges();

            return "Updated";
        }

        public string Remove(int id)
        {
            var loan = _context.Loans.Where(x => x.Id == id).FirstOrDefault();

            _context.Remove(loan);
            _context.SaveChanges();

            return "Removed";
        }
    }
}
