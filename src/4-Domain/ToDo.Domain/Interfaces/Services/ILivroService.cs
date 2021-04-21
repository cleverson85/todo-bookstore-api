using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;

namespace ToDo.Domain.Interfaces.Services
{
    public interface ILivroService : IBaseService<Livro>
    {
        Task<IList<Livro>> FindByTitulo(LivroPesquisa livroPesquisa, PaginacaoParametroDto paginacaoParametro);
        Task<IList<Livro>> FindByGenero(int generoId, PaginacaoParametroDto paginacaoParametro);
        Task<IList<Livro>> FindByAutor(LivroPesquisa livroPesquisa, PaginacaoParametroDto paginacaoParametro);
        Task<Livro> GetById(int id);
    }
}
