namespace ZooWeb.Service.Models
{
    public class ZooWebCommunityServiceModel : MetadataBaseServiceModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<ZooWebTagServiceModel> Tags { get; set; }

        public AttachmentServiceModel ThumbnailPhoto { get; set; }

        public AttachmentServiceModel BannerPhoto { get; set; }
    }
}
