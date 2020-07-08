using Credo.Models;
using Credo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Credo.Controllers.Command
{
    public class LoanController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private ILoanCrud loanCrud;

        public LoanController(ILoanCrud loanCrud, UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            this.loanCrud = loanCrud;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public string Create(Loan loan)
        {
            var currUser = userManager.GetUserId(HttpContext.User);
            loan.AppUser = currUser;
            var ressultStatus = loanCrud.AddLoan(loan);

            return ressultStatus;
        }

        [Authorize]
        [HttpPost]
        public string Edit(Loan loan, int Id)
        {
            var ressultStatus = loanCrud.Edit(loan, Id);

            return ressultStatus;
        }

        [Authorize]
        [HttpGet]
        public string Remove(int loanId)
        {
            var ressultStatus = loanCrud.Remove(loanId);

            return ressultStatus;
        }
    }
}