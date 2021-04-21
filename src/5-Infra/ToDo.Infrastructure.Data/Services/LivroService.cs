using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;

namespace ToDo.Infrastructure.Services
{
    public class LivroService : BaseService<Livro>, ILivroService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILivroRepository _livroRepository;
        private readonly Expression<Func<Livro, object>>[] include = { c => c.Genero };

        public LivroService(ILivroRepository livroRepository, IUnitOfWork unitOfWork) : base(livroRepository)
        {
            _livroRepository = livroRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Livro>> FindByAutor(LivroPesquisa livroPesquisa, PaginacaoParametroDto paginacaoParametro)
        {
            if (livroPesquisa.generoId == 0)
            {
                return await _livroRepository.GetByExpression(paginacaoParametro, c => c.Autor.Contains(livroPesquisa.description), c => c.OrderBy(e => e.Autor), include);
            }
            else
            {
                return await _livroRepository.GetByExpression(paginacaoParametro,
                    c => c.Autor.Contains(livroPesquisa.description) && c.Genero.Id == livroPesquisa.generoId,
                    c => c.OrderBy(e => e.Autor), include);
            }
        }

        public async Task<IList<Livro>> FindByTitulo(LivroPesquisa livroPesquisa, PaginacaoParametroDto paginacaoParametro)
        {
            if (livroPesquisa.generoId == 0)
            {
                return await _livroRepository.GetByExpression(paginacaoParametro, c => c.Titulo.Contains(livroPesquisa.description), c => c.OrderBy(e => e.Titulo), include);
            }
            else
            {
                return await _livroRepository.GetByExpression(paginacaoParametro, 
                    c => c.Titulo.Contains(livroPesquisa.description) && c.Genero.Id == livroPesquisa.generoId,
                    c => c.OrderBy(e => e.Titulo), include);
            }
        }

        public async Task<IList<Livro>> FindByGenero(int generoId, PaginacaoParametroDto paginacaoParametro)
        {
            return await _livroRepository.GetByExpression(paginacaoParametro, c => c.Genero.Id == generoId, c => c.OrderBy(e => e.Titulo), include);
        }

        public override Task<IList<Livro>> GetAll(PaginacaoParametroDto paginacaoParametro, params Expression<Func<Livro, object>>[] includes)
        {
            return base.GetAll(paginacaoParametro, include);
        }

        public async Task<Livro> GetById(int id)
        {
            return await _repository.GetById(id, include);
        }
    }
}
