using Microsoft.EntityFrameworkCore;

namespace _253502_Melikava.Persistence.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            Database.EnsureCreated();
        }

        //Определение DbSet для сущностей
        public DbSet<MenuPosition> MenuPositions { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
