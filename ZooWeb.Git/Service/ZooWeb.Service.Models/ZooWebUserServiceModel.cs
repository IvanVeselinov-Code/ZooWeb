using Microsoft.AspNetCore.Identity;

namespace ZooWeb.Service.Models
{
    public class ZooWebUserServiceModel : IdentityUser
    {
        public ZooWebRoleServiceModel ForumRole { get; set; }
    }
}
