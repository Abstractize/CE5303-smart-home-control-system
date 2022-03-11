using Microsoft.AspNetCore.Diagnostics;
using Models.Exceptions;
using static System.Net.Mime.MediaTypeNames;

namespace API.Middlewares
{
    public static class ExceptionMiddlewareEx
    {
        public static IApplicationBuilder UseExceptions(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = Text.Plain;
                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();

                    switch (exceptionHandlerPathFeature?.Error)
                    {
                        case BaseException e:
                            context.Response.StatusCode = e.StatusCode;
                            await context.Response.WriteAsync(e.UserFriendlyMessage);
                            break;
                        case NotImplementedException e:
                            int statusCode = StatusCodes.Status500InternalServerError;
                            context.Response.StatusCode = statusCode;
                            await context.Response.WriteAsync(e.Message);
                            break;
                        default:
                            Exception? ex = exceptionHandlerPathFeature?.Error;
                            int cd = StatusCodes.Status500InternalServerError;
                            context.Response.StatusCode = cd;
                            await context.Response.WriteAsync(ex.Message);
                            break;
                    }
                });
            });

            return app;
        }
    }
}
