
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Demo.ASB.CreditCardStore.InfraStructure.DependencyInjection
{
    public static class AddInfraStructureServices
    {
        public static void AddInfraStructureServicesInAssemblies(this IServiceCollection services, IConfiguration configuration)
        {
            var servicesToRegister = typeof(InfraStructureEntryPoint).Assembly.ExportedTypes.
                Where(x => typeof(IRegisterService).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).
                Select(Activator.CreateInstance).Cast<IRegisterService>().ToList();

            servicesToRegister.ForEach(servicesToRegister => servicesToRegister.RegisterServices(services, configuration));
        }
    }
}
