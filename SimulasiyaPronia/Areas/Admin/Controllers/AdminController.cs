using Microsoft.AspNetCore.Mvc;

namespace SimulasiyaPronia.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
       


    }
}
