namespace ZooWeb.Data.Repositories
{
    using ZooWeb.Data.Models;
    using ZooWeb.Web.Data;

    public class AttachmentRepository : BaseGenericRepository<Attachment>
    {
        public AttachmentRepository(ZooWebDbContext dbContext) : base(dbContext)
        {
        }
    }
}
