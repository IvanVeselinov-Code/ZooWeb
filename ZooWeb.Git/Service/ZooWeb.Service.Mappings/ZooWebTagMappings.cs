using ZooWeb.Data.Models;
using ZooWeb.Service.Models;
using System.Reflection.Emit;

namespace ZooWeb.Service.Mappings
{
    public static class ZooWebTagMappings
    {
        public static ZooWebTag ToEntity(this ZooWebTagServiceModel model)
        {
            return new ZooWebTag
            {
                Label = model.Label
            };
        }

        public static ZooWebTagServiceModel ToModel(this ZooWebTag entity)
        {
            return new ZooWebTagServiceModel
            {
                Id = entity.Id,
                Label = entity.Label,
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
