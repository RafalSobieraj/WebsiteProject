using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebsiteProject.Data;
using WebsiteProject.Models;

namespace WebsiteProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly MyDbContext _context;

        public UsersController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ICollection<User> users = _context.Users.Include(e => e.UserInfo).Include(r => r.Role).ToList();
            return View("~/Views/Home/UserView.cshtml", users);
        }
    }
}
