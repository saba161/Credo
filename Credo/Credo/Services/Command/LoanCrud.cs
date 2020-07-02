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
                    LoanStatus = LoanStatus.Rejected,
                    LoanType = loan.LoanType,
                    Period = loan.Period
                });

            _context.SaveChanges();

            return "Added";
        }

        public string Edit(Loan loan, int loanId)
        {
            var currentLoan = _context.Loans.Where(x => x.Id == loanId).FirstOrDefault();

            if (loan.LoanStatus != LoanStatus.Approved || loan.LoanStatus != LoanStatus.Rejected)
            {
                currentLoan.Amount = loan.Amount;
                currentLoan.Currency = loan.Currency;
                currentLoan.LoanType = loan.LoanType;
                currentLoan.Period = loan.Period;

                _context.SaveChanges();

                return "Updated";
            }

            return "can't edit this loan";
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
