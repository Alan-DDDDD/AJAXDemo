using AJAXDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AJAXDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DemoContext _context;

        public HomeController(ILogger<HomeController> logger, DemoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult member()
        {
            return View(_context.Members);
        }

        public IActionResult Address()
        {
            return View();
        }

        public IActionResult Fetch()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FirstAjax()
        {
            return View();
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