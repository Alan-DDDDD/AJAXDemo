using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AJAXDemo.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "Ajax哈";
            }
            //Content("要傳送資料","content-type(["text/html","text/plain",......])",format編碼)
            return Content($"Hello {name}","text/html",Encoding.UTF8);
        }
    }
}
