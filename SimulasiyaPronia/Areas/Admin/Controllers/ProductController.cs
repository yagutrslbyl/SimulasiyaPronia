using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimulasiyaPronia.DAL;

namespace SimulasiyaPronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        

        AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Product()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            
            return View();
        }
    }
}
