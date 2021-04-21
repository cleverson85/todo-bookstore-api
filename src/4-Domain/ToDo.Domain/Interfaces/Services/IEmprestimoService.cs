using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Enum;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Services
{
    public interface IEmprestimoService : IBaseService<Emprestimo>
    {
        Task EfetuarEmprestimo(Cliente cliente, IList<Livro> livros);
        Task AtualizarSituacaoEmprestimo(Emprestimo emprestimo, SituacaoEmprestimo Situacao);
        Task<Emprestimo> FindById(int id);
        Task<Emprestimo> EfetuarDevolucaoLivro(int emprestimoId, IList<Livro> livros);
    }
}
