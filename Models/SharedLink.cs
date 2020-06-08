using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ShareEverything.Models
{
    public class SharedLink
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        public ICollection<SharedLinkTag> SharedLinkTags { get; }
    }
}