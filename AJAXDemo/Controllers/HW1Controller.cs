using Microsoft.AspNetCore.Mvc;

namespace AJAXDemo.Controllers
{
    public class HW1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
