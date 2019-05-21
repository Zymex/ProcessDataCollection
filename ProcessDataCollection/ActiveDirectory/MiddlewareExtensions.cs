using Microsoft.AspNetCore.Builder;

namespace KittingApplication.ActiveDirectory
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseAdMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AdUserMiddleware>();
        }
    }
}