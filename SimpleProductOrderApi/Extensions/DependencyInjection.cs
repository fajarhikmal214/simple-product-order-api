using SimpleProductOrderApi.Services;
using SimpleProductOrderApi.Repositories;

namespace SimpleProductOrderApi.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ProductRepository>();
            
            services.AddScoped<ProductService>();
            services.AddScoped<TokenService>();

            return services;
        }
    }
}