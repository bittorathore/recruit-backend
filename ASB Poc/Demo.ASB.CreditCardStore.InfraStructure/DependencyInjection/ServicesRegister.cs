
using Demo.ASB.CreditCardStore.Application.Interfaces;
using Demo.ASB.CreditCardStore.InfraStructure.Data;
using Demo.ASB.CreditCardStore.InfraStructure.Interfaces;
using Demo.ASB.CreditCardStore.InfraStructure.Repositories;
using Demo.ASB.CreditCardStore.InfraStructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.ASB.CreditCardStore.InfraStructure.DependencyInjection
{
    public class ServicesRegister : IRegisterService
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<ICreditCardRepository, CreditCardRepository>();
            services.AddScoped<ICardHolderRepository, CardHolderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDataEncryption,EncryptionService>();

            services.AddSingleton<IUriService>(uri =>
            {
                var accessor = uri.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var baseUri = string.Concat(request.Scheme + "://" + request.Host.ToUriComponent()+"/");
                return new UriService(baseUri);
            });
        }
    }
}