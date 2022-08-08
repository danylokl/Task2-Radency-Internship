using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections;
using System.Collections.Generic;
using System.Web;
namespace Task2_Radency_Internship
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                _logger.LogInformation(
                    "Request {method} {url}\n Header: {headers}\n Queries: {queries}\n",
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    context.Request?.Headers,
                    context.Request?.QueryString
                    );
            }
        }
    }
}
