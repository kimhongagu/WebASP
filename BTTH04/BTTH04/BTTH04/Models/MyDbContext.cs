using Microsoft.EntityFrameworkCore;

namespace BTTH04.Models
{
	public class MyDbContext : DbContext
	{
		public MyDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
	}

	
}
