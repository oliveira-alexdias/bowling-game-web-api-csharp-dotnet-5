using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace BowlingGame.API.Extensions
{
    public static class IApplicationBuilderExceptions
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
                var response = new { error = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));
        }
    }
}
