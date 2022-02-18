using System.ComponentModel.DataAnnotations;

namespace CommandsAPI.Models
{
    public class CommandCreateDTO
    {
        [Required]
        public string HowTo { get; set; }

        [Required]
        public string CommandLine { get; set; }
        public int PlatformId { get; set; }
    }
}
