using Microsoft.EntityFrameworkCore;

namespace PlatformsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts):base(opts)
        {

        }

        public DbSet<PlatformModel> Platforms { get; set; }
    }
}
