
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.ASB.CreditCardStore.Application.Interfaces
{
    public interface IRegisterService
    {
        void RegisterServices(IServiceCollection services, IConfiguration configuration);
    }
}
