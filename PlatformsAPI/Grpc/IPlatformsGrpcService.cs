using Grpc.Core;

namespace PlatformsAPI.Grpc
{
    public interface IPlatformsGrpcService
    {
        Task<GrpcResponse> GetAll(GrpcInput request, ServerCallContext context);
    }
}