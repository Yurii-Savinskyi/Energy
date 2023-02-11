using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Energy.Common.Models.ApiCommunication;
using Energy.Common.Models.Exceptions;
using Energy.Common.StaticResources;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace Energy.Api.Extentions
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var body = string.Empty;

            try
            {
                context.Request.EnableBuffering();

                var reader = new StreamReader(context.Request.Body);

                body = await reader.ReadToEndAsync();

                context.Request.Body.Position = 0L;

                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var apiResponse = new ApiResponse();

            switch (exception)
            {
                case NotFoundException _:
                    code = HttpStatusCode.NotFound;
                    apiResponse.Message = ApiResponseMessages.NotFound;
                    break;
                default:
                    apiResponse.Message = ApiResponseMessages.InternalServerError;
                    break;
            }

            var result = JsonConvert.SerializeObject(apiResponse, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Include,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}