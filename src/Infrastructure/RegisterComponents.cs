using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class RegisterComponents
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseInMemoryDatabase("User");
            });

            services.AddScoped<IDataRepository, DataRepository>();

            return services;
        }
    }
}
