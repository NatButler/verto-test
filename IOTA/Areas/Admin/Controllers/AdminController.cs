using System.IO;
using IOTA.Areas.Admin.Data;
using IOTA.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IOTA.Areas.Admin.Controllers;
[Area("Admin")]

    public class AdminController : Controller
    {
        private readonly IOTADbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(IOTADbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var homePage = await _context.HomePage.FirstOrDefaultAsync(h => h.Id == 1);
            if (homePage == null)
            {
                return NotFound();
            }

            return View(homePage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,SliderOverlayHeading,TopBannerHeading,TopBannerText,CaseStudy1Heading,CaseStudy1Summary,CaseStudy2Heading,CaseStudy2Summary,CaseStudy3Heading,CaseStudy3Summary,ImageOverlayHeading,ImageOverlayText")] HomePage homePage)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homePage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine("There was an error!");
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return RedirectToAction(nameof(Index));
        }

    [HttpGet]
    public IActionResult Images()
    {
        // Read all .png files in uplaods directory and provide file names via ViewBag
        string uploadsDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "uploads");
        string[] images = Directory.GetFiles(uploadsDirectory, "*.png").Select(image => Path.GetFileName(image)).ToArray();
        ViewBag.SliderImages = images;
        
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upload(IFormFile image)
    {
        string uploadsDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "uploads");

        if (!Directory.Exists(uploadsDirectory))
        {
            Directory.CreateDirectory(uploadsDirectory);
        }

        string fileName = Path.GetFileName(image.FileName);
        string fileSavePath = Path.Combine(uploadsDirectory, fileName);

        using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
        {
            await image.CopyToAsync(stream);
        }

        return RedirectToAction(nameof(Images));
    }
}

