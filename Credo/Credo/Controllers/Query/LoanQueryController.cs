using Credo.Data;
using Credo.Services;
using Credo.Services.Query;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Credo.Controllers.Query
{
    public class LoanQueryController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private ILoanQuery loanQuery;

        public LoanQueryController(ILoanQuery loanQuery, UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            this.loanQuery = loanQuery;
        }


        public IActionResult Index(string email)
        {
            var users = userManager.Users
                .Where(x => x.Email == email)
                .FirstOrDefault();

            var loans = loanQuery.UserWithLoan(users.Id);

            return View();
        }
    }
}
