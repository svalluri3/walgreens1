using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Walgreens.Models;

namespace Walgreens.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WalgreensContext _context;

        public HomeController(ILogger<HomeController> logger, WalgreensContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Get prescriptions from the database
            var prescriptions = _context.Prescriptions.ToList();

            // Pass them to the view
            return View(prescriptions);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
