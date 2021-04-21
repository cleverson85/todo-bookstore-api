using Microsoft.Extensions.DependencyInjection;
using ToDo.Domain.Interfaces.Services;
using ToDo.Infrastructure.Data.Services;
using ToDo.Infrastructure.Services;

namespace ToDo.Infrastructure.IoC
{
    public static class InjectServices
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services) =>
            services.AddScoped<IClienteService, ClienteService>()
                    .AddScoped<IInstituicaoEnsinoService, InstituicaoEnsinoService>()
                    .AddScoped<ILivroService, LivroService>()
                    .AddScoped<IUsuarioService, UsuarioService>()
                    .AddScoped<IEmprestimoService, EmprestimoService>()
                    .AddScoped<IClienteBloqueioService, ClienteBloqueioService>()
                    .AddScoped<IAuthJwtService, AuthJwtService>()
                    .AddScoped<IGeneroService, GeneroService>();
    }
}
