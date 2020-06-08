using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShareEverything.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<SharedLinkTag> SharedLinkTags { get; }
    }
}