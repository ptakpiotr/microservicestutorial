namespace CommandsAPI.GraphQL.Types
{
    public class CommandType : ObjectType<CommandModel>
    {
        protected override void Configure(IObjectTypeDescriptor<CommandModel> descriptor)
        {
            descriptor.Description("Single command model");

            descriptor.Field(f => f.Platform).
                ResolveWith<Resolvers>(r => r.GetPlatform(default!, default!)).UseDbContext<AppDbContext>();
        }
    }
}
