using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;

namespace ToDo.Infrastructure.Services
{
    public class LivroService : BaseService<Livro>, ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository) : base(livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<IList<Livro>> FindByAutor(LivroPesquisa livroPesquisa, PaginacaoParametroDto paginacaoParametro)
        {
            if (livroPesquisa.generoId == 0)
            {
                return await _livroRepository.FindByAutor(livroPesquisa, paginacaoParametro);
            }
            else
            {
                return await _livroRepository.FindByAutorAndGenero(livroPesquisa, paginacaoParametro);
            }
        }

        public async Task<IList<Livro>> FindByTitulo(LivroPesquisa livroPesquisa, PaginacaoParametroDto paginacaoParametro)
        {
            if (livroPesquisa.generoId == 0)
            {
                return await _livroRepository.FindByTitulo(livroPesquisa, paginacaoParametro);
            }
            else
            {
                return await _livroRepository.FindByTituloAndGenero(livroPesquisa, paginacaoParametro);
            }
        }

        public async Task<IList<Livro>> FindByGenero(int generoId, PaginacaoParametroDto paginacaoParametro)
        {
            return await _livroRepository.FindByGenero(generoId, paginacaoParametro);
        }

        public async Task<IList<Livro>> FindByGeneroAndDescription(int generoId, string description, PaginacaoParametroDto paginacaoParametro)
        {
            return await _livroRepository.FindByGeneroAndDescription(generoId, description, paginacaoParametro);
        }

        public override async Task<IList<Livro>> GetAll(PaginacaoParametroDto paginacaoParametro)
        {
            return await base.GetAll(paginacaoParametro);
        }

        public override async Task<Livro> GetById(int id)
        {
            return await _livroRepository.GetById(id);
        }

        public override async Task<IList<Livro>> FindByDescription(string description, PaginacaoParametroDto paginacaoParametro)
        {
            return await _livroRepository.FindByDescription(description, paginacaoParametro);
        }        
    }
}
