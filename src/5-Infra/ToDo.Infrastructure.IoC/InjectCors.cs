using Microsoft.Extensions.DependencyInjection;

namespace ToDo.Infrastructure.IoC
{
    public static class InjectCors
    {
        public static IServiceCollection ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                );
            });
    }
}
