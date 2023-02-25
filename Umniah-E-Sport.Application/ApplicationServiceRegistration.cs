using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Umniah_E_Sport.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }

    }
}