using ZooWeb.Data.Models;
using ZooWeb.Service.Models;

namespace ZooWeb.Service.Mappings
{
    public static class ZooWebUserMappings
    {
        public static ZooWebUser ToEntity(this ZooWebUserServiceModel model)
        {
            return new ZooWebUser(); // TODO: Verify if we actually need this
        }

        public static ZooWebUserServiceModel ToModel(this ZooWebUser entity)
        {
            return new ZooWebUserServiceModel
            {
                ForumRole = entity.ForumRole?.ToModel(),
                Email = entity.Email,
                Id = entity.Id,
                UserName = entity.UserName
            };
        }
    }
}
