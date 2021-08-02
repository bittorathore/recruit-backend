
using Demo.ASB.CreditCardStore.Api.ExceptionHandlers;
using Microsoft.AspNetCore.Builder;

namespace Demo.ASB.CreditCardStore.Api.Extensions
{
    public static class ErrorHandlingMiddlewareExtension
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(
        this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HandleFluentValidationError>();
        }
    }
}
