using Microsoft.EntityFrameworkCore;
using PlatformsAPI;
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

services.AddScoped<IPlatformsRepo, PlatformsRepo>();
services.AddSingleton<IEventPublisher, EventPublisher>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseGlobalEndpoints();
app.MigrateAndSeed();
app.Run();