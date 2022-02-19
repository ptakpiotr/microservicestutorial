using AutoMapper;
using Grpc.Core;

namespace PlatformsAPI.Grpc
{
    public class PlatformsGrpcService : GetPlatforms.GetPlatformsBase, IPlatformsGrpcService
    {
        private readonly IPlatformsRepo _repo;
        private readonly IMapper _mapper;

        public PlatformsGrpcService(IPlatformsRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public override Task<GrpcResponse> GetAll(GrpcInput request, ServerCallContext context)
        {
            var platforms = _repo.GetAllPlatforms();
            var res = _mapper.Map<List<GrpcPlatformModel>>(platforms);

            var output = new GrpcResponse();
            output.Platforms.AddRange(res);
            return Task.FromResult(output);
        }
    }
}
