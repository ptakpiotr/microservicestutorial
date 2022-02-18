namespace CommandsAPI.GraphQL.Types
{
    public class Resolvers
    {
        public PlatformModel GetPlatform([Parent] CommandModel command,[ScopedService] AppDbContext ctx)
        {
            var platform = ctx.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);

            return platform;
        }

        public List<CommandModel> GetCommands([Parent] PlatformModel platform,[ScopedService] AppDbContext ctx)
        {
            var commands = ctx.Commands.Where(c => c.PlatformId == platform.Id).ToList();

            return commands;
        }
    }
}
