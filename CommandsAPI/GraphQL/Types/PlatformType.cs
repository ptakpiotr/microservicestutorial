namespace CommandsAPI.GraphQL.Types
{
    public class PlatformType : ObjectType<PlatformModel>
    {
        protected override void Configure(IObjectTypeDescriptor<PlatformModel> descriptor)
        {
            descriptor.Description("Platform which offers multiple different commands");

            descriptor.Field(f => f.Commands).
                ResolveWith<Resolvers>(r => r.GetCommands(default!, default!)).UseDbContext<AppDbContext>();
        }
    }
}
