namespace ZooWeb.Data.Models
{
    public class UserCommentReaction : BaseEntity
    {
        public ZooWebUser User { get; set; }

        public Comment Comment { get; set; }

        public Reaction Reaction { get; set; }
    }
}
