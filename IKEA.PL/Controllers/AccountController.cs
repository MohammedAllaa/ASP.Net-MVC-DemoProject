using IKEA.DAL.Models.Users;
using IKEA.PL.ViewModel.AccountViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new ApplicationUser
            {
                FristName = model.FristName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email
            };
            var result = userManager.CreateAsync(user, model.Password).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Logic for user login will go here
            var User = userManager.FindByEmailAsync(model.Email).Result;
            if (User is not null) 
            {
                bool flag = userManager.CheckPasswordAsync(User, model.Password).Result;
                if (flag) 
                {
                    var result = signInManager.PasswordSignInAsync(User, model.Password, model.RememberMe, false).Result;
                    if (result.IsNotAllowed) { ModelState.AddModelError(string.Empty, "not Allowed"); }
                    if (result.IsLockedOut) { ModelState.AddModelError(string.Empty, "Lockedout"); }
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            return View(model);
        }

        public IActionResult SignOut()
        {
            signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }
    }
}
