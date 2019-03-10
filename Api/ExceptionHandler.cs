using Domains.ViewModels;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api
{
    public class ExceptionHandler : IExceptionFilter
    {
        /// <summary>Called after an action has thrown an <see cref="T:System.Exception"/>.</summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ExceptionContext"/>.</param>
        public void OnException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType().ToString();
            if (exceptionType.Contains("System.Data.DuplicateNameException"))
            {
                context.Result = new InernalErrorObjectResult(
                new Error { StatusCode = 409, Description = "The request could not be completed because of a conflict", Message = context.Exception.Message });
            }
            else if (exceptionType.Contains("System.Data.DataException"))
            {
                context.Result = new InernalErrorObjectResult(
                new Error { StatusCode = 404, Description = "The reqested Resource is Not Found", Message = context.Exception.Message });
            }
            else if (exceptionType.Contains("System.FormatException"))
            {
                context.Result = new InernalErrorObjectResult(
                new Error { StatusCode = 400, Description = "Bad request", Message = context.Exception.Message });
            }
            else
            {
                context.Result = new InernalErrorObjectResult(
                new Error { StatusCode = 500, Description = "The server encountered an unexpected condition which prevented it from fulfilling the request", Message = context.Exception.Message });
            }
        }
    }
}
