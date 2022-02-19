using Microsoft.EntityFrameworkCore;

namespace CommandsAPI.Grpc
{
    public static class CallGrpcEndpointExts
    {
        public static void CallGrpc(this WebApplication app)
        {
            using(var scope = app.Services.CreateScope())
            {
                IGrpcClient client = scope.ServiceProvider.GetService<IGrpcClient>();
                AppDbContext ctx = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>().CreateDbContext();

                FillWithData(ctx, client);
            }
        }

        private static void FillWithData(AppDbContext ctx,IGrpcClient client)
        {
            try
            {
                var platforms = client.GetAllPlatforms();
                ctx.Platforms.AddRange(platforms);
                ctx.SaveChanges();
            }
            catch
            {
                //
            }
        }
    }
}
