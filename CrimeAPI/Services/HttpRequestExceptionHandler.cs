using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CrimeAPI.Services
{
    internal sealed class HttpRequestExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<HttpRequestExceptionHandler> _logger;

        public HttpRequestExceptionHandler(ILogger<HttpRequestExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            if (exception is not HttpRequestException httpException || httpException.StatusCode == null)
            {
                return false;
            }

            _logger.LogError(
                httpException,
                "Exception occurred during accessing remote resource: {Message}",
                httpException.Message);

            var problemDetails = new ProblemDetails
            {
                Status = (int)httpException.StatusCode,
                Title = "Exception occurred during accessing remote resource",
                Detail = httpException.Message
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;

            await httpContext.Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
