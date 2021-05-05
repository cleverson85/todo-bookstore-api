using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Factories;
using ToDo.Api;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;
using ToDo.Infrastructure.Services;
using Xunit;

namespace TestProject
{
    public class UnitTest
    {
        private readonly IClienteService _clienteService;
        private readonly IInstituicaoEnsinoService _instituicaoEnsinoService;
        private readonly ILivroService _livroService;
        private readonly IEmprestimoService _emprestimoService;
        private readonly IClienteBloqueioService _clienteBloqueioService;
        private readonly IUsuarioService _usuarioService;

        private readonly IUnitOfWork _unitOfWork;

        private readonly DependencyResolverHelpercs _serviceProvider;

        public UnitTest()
        {
            var webHost = WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseEnvironment("Development")
                .Build();
            _serviceProvider = new DependencyResolverHelpercs(webHost);

            _usuarioService = _serviceProvider.GetService<IUsuarioService>();
            _clienteService = _serviceProvider.GetService<IClienteService>();
            _instituicaoEnsinoService = _serviceProvider.GetService<IInstituicaoEnsinoService>();
            _livroService = _serviceProvider.GetService<ILivroService>();
            _emprestimoService = _serviceProvider.GetService<IEmprestimoService>();
            _clienteBloqueioService = _serviceProvider.GetService<IClienteBloqueioService>();

            _unitOfWork = _serviceProvider.GetService<IUnitOfWork>();
        }

        [Fact]
        public void ServiceInstanceTest()
        {
            var clienteService = _serviceProvider.GetService<IClienteService>();
            Assert.NotNull(clienteService);
        }

        [Fact]
        public async Task DeveInserirUmCliente()
        {
            var cliente = DomainFactory.BuildCliente();
            await _unitOfWork.GetRepository<Cliente>().Save(cliente);

            var result = await _unitOfWork.Commit();
            Assert.NotEqual(0, result);
        }

        [Fact]
        public async Task DeveRetornarUmClientePeloCpf()
        {
            var cliente = await _clienteService.FindByCpf(DomainFactory.BuildCliente().Cpf);
            Assert.NotNull(cliente);
        }

        [Fact]
        public async Task DeveRetornarUmClientePeloEmail()
        {
            var cliente = await _clienteService.FindByEmail(DomainFactory.BuildCliente().Pessoa.Email);
            Assert.NotNull(cliente);
        }

        [Fact]
        public async Task DeveBuscarUmClientePeloNome()
        {
            var cliente = await _clienteService.FindByName(DomainFactory.BuildCliente().Pessoa.Nome);
            Assert.NotNull(cliente);
        }

        [Fact]
        public async Task DeveAtualizarUmCliente()
        {
            var cliente = await _clienteService.FindByCpf("340.112.370-99");

            cliente.Pessoa.Nome = "Cliente Teste Atualizado";
            cliente.Cpf = "123.531.706-90";

            await _unitOfWork.GetRepository<Cliente>().Save(cliente);

            var result = await _unitOfWork.Commit();
            Assert.NotEqual(0, result);
        }

        [Fact]
        public async Task DeveInserirUmaInstituicaoEnsino()
        {
            var instituicaoEnsino = DomainFactory.BuildIntituicao();

            await _unitOfWork.GetRepository<InstituicaoEnsino>().Save(instituicaoEnsino);
            await _unitOfWork.Commit();

            var instituicaoEnsinoAdd = await _instituicaoEnsinoService.FindInstituicaoByName(instituicaoEnsino.Pessoa.Nome);
            Assert.NotNull(instituicaoEnsinoAdd);
        }

        [Fact]
        public async Task DeveBuscarUmaInstituicaoEnsinoPeloCnpj()
        {
            var instituicaoEnsino = await _instituicaoEnsinoService.FindInstituicaoEnsinoByCnpj(DomainFactory.BuildIntituicao().Cnpj);
            Assert.NotNull(instituicaoEnsino);
        }

        [Fact]
        public async Task DeveBuscarUmaInstituicaoEnsinoPeloNome()
        {
            var instituicaoEnsino = await _instituicaoEnsinoService.FindInstituicaoByName(DomainFactory.BuildIntituicao().Pessoa.Nome);
            Assert.NotNull(instituicaoEnsino);
        }

        [Fact]
        public async Task DeveInserirUmLivro()
        {
            var livro = DomainFactory.BuildLivro();
            await _unitOfWork.GetRepository<Livro>().Save(livro);

            var result = await _unitOfWork.Commit();
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task DeveInserirUmaListaLivros()
        {
            var livros = DomainFactory.BuildListaLivros();

            await _unitOfWork.GetRepository<Livro>().SaveList(livros);

            var result = await _unitOfWork.Commit();
            Assert.Equal(livros.Count, result);
        }

        [Fact]
        public async Task DeveRetornarLivroPorGenero()
        {
            var livros = await _livroService.FindByGenero(1);
            Assert.NotNull(livros);
        }

        [Fact]
        public async Task DeveFazerEmprestimo()
        {
            var livro = await _livroService.FindByTitulo(new LivroPesquisa("O Retorno do Rei", 0));
            var cliente = await _clienteService.GetAll();

            var emprestimo = new Emprestimo();
            emprestimo.AdicionarLivroEmprestimo(cliente.LastOrDefault(), livro);

            await _unitOfWork.GetEmprestimoRepository().SaveEmprestimo(emprestimo);

            var result = await _unitOfWork.Commit();
            Assert.NotEqual(0, result);
        }

        [Fact]
        public async Task DeveAtualizarEmprestimo()
        {
            var emprestimo = await _emprestimoService.GetById(6);

            emprestimo.DataDevolucao = emprestimo.DataDevolucao.AddDays(-110);

            var livro = await _livroService.FindByTitulo(new LivroPesquisa("A Torre Negra", 0));
            livro.ToList().ForEach(c => c.Disponivel = false);

            emprestimo.AdicionarLivroEmprestimo(emprestimo.Cliente, livro);

            await _unitOfWork.GetEmprestimoRepository().SaveEmprestimo(emprestimo);

            var result = await _unitOfWork.Commit();
            Assert.NotEqual(0, result);
        }

        [Fact]
        public async Task DeveInserirUmUsuario()
        {
            var usuario = DomainFactory.BuildUsuario();

            var account = await _usuarioService.Register(usuario);

            //await _unitOfWork.GetRepository<Usuario>().Save(usuario);

            //var result = await _unitOfWork.Commit();
            //Assert.NotEqual(0, result);
        }

        [Fact]
        public async Task DeveAutenticarUmUsuario()
        {
            var usuario = DomainFactory.BuildUsuario();

            var autheticated = await _usuarioService.Authenticate(usuario);
            Assert.NotNull(autheticated);
        }
    }
}
