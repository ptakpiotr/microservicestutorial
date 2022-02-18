namespace CommandsAPI.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseSorting]
        [UseFiltering]
        public IQueryable<CommandModel> GetAllCommands([ScopedService] AppDbContext ctx)
        {
            var res = ctx.Commands;

            return res;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseSorting]
        [UseFiltering]
        public IQueryable<PlatformModel> GetAllPlatforms([ScopedService] AppDbContext ctx)
        {
            var res = ctx.Platforms;

            return res;
        }
    }
}
