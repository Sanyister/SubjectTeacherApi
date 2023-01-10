using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace zsoow6TeacherSubjApi.Policy
{
    public class UserAuthorizationHandler : AuthorizationHandler<UserPolicy>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserPolicy requirement)
        {
            var UserClaim = context.User.FindFirst(
                        c => c.Type == ClaimTypes.Actor);
            if (UserClaim is null) { 
                return Task.CompletedTask;
            }
            if (bool.Parse(UserClaim.Value))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
