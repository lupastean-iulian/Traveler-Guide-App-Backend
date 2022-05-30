using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TravelerGuideApp.API.Services;

namespace TravelerGuideApp.API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TgaMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TgaMiddleware> _logger;
        private readonly ISingletonService _singleton;
        private readonly ITransientService _transient;
        private readonly IScopedService _scoped;

        public TgaMiddleware(RequestDelegate next, ILogger<TgaMiddleware> logger, ISingletonService singleton, ITransientService transient)
        {
            _next = next;
            _logger = logger;
            _singleton = singleton;
            _transient = transient;
            _logger.LogInformation($"Middleware Singleton GUID: {_singleton.Guid}");
            _logger.LogInformation($"Middleware Transient GUID: {_transient.Guid}");
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TgaMiddlewareExtensions
    {
        public static IApplicationBuilder UseTgaMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TgaMiddleware>();
        }
    }
}
