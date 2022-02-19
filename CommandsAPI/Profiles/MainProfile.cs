using AutoMapper;
using PlatformsAPI;

namespace CommandsAPI.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<PlatformPublishDTO, PlatformModel>().ForMember(dest => dest.ExternalId, src => src.MapFrom(opts => opts.Id))
                .ForMember(dest=>dest.Id,opts=>opts.Ignore());
                
            CreateMap<CommandCreateDTO, CommandModel>();
            CreateMap<GrpcPlatformModel, PlatformModel>().ForMember(dest=>dest.Id,opts=>opts.Ignore());
        }
    }
}
