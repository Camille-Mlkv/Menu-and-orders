using Microsoft.EntityFrameworkCore;

namespace _253502_Melikava.Persistence.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        {
            Database.EnsureCreated();
        }
    }
}
