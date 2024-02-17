
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace IMS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }

    }
}
