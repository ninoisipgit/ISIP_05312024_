namespace CatalogAPI.Middleware
{
 
    public class KeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _apiKey;

        public KeyMiddleware(RequestDelegate next, string apiKey)
        {
            _next = next;
            _apiKey = apiKey;
        }

        public async Task Invoke(HttpContext context)
        {
            string apiKey = context.Request.Headers["apikey"]; // Adjusted to "Apikey"

            if (_apiKey != _apiKey)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid API Key");
                return;
            }

            await _next(context);
        }
    }
    public static class ApiKeyMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiKeyMiddleware(this IApplicationBuilder builder, string apiKey)
        {
            return builder.UseMiddleware<KeyMiddleware>(apiKey);
        }
    }
}
