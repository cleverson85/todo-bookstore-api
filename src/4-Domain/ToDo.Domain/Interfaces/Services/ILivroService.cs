using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;

namespace ToDo.Domain.Interfaces.Services
{
    public interface ILivroService : IBaseService<Livro>
    {
        Task<IList<Livro>> FindByTitulo(LivroPesquisa livroPesquisa);
        Task<IList<Livro>> FindByGenero(int generoId);
        Task<IList<Livro>> FindByAutor(LivroPesquisa livroPesquisa);
        Task<IList<Livro>> FindByDescription(string description);
    }
}
