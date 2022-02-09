using Core.Utilities.Exceptions;
using Core.Utilities.Wrappers;
using Domain.DTOs.Wrappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace API.Middlewares
{
    public static class UseCustomExceptionHandler
    {

        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {

                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature.Error switch
                    {
                        CustomException => 400,
                        ValidationException => 400,
                        NotFoundExcepiton => 404,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;

                    var response = new ErrorDataResult<NoDataDto>(null, exceptionFeature.Error.Message, statusCode);  

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                });

            });
        }
    }
}
