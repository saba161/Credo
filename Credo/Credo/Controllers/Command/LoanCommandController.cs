using Credo.Models;
using Credo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace Credo.Controllers.Command
{
    public class LoanCommandController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private ILoanCrud loanCrud;

        public LoanCommandController(ILoanCrud loanCrud, UserManager<IdentityUser> userManager)
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
            try
            {
                var currUser = userManager.GetUserId(HttpContext.User);
                loan.AppUser = currUser;
                var ressultStatus = loanCrud.AddLoan(loan);

                Logger(loan, ressultStatus);

                return ressultStatus;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new ArgumentException();
            }
        }

        [Authorize]
        [HttpPost]
        public string Edit(Loan loan, int Id)
        {
            try
            {
                var ressultStatus = loanCrud.Edit(loan, Id);

                Logger(loan, ressultStatus);

                return ressultStatus;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new ArgumentException();
            }
        }

        [Authorize]
        [HttpGet]
        public string Remove(int loanId)
        {
            try
            {
                var ressultStatus = loanCrud.Remove(loanId);
                Log.Information(ressultStatus);

                return ressultStatus;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new ArgumentException();
            }
        }

        private void Logger(Loan loan, string text)
        {
            Log.Information($"Amount: {loan.Amount} "
                + $"Currency: {loan.Currency} "
                + $"LoanStatus: {loan.LoanStatus} "
                + $"LoanType: {loan.LoanType} "
                + $"Period: {loan.Period} "
                + $"result: {text} ");
        }
    }
}