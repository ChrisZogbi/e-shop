using eShop.Infrastructure.ActionResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;

namespace eShop.Infrastructure.Filter
{

    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment env;
        private readonly ILogger<HttpGlobalExceptionFilter> logger;

        public HttpGlobalExceptionFilter(IHostEnvironment env, ILogger<HttpGlobalExceptionFilter> logger)
        {
            this.env = env;
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);

            var problemDetails = new ValidationProblemDetails()
            {
                Instance = context.HttpContext.Request.Path,
                Status = StatusCodes.Status500InternalServerError,
                Detail = "Please refer to the errors property for additional details."
            };

            problemDetails.Errors.Add("Exception", new string[] { context.Exception.Message.ToString() });

            context.Result = new InternalServerErrorObjectResult(problemDetails);

            context.ExceptionHandled = true;

        }
    }
}
