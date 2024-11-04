using ERP.MVC.Infrastructure.Services;
using Microsoft.AspNetCore.Http;

namespace ERP.MVC.Infrastructure.Middleware
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserService _userService;

        public AuthorizationMiddleware(RequestDelegate next, IUserService userService)
        {
            _next = next;
            _userService = userService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (!string.IsNullOrEmpty(token))
            {
                var user = _userService.GetUserFromToken(token);
                if (user != null)
                {
                    context.Items["User"] = user; // Attach user to context
                }
            }

            await _next(context);
        }
    }
}
