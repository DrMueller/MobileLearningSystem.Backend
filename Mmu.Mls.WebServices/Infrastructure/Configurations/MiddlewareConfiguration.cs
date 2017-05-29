using Microsoft.AspNetCore.Builder;
using Mmu.Mls.WebServices.Infrastructure.Middlewares;

namespace Mmu.Mls.WebServices.Infrastructure.Configurations
{
    internal static class MiddlewareConfiguration
    {
        internal static void ConfigureMiddlewares(IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}