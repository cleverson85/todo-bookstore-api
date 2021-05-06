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

        public async Task<IList<Livro>> FindByAutor(LivroPesquisa livroPesquisa)
        {
            if (livroPesquisa.generoId == 0)
            {
                return await _livroRepository.FindByAutor(livroPesquisa);
            }
            else
            {
                return await _livroRepository.FindByAutorAndGenero(livroPesquisa);
            }
        }

        public async Task<IList<Livro>> FindByTitulo(LivroPesquisa livroPesquisa)
        {
            if (livroPesquisa.generoId == 0)
            {
                return await _livroRepository.FindByTitulo(livroPesquisa);
            }
            else
            {
                return await _livroRepository.FindByTituloAndGenero(livroPesquisa);
            }
        }

        public async Task<IList<Livro>> FindByGenero(int generoId)
        {
            return await _livroRepository.FindByGenero(generoId);
        }

        public override async Task<IList<Livro>> GetAll(PaginacaoParametroDto paginacaoParametro)
        {
            return await base.GetAll(paginacaoParametro);
        }

        public override async Task<Livro> GetById(int id)
        {
            return await _livroRepository.GetById(id);
        }

        public async Task<IList<Livro>> FindByDescription(string description, PaginacaoParametroDto paginacaoParametro)
        {
            return await _livroRepository.FindByDescription(description, paginacaoParametro);
        }
    }
}
