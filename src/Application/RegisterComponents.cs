using Application.Services.Customers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class RegisterComponents
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
