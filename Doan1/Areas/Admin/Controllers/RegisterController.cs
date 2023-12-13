using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Doan1.Areas.Admin.Models;
using Doan1.Models;
using Doan1.Ulitities;

namespace Doan1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly DataContext _context;
        public RegisterController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminUser user)
        {
            if (user == null)
            {
                return NotFound();
            }
            var check = _context.AdminUsers.Where(m => m.Email == user.Email).FirstOrDefault();
            if (check != null)
            {
                Functions._MessageEmail = "Duplication Email";
                return RedirectToAction("Index", "Register");
            }
            Functions._MessageEmail = string.Empty;
            user.Password = Functions.MD5Password(user.Password);
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}