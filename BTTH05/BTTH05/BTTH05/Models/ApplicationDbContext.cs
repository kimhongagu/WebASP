using Microsoft.EntityFrameworkCore;

namespace BTTH05.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }
    }
}
