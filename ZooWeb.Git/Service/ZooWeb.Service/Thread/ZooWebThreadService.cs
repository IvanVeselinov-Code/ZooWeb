using ZooWeb.Data.Models;
using ZooWeb.Data.Repositories;
using ZooWeb.Service.Mappings;
using ZooWeb.Service.Models;
using ZooWeb.Service.User;
using Microsoft.EntityFrameworkCore;

namespace ZooWeb.Service.Thread
{
    public class ZooWebThreadService : IZooWebThreadService
    {
        private readonly ZooWebThreadRepository ZooWebThreadRepository;

        private readonly ZooWebTagRepository ZooWebTagRepository;

        private readonly ZooWebCommunityRepository ZooWebCommunityRepository;

        private readonly CommentRepository commentRepository;

        private readonly IUserContextService userContextService;

        public ZooWebThreadService(
            ZooWebThreadRepository ZooWebThreadRepository,
            ZooWebTagRepository ZooWebTagRepository,
            ZooWebCommunityRepository ZooWebCommunityRepository,
            CommentRepository commentRepository,
            IUserContextService userContextService)
        {
            this.ZooWebThreadRepository = ZooWebThreadRepository;
            this.ZooWebTagRepository = ZooWebTagRepository;
            this.ZooWebCommunityRepository = ZooWebCommunityRepository;
            this.commentRepository = commentRepository;
            this.userContextService = userContextService;
        }

        public async Task<ZooWebThreadServiceModel> CreateAsync(ZooWebThreadServiceModel model)
        {
            ZooWebThread ZooWebThread = model.ToEntity();

            ZooWebThread.Tags = ZooWebThread.Tags.Select(async tag => {
                return (await this.ZooWebTagRepository.CreateAsync(tag));
            }).Select(t => t.Result).ToList();

            ZooWebThread.Community = await this.ZooWebCommunityRepository.GetAll()
                .SingleOrDefaultAsync(community => community.Id == model.Community.Id);

            await ZooWebThreadRepository.CreateAsync(ZooWebThread);

            return ZooWebThread.ToModel();
        }

        public async Task<CommentServiceModel> CreateCommentOnThread(CommentServiceModel commentServiceModel, string threadId, string? parentCommentId = null)
        {
            Data.Models.Comment entity = commentServiceModel.ToEntity();

            if (parentCommentId != null)
            {
                Data.Models.Comment? parent = await commentRepository.GetAll()
                    .SingleOrDefaultAsync(c => c.Id == parentCommentId);

                if (parent == null)
                {
                    throw new ArgumentException("Parent comment not found for id - " + parentCommentId);
                }

                entity.Parent = parent;
            }

            entity = await this.commentRepository.CreateAsync(entity);

            ZooWebThread commentThread = await this.InternalGetByIdAsync(threadId);

            commentThread.Comments.Add(new UserThreadComment
            {
                Comment = entity,
                Thread = commentThread,
                User = (await this.userContextService.GetCurrentUserAsync())
            });

            await this.ZooWebThreadRepository.UpdateAsync(commentThread);

            return entity.ToModel(CommentMappingsContext.Reaction);
        }

        public Task<ZooWebThreadServiceModel> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ZooWebThreadServiceModel> GetAll()
        {
            return this.InternalGetAll()
                .Select(t => t.ToModel());
        }

        public async Task<ZooWebThreadServiceModel> GetByIdAsync(string id)
        {
            return (await this.InternalGetAll().SingleOrDefaultAsync(thread => thread.Id == id))?.ToModel();
        }

        public Task<ZooWebThreadServiceModel> UpdateAsync(string id, ZooWebThreadServiceModel model)
        {
            throw new NotImplementedException();
        }

        private async Task<ZooWebThread> InternalGetByIdAsync(string id)
        {
            return await this.InternalGetAll().SingleOrDefaultAsync(thread => thread.Id == id);
        }

        private IQueryable<ZooWebThread> InternalGetAll()
        {
            return ZooWebThreadRepository.GetAll()
                .Include(t => t.Tags)
                .Include(t => t.Community)
                .Include(t => t.Reactions)
                .Include(t => t.Comments)
                .Include(t => t.CreatedBy)
                .Include(t => t.UpdatedBy)
                .Include(t => t.DeletedBy);
        }
    }
}
