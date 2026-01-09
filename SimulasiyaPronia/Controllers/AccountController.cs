using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimulasiyaPronia.Models;
using SimulasiyaPronia.ViewModels;

namespace SimulasiyaPronia.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
                return View(loginVM);
            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            var result = await _signInManager.PasswordSignInAsync(user,
                loginVM.Password, false,false
                );

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Email və ya şifrə yanlışdır");
                return View(loginVM);
            }

            return RedirectToAction("Index", "Home");
        }








        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registervm)
        {
            if (!ModelState.IsValid)
            {
                return View(registervm);
            }
            AppUser user = new()
            {
                Name = registervm.Name,
                Surname=registervm.Surname,
                UserName=registervm.Name,
                Email=registervm.Email,

            };
            IdentityResult result = await _userManager.CreateAsync(user, registervm.Password);
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    return View(registervm);
                }
            }
            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("login");

        }
    }
}
