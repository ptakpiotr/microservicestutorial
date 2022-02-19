using AutoMapper;
using CommandsAPI.Models;
using Grpc.Net.Client;
using PlatformsAPI;

namespace CommandsAPI.Grpc
{
    public class GrpcClient : IGrpcClient
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public GrpcClient(IConfiguration config, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
        }

        public List<PlatformModel> GetAllPlatforms()
        {
            var channel = GrpcChannel.ForAddress(_config["Grpc:Target"]);
            var client = new GetPlatforms.GetPlatformsClient(channel);
            try
            {
                List<GrpcPlatformModel> data = client.GetAll(new GrpcInput()).Platforms.ToList();

                var res = _mapper.Map<List<PlatformModel>>(data);

                return res;
            }
            catch
            {
                return null;
            }
        }
    }
}
