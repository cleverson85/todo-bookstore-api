using Microsoft.Extensions.DependencyInjection;
using ToDo.Domain.Interfaces.Services;
using ToDo.Infrastructure.Data.Services;
using ToDo.Infrastructure.Services;

namespace ToDo.Infrastructure.IoC
{
    public static class InjectServices
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services) =>
            services.AddTransient<IClienteService, ClienteService>()
                    .AddTransient<IInstituicaoEnsinoService, InstituicaoEnsinoService>()
                    .AddTransient<ILivroService, LivroService>()
                    .AddTransient<IUsuarioService, UsuarioService>()
                    .AddTransient<IEmprestimoService, EmprestimoService>()
                    .AddTransient<IClienteBloqueioService, ClienteBloqueioService>()
                    .AddTransient<IAuthJwtService, AuthJwtService>()
                    .AddTransient<IGeneroService, GeneroService>();
    }
}
