using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using SimulasiyaPronia.DAL;
using SimulasiyaPronia.Models;

namespace SimulasiyaPronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Category()
        {
            var categories = _context.Categories.ToList();
            return View(categories);

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Category");
        }
    }
}
