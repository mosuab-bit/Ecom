using Ecom.core.Interfacies;
using Ecom.core.Services;
using Ecom.Infrustructure.Data;
using Ecom.Infrustructure.Repositories;
using Ecom.Infrustructure.Repositories.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Ecom.Infrustructure
{
    public static class infrastructureRegistration
    {
        public static IServiceCollection infrastructureConfiguration(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddSingleton<IImageManagementService,ImageManagementService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
            services.AddDbContext<AppDbContext>(op =>
            {
                op.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}