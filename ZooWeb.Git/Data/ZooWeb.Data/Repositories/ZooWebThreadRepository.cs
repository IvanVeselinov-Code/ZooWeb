using ZooWeb.Data.Models;
using ZooWeb.Web.Data;
using Microsoft.AspNetCore.Http;

namespace ZooWeb.Data.Repositories
{
    public class ZooWebThreadRepository : MetadataBaseGenericRepository<ZooWebThread>
    {
        public ZooWebThreadRepository(ZooWebDbContext dbContext, IHttpContextAccessor httpContextAccessor) 
            : base(dbContext, httpContextAccessor)
        {
        }
    }
}
