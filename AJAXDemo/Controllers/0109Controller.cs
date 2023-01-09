using AJAXDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace AJAXDemo.Controllers
{
    public class _0109Controller : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _host;

        public _0109Controller(ILogger<HomeController> logger, DemoContext context, IWebHostEnvironment host)
        {
            _logger = logger;
            _context = context;
            _host = host;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index1(Member member,IFormFile photo)
        {
            //WebRootPath取得wwwroot路徑。Combine組合路徑。
            string photoPath = Path.Combine(_host.WebRootPath, "testupload", photo.FileName);
            if (System.IO.File.Exists(photoPath))
            {
                //photoPath = Path.Combine(_host.WebRootPath, "testupload", $"{(new Guid()).}");
            }
            using (var fileStream = new FileStream(photoPath, FileMode.Create))
            {
                photo.CopyTo(fileStream);
            }

            member.FileName = photo.FileName;
            byte[]? imgbyte = null;
            using (var memerystream = new MemoryStream())
            {
                photo.CopyTo(memerystream);
                imgbyte = memerystream.ToArray();
            }
            member.FileData = imgbyte;

            _context.Add(member);
            _context.SaveChanges();
                return Content($"Hello{member.Name},you are {member.Age} years old ,{member.Email}" +
                    $"<br/>{photoPath}", "text/html");
        }

    }
}
