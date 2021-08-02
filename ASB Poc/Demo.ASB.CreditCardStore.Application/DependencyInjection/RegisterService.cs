
using Demo.ASB.CreditCardStore.Application.Behaviors;
using Demo.ASB.CreditCardStore.Application.Interfaces;
using Demo.ASB.CreditCardStore.Application.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.ASB.CreditCardStore.Application.DependencyInjection
{
    public class RegisterService : IRegisterService
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICardHolderService, CardHolderService>();
            services.AddScoped<ICreditCardService, CreditCardService>();

            services.AddValidatorsFromAssembly(typeof(ApplicationEntryPoint).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
