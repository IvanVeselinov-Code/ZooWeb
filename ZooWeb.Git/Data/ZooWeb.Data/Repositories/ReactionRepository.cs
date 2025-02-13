using ZooWeb.Data.Models;
using ZooWeb.Web.Data;
using Microsoft.AspNetCore.Http;

namespace ZooWeb.Data.Repositories
{
    public class ReactionRepository : MetadataBaseGenericRepository<Reaction>
    {
        public ReactionRepository(ZooWebDbContext dbContext, IHttpContextAccessor httpContextAccessor) 
            : base(dbContext, httpContextAccessor)
        {
        }
    }
}
