using ZooWeb.Data.Models;
using ZooWeb.Service.Models;

namespace ZooWeb.Service.Mappings
{
    public static class ZooWebCommunityMappings
    {
        public static ZooWebCommunity ToEntity(this ZooWebCommunityServiceModel model)
        {
            return new ZooWebCommunity
            {
                Name = model.Name,
                Description = model.Description,
                Tags = model.Tags?.Select(tag => tag.ToEntity()).ToList(),
                ThumbnailPhoto = model.ThumbnailPhoto?.ToEntity(),
                BannerPhoto = model.BannerPhoto?.ToEntity()
            };
        }

        public static ZooWebCommunityServiceModel ToModel(this ZooWebCommunity entity)
        {
            return new ZooWebCommunityServiceModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Tags = entity.Tags?.Select(tag => tag.ToModel()).ToList(),
                ThumbnailPhoto = entity.ThumbnailPhoto?.ToModel(),
                BannerPhoto = entity.BannerPhoto?.ToModel(),
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
