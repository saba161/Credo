using Credo.Services.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

        [Authorize]
        public IActionResult Index()
        {
            var currUser = userManager.GetUserId(HttpContext.User);

            var loans = loanQuery.UserWithLoan(currUser);

            return View(loans);
        }
    }
}
