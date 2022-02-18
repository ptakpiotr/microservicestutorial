using System.ComponentModel.DataAnnotations;

namespace PlatformsAPI.Models
{
    public class PlatformModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Publisher { get; set; }

        public decimal Cost { get; set; }
    }
}
