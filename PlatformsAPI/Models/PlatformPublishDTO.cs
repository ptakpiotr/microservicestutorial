using System.ComponentModel.DataAnnotations;

namespace PlatformsAPI.Models
{
    public class PlatformPublishDTO
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
    }
}
