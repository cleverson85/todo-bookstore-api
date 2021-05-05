using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;

namespace ToDo.Domain.Interfaces.Repositories
{
    public interface ILivroRepository : IBaseRepository<Livro>
    {
        Task<IList<Livro>> FindByAutor(LivroPesquisa livroPesquisa);
        Task<IList<Livro>> FindByAutorAndGenero(LivroPesquisa livroPesquisa);
        Task<IList<Livro>> FindByTitulo(LivroPesquisa livroPesquisa);
        Task<IList<Livro>> FindByTituloAndGenero(LivroPesquisa livroPesquisa);
        Task<IList<Livro>> FindByGenero(int generoId);
        Task<IList<Livro>> FindByDescription(string description);
    }
}
