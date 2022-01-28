using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using WebsiteProject.Models;

namespace WebsiteProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public LoginController(SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            var user = await _userManager.FindByNameAsync(model.username);
            string password = BCrypt.Net.BCrypt.HashPassword(user.password);
            if (user != null)
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
