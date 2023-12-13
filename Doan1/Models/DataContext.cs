using Microsoft.EntityFrameworkCore;
using Doan1.Areas.Admin.Models;
namespace Doan1.Models
{
	public class DataContext : DbContext
	{
		public DataContext() { }
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }
		public DbSet<Menu> Menus { get; set; }
		public DbSet<BookCategory> BookCategorys { get; set; }
		public DbSet<AdminMenu> AdminMenus { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<AdminUser> AdminUsers { get; set; }
	}
}
