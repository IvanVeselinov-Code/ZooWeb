namespace ZooWeb.Service.Models
{
    public class UserThreadCommentServiceModel : BaseServiceModel
    {
        public ZooWebUserServiceModel User { get; set; }

        public ZooWebThreadServiceModel Thread { get; set; }

        public CommentServiceModel Comment { get; set; }
    }
}
