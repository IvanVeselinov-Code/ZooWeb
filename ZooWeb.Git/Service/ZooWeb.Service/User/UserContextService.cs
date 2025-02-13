using ZooWeb.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ZooWeb.Service.User
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IUserStore<ZooWebUser> userStore;

        public UserContextService(
            IHttpContextAccessor httpContextAccessor, 
            IUserStore<ZooWebUser> userStore)
        {
            _httpContextAccessor = httpContextAccessor;
            this.userStore = userStore;
        }

        public async Task<ZooWebUser> GetCurrentUserAsync()
        {
            string? userId = this._httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return await this.userStore.FindByIdAsync(userId, CancellationToken.None);
        }
    }
}
