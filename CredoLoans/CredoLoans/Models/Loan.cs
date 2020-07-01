using CredoLoans.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredoLoans.Models
{
    public class Loan
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public int Period { get; set; }

        public Currency Currency { get; set; }

        public LoanType LoanType { get; set; }

        public LoanStatus LoanStatus { get; set; }
    }
}
