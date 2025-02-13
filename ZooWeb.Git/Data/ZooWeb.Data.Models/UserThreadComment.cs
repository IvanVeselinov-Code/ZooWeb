namespace ZooWeb.Data.Models
{
    public class UserThreadComment : BaseEntity
    {
        public ZooWebUser User { get; set; }

        public ZooWebThread Thread { get; set; }

        public Comment Comment { get; set; }
    }
}
