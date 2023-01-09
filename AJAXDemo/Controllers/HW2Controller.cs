using AJAXDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace AJAXDemo.Controllers
{
    public class HW2Controller : Controller
    {
        private readonly DemoContext _context;

        public HW2Controller(DemoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult login(string name)
        {
            var result = _context.Members.FirstOrDefault(c => c.Name == name);
            if (result == null)
                return Content($"0");
            else return Content($"{result.Name}");

        }
    }
}
