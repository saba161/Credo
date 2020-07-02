using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Credo.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Credo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
