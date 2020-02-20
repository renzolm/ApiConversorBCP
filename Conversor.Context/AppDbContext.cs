using Conversor.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace Conversor.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<EMoneda> moneda { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
