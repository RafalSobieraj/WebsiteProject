using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebsiteProject.Models;

namespace WebsiteProject.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public RegisterController(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            var user = new User
            {
                username = model.username,
                password = model.password

            };
            var result = await _userManager.CreateAsync(user, user.password);
            string password = BCrypt.Net.BCrypt.HashPassword(user.password);
            if (result.Succeeded)
            {
                var signIn = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (signIn.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }
    }
}
