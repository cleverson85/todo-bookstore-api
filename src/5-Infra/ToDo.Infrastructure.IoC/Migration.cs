using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using ToDo.Domain.Models;
using ToDo.Infrastructure.Data.Contexts;
using BC = BCrypt.Net.BCrypt;

namespace ToDo.Infrastructure.IoC
{
    public static class Migration
    {
        public static IHost MigrateDbContext<TContext>(this IHost host) where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<TContext>();
                context.Database.Migrate();
#if DEBUG
               // InserirUsuarioAdmin(context as Context);
#endif
            }

            return host;
        }
        private static void InserirUsuarioAdmin(Context context)
        {
            context.AddRange(BuildGenero());
            context.AddRange(BuildListaLivros());
            context.Add(BuildUsuario());

            context.SaveChanges();
        }

        private static Pessoa BuildPessoa(string nome, string email, string telefone)
        {
            var fixture = new Fixture();
            var pessoa = fixture.Build<Pessoa>()
                .With(c => c.Id, 0)
                .With(c => c.Nome, nome)
                .With(c => c.Telefone, telefone)
                .With(c => c.Email, email)
                .Create();

            return pessoa;
        }

        private static Usuario BuildUsuario()
        {
            var pessoa = BuildPessoa($"Usuario", "usuario@admin.com.br", "99999-3333");

            var fixture = new Fixture();
            var usuario = fixture.Build<Usuario>()
                .With(c => c.Id, 0)
                .With(c => c.Pessoa, pessoa)
                .With(c => c.Senha, BC.HashPassword("123456"))
                .Create();

            return usuario;
        }

        private static IList<Genero> BuildGenero()
        {
            string[] generos = { "Química", "Física", "Inglês", "Português", "Literatura", "Matemática", "Biologia", "Outros" };
            IList<Genero> genero = new List<Genero>();

            var fixture = new Fixture();

            foreach (var item in generos)
            {
                genero.Add(fixture.Build<Genero>()
                               .With(c => c.Id, 0)
                               .With(c => c.Nome, item)
                               .Create()
                           );
            }

            return genero;
        }

        private static IList<Livro> BuildListaLivros()
        {
            string[] nomeLivro = { "O Senhor dos Anéis", "A Ordem da Fenix", "Game of Thrones", "A Torre Negra", "O Retorno do Rei" };
            IList<Livro> livros = new List<Livro>();

            var fixture = new Fixture();

            foreach (var item in nomeLivro)
            {
                livros.Add(fixture.Build<Livro>()
                               .With(c => c.Id, 0)
                               .With(c => c.Titulo, item)
                               .Without(c => c.Genero)
                               .Create()
                           );
            }

            return livros;
        }
    }
}
