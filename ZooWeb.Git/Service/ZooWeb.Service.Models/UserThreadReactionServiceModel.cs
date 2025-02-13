namespace ZooWeb.Service.Models
{
    public class UserThreadReactionServiceModel : BaseServiceModel
    {
        public ZooWebUserServiceModel User { get; set; }

        public ZooWebThreadServiceModel Thread { get; set; }

        public ReactionServiceModel Reaction { get; set; }
    }
}
