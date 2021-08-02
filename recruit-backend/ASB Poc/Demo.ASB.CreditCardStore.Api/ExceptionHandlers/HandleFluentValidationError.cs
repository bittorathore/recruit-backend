
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Demo.ASB.CreditCardStore.Api.ExceptionHandlers
{
    public class HandleFluentValidationError
    {
        private readonly RequestDelegate next;
        public HandleFluentValidationError(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try 
            { 
                await next(context); 
            }
            catch (Exception ex) 
            { 
                await HandleExceptionAsync(context, ex); 
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception.GetType() == typeof(ValidationException))
            {
                var result = JsonConvert.SerializeObject(((ValidationException)exception).Errors);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return context.Response.WriteAsync(result);

            }
            else
            {
                var result = JsonConvert.SerializeObject(new { isSuccess = false, error = exception.Message });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return context.Response.WriteAsync(result);
            }
        }
    }
}