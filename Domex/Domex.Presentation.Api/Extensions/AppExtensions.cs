﻿using Domex.WebApi.Middlewares;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Domex.WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwagggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Domex API");
                options.DefaultModelRendering(ModelRendering.Model);
;            });
        }

        public static void UseErrorHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
