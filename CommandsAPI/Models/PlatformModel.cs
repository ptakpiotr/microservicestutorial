using System.ComponentModel.DataAnnotations;

namespace CommandsAPI.Models
{
    public class PlatformModel
    {
        [Key]
        public int Id { get; set; }

        public int ExternalId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<CommandModel> Commands{ get; set; }
    }
}
