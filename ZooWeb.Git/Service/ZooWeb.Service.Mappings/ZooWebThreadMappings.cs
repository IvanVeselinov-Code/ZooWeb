using ZooWeb.Data.Models;
using ZooWeb.Service.Models;

namespace ZooWeb.Service.Mappings
{
    public static class ZooWebThreadMappings
    {
        public static ZooWebThread ToEntity(this ZooWebThreadServiceModel model)
        {
            return new ZooWebThread
            {
                Title = model.Title,
                Content = model.Content,
                Community = model.Community?.ToEntity(),
                Tags = model.Tags?.Select(tag => tag.ToEntity()).ToList(),
            };
        }

        public static ZooWebThreadServiceModel ToModel(this ZooWebThread entity)
        {
            return new ZooWebThreadServiceModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Content = entity.Content,
                Community = entity.Community?.ToModel(),
                Tags = entity.Tags?.Select(tag => tag.ToModel()).ToList(),
                Reactions = entity.Reactions?.Select(reaction => reaction.ToModel()).ToList(),
                Comments = entity.Comments?.Select(comment => comment.ToModel(UserThreadCommentMappingsContext.Thread)).ToList(),
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
