using ZooWeb.Data.Models;
using ZooWeb.Service.Models;

namespace ZooWeb.Service.Mappings
{
    public static class UserThreadReactionMappings
    {
        public static UserThreadReactionServiceModel ToModel(this UserThreadReaction entity)
        {
            return new UserThreadReactionServiceModel
            {
                Id = entity.Id,
                Reaction = entity.Reaction?.ToModel(),
                Thread = entity.Thread?.ToModel(),
                User = entity.User?.ToModel()
            };
        }
    }
}
