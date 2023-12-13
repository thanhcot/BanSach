using Doan1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Doan1.Components
{
    [ViewComponent(Name ="BookCategory")]
    public class BookCategoryComponent : ViewComponent
    {
        private readonly DataContext _context;
        public BookCategoryComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = (from p in _context.BookCategorys
                              where (p.IsActive == true)
                              orderby p.BookCategoryID descending
                              select p).Take(5).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", list));
        }
    }
}
