using _444.Models;
using Microsoft.EntityFrameworkCore;

namespace _444.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }
    }
}