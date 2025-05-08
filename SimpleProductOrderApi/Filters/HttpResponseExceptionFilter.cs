namespace SimpleProductOrderApi.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Collections.Generic;

    public class HttpResponseExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            int statusCode;
            object response;

            switch (context.Exception)
            {
                case KeyNotFoundException:
                    statusCode = 404;
                    response = new { message = context.Exception.Message };
                    break;

                case ArgumentException:
                    statusCode = 400;
                    response = new { message = context.Exception.Message };
                    break;

                default:
                    statusCode = 500;
                    response = new { message = "An unexpected error occurred." };
                    break;
            }

            context.Result = new ObjectResult(response)
            {
                StatusCode = statusCode
            };

            context.ExceptionHandled = true;
        }
    }
}