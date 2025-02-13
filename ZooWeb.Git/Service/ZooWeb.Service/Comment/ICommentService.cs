using ZooWeb.Service.Models;

namespace ZooWeb.Service.Comment
{
    public interface ICommentService : IGenericService<Data.Models.Comment, CommentServiceModel>
    {
        IQueryable<CommentServiceModel> GetAllByParentId(string parentId);

        Task<IQueryable<CommentServiceModel>> GetAllByThreadId(string threadId);
    }
}
