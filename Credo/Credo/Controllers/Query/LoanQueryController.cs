using Credo.Services.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

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
            try
            {
                var currUser = userManager.GetUserId(HttpContext.User);

                var loans = loanQuery.UserWithLoan(currUser);

                return View(loans);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new ArgumentException();
            }
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            return View();
        }
    }
}
