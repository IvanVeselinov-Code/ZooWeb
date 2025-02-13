using ZooWeb.Data.Models;
using ZooWeb.Web.Data;

namespace ZooWeb.Data.Repositories
{
    public class ZooWebRoleRepository : BaseGenericRepository<ZooWebRole>
    {
        public ZooWebRoleRepository(ZooWebDbContext dbContext) : base(dbContext)
        {
        }
    }
}
