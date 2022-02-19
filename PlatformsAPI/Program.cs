using Microsoft.EntityFrameworkCore;
using PlatformsAPI;
using PlatformsAPI.Grpc;
using PlatformsAPI.Profiles;
using PlatformsAPI.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;
IWebHostEnvironment env = builder.Environment;

services.AddDbContext<AppDbContext>(opts =>
{
    //if (env.IsProduction())
    //{
        opts.UseNpgsql(configuration.GetConnectionString("MainConn"));
    //}
    //else
    //{
        //inmem
    //}
});

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddAutoMapper(typeof(MainProfile));
services.AddGrpc();

services.AddScoped<IPlatformsRepo, PlatformsRepo>();
services.AddSingleton<IEventPublisher, EventPublisher>();
services.AddScoped<IPlatformsGrpcService, PlatformsGrpcService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseGlobalEndpoints();
app.MapGrpcService<PlatformsGrpcService>();
app.MigrateAndSeed();
app.Run();