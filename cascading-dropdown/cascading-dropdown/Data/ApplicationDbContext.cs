using cascading_dropdown.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace cascading_dropdown.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
