using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDo.Domain.Enum;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;

namespace ToDo.Infrastructure.Services
{
    public class EmprestimoService : BaseService<Emprestimo>, IEmprestimoService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly Expression<Func<Emprestimo, object>>[] include = { c => c.Cliente, c => c.LivrosEmprestimo, c => c.Cliente.Pessoa, c => c.Cliente.InstituicaoEnsino };

        public EmprestimoService(IEmprestimoRepository emprestimoRepository) : base(emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }

        public async Task EfetuarEmprestimo(Cliente cliente, IList<Livro> livros)
        {
            var emprestimo = new Emprestimo();
            emprestimo.AdicionarLivroEmprestimo(cliente, livros);

            await _emprestimoRepository.Save(emprestimo);
        }

        public async Task AtualizarSituacaoEmprestimo(Emprestimo emprestimo, SituacaoEmprestimo situacao)
        {
            emprestimo.Situacao = situacao;
            await _emprestimoRepository.Save(emprestimo);
        }

        public async Task<Emprestimo> FindById(int id)
        {
            return await _emprestimoRepository.GetById(id, include);
        }

        public async Task<Emprestimo> EfetuarDevolucaoLivro(int emprestimoId, IList<Livro> livros)
        {
            var emprestimo = await GetById(emprestimoId);

            foreach (var item in emprestimo.LivrosEmprestimo)
            {
                item.Pendente = false;
                item.Livro.Disponivel = true;
            }

            emprestimo.Situacao = emprestimo.LivrosEmprestimo.Any(c => c.Pendente) ? SituacaoEmprestimo.Pendente : SituacaoEmprestimo.Concluída;

            await _emprestimoRepository.Save(emprestimo);

            return emprestimo;
        }

        public override async Task<IList<Emprestimo>> FindByDescription(string description, PaginacaoParametroDto paginacaoParametro)
        {
            var emprestimo = await _emprestimoRepository.GetByExpression(new PaginacaoParametroDto(),
                c => c.Cliente.Pessoa.Nome.Contains(description) || c.Cliente.Cpf.Contains(description), null, include);
            return emprestimo;
        }
    }
}
