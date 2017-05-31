using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Mmu.Mls.WebServices.Infrastructure.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception == null)
            {
                return;
            }

            const HttpStatusCode CODE = HttpStatusCode.InternalServerError;

            await WriteExceptionAsync(context, exception, CODE).ConfigureAwait(false);
        }

        // Careful, these properties are expected form the client, do not change on only one side
        private static async Task WriteExceptionAsync(HttpContext context, Exception exception, HttpStatusCode code)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)code;

            Trace.TraceError(exception.Message);
            //Debug.WriteLine(exception.Message);

            //await response.WriteAsync(
            //    JsonConvert.SerializeObject(
            //        new
            //        {
            //            error = new
            //            {
            //                message = exception.Message,
            //                name = exception.GetType().Name,
            //                stack = exception.StackTrace
            //            }
            //        })).ConfigureAwait(false);
        }
    }
}