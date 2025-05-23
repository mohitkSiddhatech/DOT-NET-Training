using System.Net;

namespace EmployeeManagementCRUD.Middlewares
{
    public class GlobalExceptionHandelingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandelingMiddleware> _logger;

        public GlobalExceptionHandelingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandelingMiddleware> logger) 
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Message");
                _logger.LogError(ex, ex.Message);
                // This error is setting in the exception if get in browser.
                // If I put 404 Not Found set then if any exception get then it will throw status code as 404.
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }
    }
}