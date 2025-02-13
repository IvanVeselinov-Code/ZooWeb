namespace ZooWeb.Data.Models
{
    public class UserThreadReaction : BaseEntity
    {
        public ZooWebUser User { get; set; }

        public ZooWebThread Thread { get; set; }

        public Reaction Reaction { get; set; }
    }
}
