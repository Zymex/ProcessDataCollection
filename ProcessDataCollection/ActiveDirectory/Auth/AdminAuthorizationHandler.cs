using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace KittingApplication.ActiveDirectory.Auth
{
    public class AdminAuthorizationHandler : AuthorizationHandler<AdminRequirement>
    {
        private readonly AdUser user;

        public AdminAuthorizationHandler(AdUserProvider provider)
        {
            user = provider.CurrentUser;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            AdminRequirement requirement)
        {
            if (user.IsAdmin)
                context.Succeed(requirement);
            else
                context.Fail();

            return Task.CompletedTask;
        }
    }
}