using Microsoft.Extensions.DependencyInjection;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Infrastructure.Data.Repositories;

namespace ToDo.Infrastructure.IoC
{
    public static class InjectRepositories
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services) =>
            services.AddScoped<IClienteRepository, ClienteRepository>()
                    .AddScoped<IInstituicaoEnsinoRepository, InstituicaoEnsinoRepository>()
                    .AddScoped<ILivroRepository, LivroRepository>()
                    .AddScoped<IUsuarioRepository, UsuarioRepository>()
                    .AddScoped<IEmprestimoRepository, EmprestimoRepository>()
                    .AddScoped<IClienteBloqueioRepository, ClienteBloqueioRepository>()
                    .AddScoped<IGeneroRepository, GeneroRepository>();
    }
}
