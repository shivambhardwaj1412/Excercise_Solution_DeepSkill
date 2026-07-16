using Microsoft.AspNetCore.Mvc.Filters;
using System.Web.Http;

namespace EmployeeWebApi.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var logPath = Path.Combine(Directory.GetCurrentDirectory(), "error_log.txt");
            File.AppendAllText(logPath, $"[{DateTime.Now}] {exception.GetType().Name}: {exception.Message}{Environment.NewLine}{exception.StackTrace}{Environment.NewLine}");

            context.Result = new ExceptionResult(exception, false);
            context.ExceptionHandled = true;
        }
    }
}
