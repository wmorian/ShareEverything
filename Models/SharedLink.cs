using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ShareEverything.Models
{
    public class SharedLink
    {
        [Required]
        public string Url { get; set; }

        [Required]
        public ICollection<string> Tags { get; set; } = new Collection<string>();

        public override string ToString()
        {
            return $"{this.Url}\t{string.Join('\t', this.Tags)}"; 
        }
    }
}