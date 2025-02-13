using ZooWeb.Data.Models;
using ZooWeb.Web.Data;
using Microsoft.AspNetCore.Http;

namespace ZooWeb.Data.Repositories
{
    public class ZooWebTagRepository : MetadataBaseGenericRepository<ZooWebTag>
    {
        public ZooWebTagRepository(ZooWebDbContext dbContext, IHttpContextAccessor httpContextAccessor) 
            : base(dbContext, httpContextAccessor)
        {
        }
    }
}
