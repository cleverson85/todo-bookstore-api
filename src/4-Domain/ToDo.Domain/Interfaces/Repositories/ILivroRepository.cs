using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;

namespace ToDo.Domain.Interfaces.Repositories
{
    public interface ILivroRepository : IBaseRepository<Livro>
    {
        Task<IList<Livro>> FindByAutor(LivroPesquisa livroPesquisa, PaginacaoParametroDto paginacaoParametro);
        Task<IList<Livro>> FindByAutorAndGenero(LivroPesquisa livroPesquisa, PaginacaoParametroDto paginacaoParametro);
        Task<IList<Livro>> FindByTitulo(LivroPesquisa livroPesquisa, PaginacaoParametroDto paginacaoParametro);
        Task<IList<Livro>> FindByTituloAndGenero(LivroPesquisa livroPesquisa, PaginacaoParametroDto paginacaoParametro);
        Task<IList<Livro>> FindByGenero(int generoId, PaginacaoParametroDto paginacaoParametro);
        Task<IList<Livro>> FindByDescription(string description, PaginacaoParametroDto paginacaoParametro);
        Task<IList<Livro>> FindByGeneroAndDescription(int generoId, string description, PaginacaoParametroDto paginacaoParametro);
    }
}
