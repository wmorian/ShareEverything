using System.ComponentModel.DataAnnotations;

namespace ShareEverything.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int SharedLinkId { get; set; }

        public SharedLink SharedLink { get; set; }
    }
}