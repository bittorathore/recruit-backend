
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Demo.ASB.CreditCardStore.Application;
using Demo.ASB.CreditCardStore.InfraStructure.Data;
using Demo.ASB.CreditCardStore.Api.Options;
using Demo.ASB.CreditCardStore.Api.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Demo.ASB.CreditCardStore.Api.Validations;
using Demo.ASB.CreditCardStore.InfraStructure.DependencyInjection;
using Demo.ASB.CreditCardStore.Application.DependencyInjection;

namespace Demo.ASB.CreditCardStore.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddControllers().AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<CreateCreditCardRequestValidator>());

            services.AddValidatorsFromAssembly(typeof(ApplicationEntryPoint).Assembly);
            services.AddDataProtection();
            services.AddAutoMapper(typeof(Startup));

            services.AddAutoMapper(typeof(ApplicationEntryPoint).Assembly);
            services.AddMediatR(typeof(ApplicationEntryPoint).Assembly);

            services.AddJwtServicesInAssemblies(Configuration);
            services.AddSwaggerServicesInAssemblies(Configuration);
            services.AddApplicationServicesInAssemblies(Configuration);
            services.AddInfraStructureServicesInAssemblies(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app.UseErrorHandlingMiddleware();

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(swaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });
            app.UseSwaggerUI(option => { option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description); });

            app.UseHttpsRedirection();
            
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
