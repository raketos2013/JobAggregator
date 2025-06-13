using JobAggregator.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JobAggregator.Api.Middlewares;

public class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
		try
		{
			await next(httpContext);
		}
		catch (Exception e)
		{
			// TODO: добавить логи
			int statusCode = (int)HttpStatusCode.InternalServerError;
			var details = "Internal server error";
            switch (e)
            {
                case ArgumentException or ArgumentNullException:
                    details = e.Message;
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case DomainException:
                    details = e.Message;
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;
            }

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Title = "An error occurred",
                Detail = details,
                Status = statusCode
            });

            throw;
		}
    }
}
