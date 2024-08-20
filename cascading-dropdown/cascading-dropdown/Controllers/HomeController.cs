using cascading_dropdown.Data;
using cascading_dropdown.Models;
using cascading_dropdown.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace cascading_dropdown.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Fetch categories and initialize ViewBag for dropdowns
            var categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");

            // Initialize products with an empty list
            var products = new List<Product>();
            ViewBag.Products = new SelectList(products, "Id", "Name");

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

        // Corrected action parameter name to match the view script
        public JsonResult ProductById(int categoryId)
        {
            // Return products that belong to the selected category
            var products = _context.Products
                                   .Where(p => p.CategoryId == categoryId)
                                   .Select(p => new { p.Id, p.Name })  // Select only necessary fields
                                   .ToList();
            return Json(products);
        }
    }
}
