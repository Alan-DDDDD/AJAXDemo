using AJAXDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AJAXDemo.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;
        public ApiController(DemoContext context)
        {
            _context = context;
        }
        public IActionResult Index(string name)
        {
            //Thread.Sleep(5000);
            if (string.IsNullOrEmpty(name))
            {
                name = "Ajax哈";
            }
            //Content("要傳送資料","content-type(["text/html","text/plain",......])",format編碼)
            return Content($"Hello {name}","text/html",Encoding.UTF8);
        }

        public IActionResult City()
        {
            var cityDate = _context.Addresses.Select(c => new
            {
                c.City
            }).Distinct().OrderBy(c=>c.City);
            return Json(cityDate);
        }

        public IActionResult Site(string City)
        {
            var siteData = _context.Addresses.Where(c => c.City == City).Select(c => new
            {
                c.SiteId
            }).Distinct().OrderBy(c=>c.SiteId);
            return Json(siteData);
        }

        public IActionResult Road(string Site)
        {
            var RoadData = _context.Addresses.Where(c => c.SiteId == Site).Select(c=>c.Road).Distinct();
            return Json(RoadData);
        }

    }
}
