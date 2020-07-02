﻿using Credo.Models;
using Credo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

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
        [HttpGet]
        public string Edit(Loan loan, int loanId)
        {
            var ressultStatus = loanCrud.Edit(loan, loanId);

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