using System.Diagnostics;
using IOTA.Areas.Admin.Data;
using IOTA.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IOTA.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOTADbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IOTADbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var homePage = await _context.HomePage.FirstOrDefaultAsync(h => h.Id == 1);
            if (homePage == null)
            {
                return NotFound();
            }

            // Read all .png files in uplaods directory and provide file names via ViewBag
            string uploadsDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "uploads");
            string[] images = Directory.GetFiles(uploadsDirectory, "*.png").Select(image => Path.GetFileName(image)).ToArray();
            ViewBag.SliderImages = images;

            return View(homePage);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
