using etiqatest.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace etiqatest.Infrastructure.Services
{
    public class UserService(IHttpContextAccessor httpContextAccessor) : IUserService
    {
        public string GetUserId()
        {
            var userId = httpContextAccessor.HttpContext?.User?.Claims
                .FirstOrDefault()?.Value;
            return userId;
        }

        public string GetUserName()
        {
            return httpContextAccessor.HttpContext?.User?.Identity?.Name;
        }
    }
}
