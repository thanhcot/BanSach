using Microsoft.AspNetCore.Mvc;
using Doan1.Models;

namespace Doan1.Controllers
{
    public class BookController : Controller
    {
        private readonly DataContext _context;
        public BookController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var items = _context.Books.Where(m=>m.IsActive==true).ToList();
            return View(items);
        }

        public IActionResult List(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var list = _context.Books.Where(m => (m.BookCategoryID == id) && (m.IsActive == true)).ToList();
            if (list == null)
            {
                return NotFound();
            }
            return View(list);
        }
      
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = _context.Books
                .FirstOrDefault(m => (m.BookID == id) && (m.IsActive == true));
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
    }
}
