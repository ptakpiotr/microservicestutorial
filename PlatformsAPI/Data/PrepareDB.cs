using Microsoft.EntityFrameworkCore;

namespace PlatformsAPI.Data
{
    public static class PrepareDB
    {
        public static void MigrateAndSeed(this WebApplication app)
        {
            using(var scope = app.Services.CreateScope())
            {
                AppDbContext ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                IWebHostEnvironment env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
                Migrate(ctx, env);
                Seed(ctx);
            }
        }

        private static void Migrate(AppDbContext ctx,IWebHostEnvironment env)
        {
            try
            {
                if (env.IsProduction())
                {
                    ctx.Database.Migrate();
                }
            }
            catch
            {

            }
        }

        private static void Seed(AppDbContext ctx)
        {
            if (!ctx.Platforms.Any())
            {
                ctx.Platforms.Add(new PlatformModel { Name = ".NET Core", Publisher = "Microsoft", Cost = 0M });
                ctx.Platforms.Add(new PlatformModel { Name = "Docker", Publisher = "Docker", Cost = 0M });
                ctx.Platforms.Add(new PlatformModel { Name = "PostgreSQL", Publisher = "PostgreSQL", Cost = 0M });

            }
        }

    }
}
