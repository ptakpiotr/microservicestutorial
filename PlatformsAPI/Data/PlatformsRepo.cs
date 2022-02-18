namespace PlatformsAPI.Data
{
    public class PlatformsRepo : IPlatformsRepo
    {
        private readonly AppDbContext _ctx;

        public PlatformsRepo(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<PlatformModel> GetAllPlatforms()
        {
            return _ctx.Platforms.ToList();
        }

        public PlatformModel GetOnePlatform(int id)
        {
            PlatformModel pm = _ctx.Platforms.FirstOrDefault(p => p.Id == id);

            return (pm);
        }

        public void AddPlatform(PlatformModel pm)
        {
            _ctx.Platforms.Add(pm);
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}
