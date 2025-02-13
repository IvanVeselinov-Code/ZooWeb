namespace ZooWeb.Data.Models
{
    public class ZooWebThread : MetadataBaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public List<Attachment> Attachments { get; set; }

        public ZooWebCommunity Community { get; set; }

        public List<ZooWebTag> Tags { get; set; }

        public List<UserThreadReaction> Reactions { get; set; }

        public List<UserThreadComment> Comments { get; set; }
    }
}
