using Credo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Credo.Services
{
    public interface ILoanCrud
    {
        string AddLoan(Loan loan);

        string Edit(Loan loan, int loanId);

        string Remove(int id);
    }
}
