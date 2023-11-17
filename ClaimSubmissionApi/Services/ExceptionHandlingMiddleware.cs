using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ClaimSubmissionApi.Services
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
   
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext)
        {
            httpContext.Response.ContentType = "application/json";


            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var response = new BadHttpRequestException("Internal server error");
         
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
