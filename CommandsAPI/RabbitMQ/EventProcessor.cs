using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CommandsAPI.RabbitMQ
{
    public class EventProcessor : IEventProcessor
    {
        private readonly AppDbContext _ctx;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory factory)
        {
            using (var scope = factory.CreateScope())
            {
                _ctx = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>().CreateDbContext();

                _mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
            }
        }

        public void AddPlatform(PlatformPublishDTO pm)
        {
            PlatformModel platform = _mapper.Map<PlatformModel>(pm);

            _ctx.Platforms.Add(platform);
            _ctx.SaveChanges();
        }
    }
}
