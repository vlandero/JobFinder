using Tema.Helpers.JwtHelpers;
using Tema.Models.Users.BaseUser;
using Tema.Services.Users;

namespace Tema.Helpers.Middleware
{
    public class JwtMiddleware<UserEntity> where UserEntity : User
    {
        private readonly RequestDelegate _nextRequestDelegate;

        public JwtMiddleware(RequestDelegate requestDelegate)
        {
            _nextRequestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext, IUserService<UserEntity> usersService, IJwtHelpers<UserEntity> jwtUtils)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split("").Last();

            var userId = jwtUtils.ValidateJwtToken(token);

            if (userId != Guid.Empty)
            {
                httpContext.Items["User"] = usersService.GetById(userId);
            }

            await _nextRequestDelegate(httpContext);
        }
    }
}
