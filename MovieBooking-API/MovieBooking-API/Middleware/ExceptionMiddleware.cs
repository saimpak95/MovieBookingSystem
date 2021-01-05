using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovieBooking_API.Errors;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieBooking_API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)StatusCodes.Status500InternalServerError;
                var response = env.IsDevelopment() ? new ApiException((int)StatusCodes.Status500InternalServerError, ex.Message, ex.StackTrace) : new ApiException((int)StatusCodes.Status500InternalServerError);
                var option = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var JsonResponse = JsonSerializer.Serialize(response, option);
                await context.Response.WriteAsync(JsonResponse);
            }
        }
    }
}