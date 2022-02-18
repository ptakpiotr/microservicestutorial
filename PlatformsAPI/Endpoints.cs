using AutoMapper;
using PlatformsAPI.RabbitMQ;
using System.Text.Json;

namespace PlatformsAPI
{
    public static class Endpoints
    {
        public static void UseGlobalEndpoints(this WebApplication app)
        {
            app.MapGet("/api/platforms", GetAllPlatforms);
            app.MapGet("/api/platforms/{id}", GetOnePlatform);
            app.MapPost("/api/platforms", AddOnePlatform);
        }

        private static IResult GetAllPlatforms(IPlatformsRepo repo, IMapper mapper)
        {
            List<PlatformModel> platforms = repo.GetAllPlatforms();
            if (platforms is null)
            {
                return Results.NotFound();
            }
            var output = mapper.Map<List<PlatformReadDTO>>(platforms);

            return Results.Ok(output);
        }

        private static IResult GetOnePlatform(int id, IPlatformsRepo repo, IMapper mapper)
        {
            PlatformModel platform = repo.GetOnePlatform(id);
            if (platform is null)
            {
                return Results.NotFound();
            }

            PlatformReadDTO output = mapper.Map<PlatformReadDTO>(platform);

            return Results.Ok(output);
        }

        private static IResult AddOnePlatform(PlatformCreateDTO dto, IPlatformsRepo repo, IMapper mapper,IEventPublisher publisher)
        {
            PlatformModel platform = mapper.Map<PlatformModel>(dto);

            repo.AddPlatform(platform);
            repo.SaveChanges();

            //rabbitmq section
            PlatformPublishDTO publishedDTO = mapper.Map<PlatformPublishDTO>(platform);

            publisher.SendMessage(JsonSerializer.Serialize(publishedDTO));

            return Results.Ok(platform);
        }
    }
}
