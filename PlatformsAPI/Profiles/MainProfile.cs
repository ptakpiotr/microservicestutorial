using AutoMapper;
namespace PlatformsAPI.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<PlatformModel,PlatformReadDTO>();
            CreateMap<PlatformCreateDTO, PlatformModel>();
            CreateMap<PlatformModel,PlatformPublishDTO>();
            CreateMap<PlatformModel, GrpcPlatformModel>();
        }
    }
}
