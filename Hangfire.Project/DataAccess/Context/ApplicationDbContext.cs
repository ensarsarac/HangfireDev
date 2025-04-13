using Hangfire.Project.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hangfire.Project.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products{ get; set; }
    }
}
