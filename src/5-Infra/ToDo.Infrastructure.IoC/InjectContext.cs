using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Domain.Interfaces;
using ToDo.Infrastructure.Data;
using ToDo.Infrastructure.Data.Contexts;

namespace ToDo.Infrastructure.IoC
{
    public static class InjectContext
    {
        public static IServiceCollection ConfigureContext(this IServiceCollection services, string connection) => 
            services.AddDbContext<Context>(options => options.UseNpgsql(connection))
                    .AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
