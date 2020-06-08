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

        [Required]
        public ICollection<Tag> Tags { get; set; } = new Collection<Tag>();

        public override string ToString()
        {
            return $"{this.Url}\t{string.Join('\t', this.Tags)}"; 
        }
    }
}