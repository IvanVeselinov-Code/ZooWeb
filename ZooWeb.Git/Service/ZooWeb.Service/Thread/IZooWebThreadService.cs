using ZooWeb.Data.Models;
using ZooWeb.Service.Models;

namespace ZooWeb.Service.Thread
{
    public interface IZooWebThreadService : IGenericService<ZooWebThread, ZooWebThreadServiceModel>
    {
        Task<CommentServiceModel> CreateCommentOnThread(CommentServiceModel commentServiceModel, string threadId, string? parentCommentId = null);
    }
}
