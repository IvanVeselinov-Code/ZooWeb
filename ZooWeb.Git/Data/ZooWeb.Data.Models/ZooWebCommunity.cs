namespace ZooWeb.Data.Models
{
    public class ZooWebCommunity : MetadataBaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        // Threads in this community can only hold the community tags
        public List<ZooWebTag> Tags { get; set; }

        public Attachment? ThumbnailPhoto { get; set; }
        
        public Attachment? BannerPhoto { get; set; }
    }
}
