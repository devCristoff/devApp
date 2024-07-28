using Fedex.WebApi.Middlewares;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Fedex.WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwagggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "StockApp API");
                options.DefaultModelRendering(ModelRendering.Model);
;            });
        }

        public static void UseErrorHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
