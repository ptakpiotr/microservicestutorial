
namespace CommandsAPI.Grpc
{
    public interface IGrpcClient
    {
        List<PlatformModel> GetAllPlatforms();
    }
}