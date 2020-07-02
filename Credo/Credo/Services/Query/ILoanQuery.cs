using Credo.Models;
using System.Collections.Generic;
using System.Linq;

namespace Credo.Services.Query
{
    public interface ILoanQuery
    {
        List<Loan> UserWithLoan(string userId);
    }
}
