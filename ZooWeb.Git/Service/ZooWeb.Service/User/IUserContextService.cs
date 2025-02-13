using ZooWeb.Data.Models;

namespace ZooWeb.Service.User
{
    public interface IUserContextService
    {
        Task<ZooWebUser> GetCurrentUserAsync();
    }
}
