namespace ZooWeb.Data.Repositories
{
    using ZooWeb.Data.Models;
    using ZooWeb.Web.Data;
    using Microsoft.AspNetCore.Http;

    public class ZooWebCommunityRepository : MetadataBaseGenericRepository<ZooWebCommunity>
    {
        public ZooWebCommunityRepository(ZooWebDbContext dbContext, IHttpContextAccessor httpContextAccessor) 
            : base(dbContext, httpContextAccessor)
        {
        }
    }
}
