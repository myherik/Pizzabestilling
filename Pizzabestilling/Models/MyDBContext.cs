using Microsoft.EntityFrameworkCore;

namespace Pizzabestilling.Models
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Kunde> Kunder { get; set; }
        public DbSet<Bestilling> Bestillinger { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}