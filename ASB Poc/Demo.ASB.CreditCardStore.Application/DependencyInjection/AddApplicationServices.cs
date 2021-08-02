
using Demo.ASB.CreditCardStore.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Linq;


namespace Demo.ASB.CreditCardStore.Application.DependencyInjection
{
    public static class AddApplicationServices
    {
        public static void AddApplicationServicesInAssemblies(this IServiceCollection services, IConfiguration configuration)
        {
            var servicesToRegister = typeof(ApplicationEntryPoint).Assembly.ExportedTypes.
                Where(x => typeof(IRegisterService).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).
                Select(Activator.CreateInstance).Cast<IRegisterService>().ToList();

            servicesToRegister.ForEach(servicesToRegister => servicesToRegister.RegisterServices(services, configuration));
        }
    }
}
