using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Doan1.Areas.Admin.Models;
using Doan1.Models;
using Doan1.Ulitities;

namespace Doan1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DataContext _context;
        public LoginController(DataContext context)
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
            string pw = Functions.MD5Password(user.Password);
            var check = _context.AdminUsers.Where(m => (m.Email == user.Email) && (m.Password == pw)).FirstOrDefault();
            if (check == null)
            {
                Functions._Message = "Tên hoặc mật khẩu không hợp ";
                return RedirectToAction("Index", "Login");
            }
            Functions._Message = string.Empty;
            Functions._UserID = check.UserID;
            Functions._UserName = string.IsNullOrEmpty(check.UserName) ? string.Empty : check.UserName;
            Functions._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;
           


            return RedirectToAction("Index", "Home");
        }
    }
}