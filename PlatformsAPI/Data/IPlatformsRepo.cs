
namespace PlatformsAPI.Data
{
    public interface IPlatformsRepo
    {
        void AddPlatform(PlatformModel pm);
        List<PlatformModel> GetAllPlatforms();
        PlatformModel GetOnePlatform(int id);
        void SaveChanges();
    }
}