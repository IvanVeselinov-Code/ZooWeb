using ZooWeb.Data.Models;
using ZooWeb.Service.Models;

namespace ZooWeb.Service.Mappings
{
    public static class ZooWebRoleMappings
    {
        public static ZooWebRole ToEntity(this ZooWebRoleServiceModel model)
        {
            return new ZooWebRole
            {
                Label = model.Label,
                Color = model.Color,
                Authority = model.Authority
            };
        }

        public static ZooWebRoleServiceModel ToModel(this ZooWebRole entity)
        {
            return new ZooWebRoleServiceModel
            {
                Id = entity.Id,
                Label = entity.Label,
                Color = entity.Color,
                Authority = entity.Authority,
                CreatedOn = entity.CreatedOn,
                UpdatedOn = entity.UpdatedOn,
                DeletedOn = entity.DeletedOn,
                CreatedBy = entity.CreatedBy.ToModel(),
                UpdatedBy = entity.UpdatedBy?.ToModel(),
                DeletedBy = entity.DeletedBy?.ToModel()
            };
        }
    }
}
