namespace ZooWeb.Service.Models
{
    public class UserCommentReactionServiceModel : BaseServiceModel
    {
        public ZooWebUserServiceModel User { get; set; }

        public CommentServiceModel Comment { get; set; }

        public ReactionServiceModel Reaction { get; set; }
    }
}
