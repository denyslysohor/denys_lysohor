
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2
{
    public class CustomLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomLoggingMiddleware> _logger;

        public CustomLoggingMiddleware(RequestDelegate next, ILogger<CustomLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;

            if ((request.Method == HttpMethods.Post || request.Method == HttpMethods.Put) && request.Body.CanRead)
            {
                request.EnableBuffering();

                var bodySize = request.ContentLength ?? request.Body.Length;

                if (bodySize > 0)
                {
                    request.Body.Seek(0, SeekOrigin.Begin);

                    using (StreamReader streamReader = new(
                        request.Body,
                        encoding: Encoding.UTF8,
                        detectEncodingFromByteOrderMarks: false,
                        bufferSize: 8192,
                        leaveOpen: true))
                    {
                        var requestBody = await streamReader.ReadToEndAsync();

                        if (!string.IsNullOrWhiteSpace(requestBody))
                            _logger.LogInformation(requestBody);
                    }
                }
            }

            await _next(context);
        }
    }

    public static class LogRequestBodyMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogRequestBodyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomLoggingMiddleware>();
        }
    }
}
