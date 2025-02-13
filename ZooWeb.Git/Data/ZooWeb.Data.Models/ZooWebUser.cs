using Microsoft.AspNetCore.Identity;

namespace ZooWeb.Data.Models
{
    public class ZooWebUser : IdentityUser
    {
        public ZooWebRole? ForumRole { get; set; }
    }
}
