using ZooWeb.Data.Models;
using ZooWeb.Web.Data;
using Microsoft.AspNetCore.Http;

namespace ZooWeb.Data.Repositories
{
    public class CommentRepository : MetadataBaseGenericRepository<Comment>
    {
        public CommentRepository(ZooWebDbContext dbContext, IHttpContextAccessor httpContextAccessor) 
            : base(dbContext, httpContextAccessor)
        {
        }
    }
}
