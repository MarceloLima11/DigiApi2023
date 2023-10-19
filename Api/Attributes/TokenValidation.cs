using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class TokenValidation : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var jwtService = context.HttpContext.RequestServices.GetRequiredService<IJwtService>();
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (authorizationHeader == null || !authorizationHeader.StartsWith("Bearer "))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var token = authorizationHeader[7..];
            if (!jwtService.ValidateToken(token))
                context.Result = new UnauthorizedResult();
        }
    }
}