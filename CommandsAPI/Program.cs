using CommandsAPI.GraphQL;
using CommandsAPI.GraphQL.Types;
using CommandsAPI.Grpc;
using CommandsAPI.Polly;
using CommandsAPI.Profiles;
using CommandsAPI.RabbitMQ;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;

services.AddPooledDbContextFactory<AppDbContext>(opts =>
{
    opts.UseSqlServer(configuration.GetConnectionString("MainConn"));
});
services.AddSingleton<BrokerPolicy>();
services.AddSingleton<IEventProcessor, EventProcessor>();
services.AddScoped<IGrpcClient, GrpcClient>();
services.AddHostedService<EventSubscriber>();

services.AddAutoMapper(typeof(MainProfile));

services.AddGraphQLServer()
        .AddQueryType<Query>()
        .AddMutationType<Mutation>()
        .AddType<PlatformType>()
        .AddType<CommandType>()
        .AddFiltering()
        .AddSorting();



var app = builder.Build();

app.MapGraphQL("/graphql");
app.MapGraphQLVoyager();
app.CallGrpc();

app.Run();

