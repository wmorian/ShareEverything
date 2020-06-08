namespace ShareEverything.Models
{
    public class SharedLinkTag
    {
        public int SharedLinkId { get; set; }

        public SharedLink SharedLink { get; set; }

        public int TagId { get; set; }

        public Tag Tag { get; set; }
    }
}