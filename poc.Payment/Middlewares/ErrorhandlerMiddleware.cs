
using Microsoft.AspNetCore.Mvc;
using poc.Payment.Exceptions;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace poc.Payment.Middlewares
{
    public class ErrorhandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
               await next(context);
            } catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                var details = new ProblemDetails
                {
                    Status = context.Response.StatusCode,
                    Detail = ex.Message
                };

                switch(ex)
                {
                    case PaymentException e:
                        context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                        details.Status = StatusCodes.Status422UnprocessableEntity;
                        break;
                }

                var json = JsonSerializer.Serialize(details);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
