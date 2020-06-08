using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShareEverything.DTOs
{
    public class SharedLinkDto
    {
        [Required]
        public string Url { get; set; }

        public ICollection<string> Tags { get; set; }
    }
}