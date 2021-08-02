
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.ASB.CreditCardStore.InfraStructure.DependencyInjection
{
    public interface IRegisterService
    {
        void RegisterServices(IServiceCollection services, IConfiguration configuration);
    }
}
