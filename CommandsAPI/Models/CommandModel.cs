using System.ComponentModel.DataAnnotations;

namespace CommandsAPI.Models
{
    public class CommandModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string HowTo { get; set; }

        [Required]
        public string CommandLine { get; set; }
        public int PlatformId { get; set; }
        public PlatformModel Platform { get; set; }
    }
}
