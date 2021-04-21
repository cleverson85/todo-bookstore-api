using AutoFixture;
using System;
using System.Collections.Generic;
using ToDo.Domain.Models;

namespace TestProject.Factories
{
    public static class DomainFactory
    {
        public static Pessoa BuildPessoa(string nome, string email, string telefone)
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

        public static Cliente BuildCliente()
        {
            var pessoa = BuildPessoa($"Cliente Teste {DateTime.Now}", "clienteteste@gmail.com", "99999-3333");

            var fixture = new Fixture();
            var cliente = fixture.Build<Cliente>()
                .With(c => c.Id, 0)
                .With(c => c.Cpf, "340.112.370-00")
                .With(c => c.Pessoa, pessoa)
                .Without(c => c.InstituicaoEnsino)
                .Create();

            return cliente;
        }

        public static InstituicaoEnsino BuildIntituicao()
        {
            var pessoa = BuildPessoa("Instituicao Ensino Teste", "intituicaoensino@gmail.com", "11111-3333");

            var fixture = new Fixture();
            var instituicaoEnsino = fixture.Build<InstituicaoEnsino>()
                .With(c => c.Id, 0)
                .With(c => c.Pessoa, pessoa)
                .With(c => c.Cnpj, "21.315.992/0001-16")
                .Create();

            return instituicaoEnsino;
        }

        public static Livro BuildLivro()
        {
            var fixture = new Fixture();
            var livro = fixture.Build<Livro>()
                .With(c => c.Id, 0)
                .With(c => c.Titulo, "A Torre Negra")
                .Create();

            return livro;
        }

        public static IList<Livro> BuildListaLivros()
        {
            string[] nomeLivro = { "O Senhor dos Anéis", "A Ordem da Fenix", "Game of Thrones", "A Torre Negra", "O Retorno do Rei" };
            IList<Livro> livros = new List<Livro>();

            var fixture = new Fixture();

            foreach (var item in nomeLivro)
            {
                livros.Add(fixture.Build<Livro>()
                               .With(c => c.Id, 0)
                               .With(c => c.Titulo, item)
                               .Create()
                           );
            }

            return livros;
        }

        public static Usuario BuildUsuario()
        {
            var pessoa = BuildPessoa($"Usuario {DateTime.Now}", "usuario@email.com", "99999-3333");

            var fixture = new Fixture();
            var usuario = fixture.Build<Usuario>()
                .With(c => c.Id, 0)
                .With(c => c.Pessoa, pessoa)
                .With(c => c.Senha, "123456")
                .Create();

            return usuario;
        }
    }
}
