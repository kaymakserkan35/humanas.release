using humanas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace humanas.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        public IActionResult Auth()
        {
            return View();
        }

      
    }
}