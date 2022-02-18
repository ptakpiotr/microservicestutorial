using AutoMapper;

namespace CommandsAPI.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public ResultModel AddCommand(CommandCreateDTO input,[ScopedService] AppDbContext ctx, [Service] IMapper mapper)
        {
            if (!ctx.Platforms.Any(p => p.Id == input.PlatformId))
            {
                return new ResultModel { Message = $"Platform with the given id: {input.PlatformId} does not exist" };
            }
            try
            {
                var mapped = mapper.Map<CommandModel>(input);
                ctx.Commands.Add(mapped);
                ctx.SaveChanges();
                return new ResultModel { Message = "Command succefully added" };
            }
            catch (Exception ex)
            {
                return new ResultModel { Message= "An error has occured"};
            }
        }
    }
}
