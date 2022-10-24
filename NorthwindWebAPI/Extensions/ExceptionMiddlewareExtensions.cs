using Microsoft.AspNetCore.Builder; //harus ada pakai ctrl + .
using Microsoft.AspNetCore.Diagnostics; // harus ada pakai ctrl + .
using Microsoft.AspNetCore.Http; // harus ada pakai ctrl + .
using Northwind.Domain.ErrorModel;
using Northwind.Services.Abstraction;
using System.Net;

namespace NorthwindWebAPI.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }
    }
}
