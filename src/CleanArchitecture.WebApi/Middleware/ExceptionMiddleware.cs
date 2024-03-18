
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Context;
using FluentValidation;

namespace CleanArchitecture.WebApi.Middleware;

public sealed class ExceptionMiddleware(AppDbContext context) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
		try
		{
			await next(context);
		}
		catch (Exception ex)
        {
            await LogExceptionToDatabaseAsync(ex, context.Request); 
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;
        if (ex.GetType() == typeof(ValidationException))
        {
            return context.Response.WriteAsync(new ValidationErrorDetails
            {
                Errors = ((ValidationException)ex).Errors.Select(s => s.PropertyName),
                StatusCode = 403
            }.ToString());
        }
        return context.Response.WriteAsync(new ErrorResult
        {
            Message = ex.Message,
            StatusCode = context.Response.StatusCode
        }.ToString());
    }
    private async Task LogExceptionToDatabaseAsync(Exception ex,HttpRequest request)
    {
        ErrorLog errorLog = new()
        {
            ErrorMessage = ex.Message,
            StackTrace = ex.StackTrace,
            RequestPath = request.Path,
            RequestMethod = request.Method,
            Timestamp = DateTime.Now,
        };
        await context.AddAsync(errorLog, default);
        await context.SaveChangesAsync(default);   
    }
}
