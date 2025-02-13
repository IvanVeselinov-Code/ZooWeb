namespace ZooWeb.Service.Models
{
    public class ZooWebThreadServiceModel : MetadataBaseServiceModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public ZooWebCommunityServiceModel Community { get; set; }

        public List<ZooWebTagServiceModel> Tags { get; set; }

        public List<UserThreadReactionServiceModel> Reactions { get; set; }

        public List<UserThreadCommentServiceModel> Comments { get; set; }
    }
}
