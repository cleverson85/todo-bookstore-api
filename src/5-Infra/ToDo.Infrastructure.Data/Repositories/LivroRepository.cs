using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;

namespace ToDo.Infrastructure.Data.Repositories
{
    public class LivroRepository : BaseRepository<Livro>, ILivroRepository
    {
        private readonly Expression<Func<Livro, object>>[] include = { c => c.Genero };
        private readonly IGeneroRepository _generoRepository;

        public LivroRepository(IUnitOfWork unitOfWork, IGeneroRepository generoRepository) : base(unitOfWork)
        {
            _generoRepository = generoRepository;
        }

        public async Task<IList<Livro>> FindByAutor(LivroPesquisa livroPesquisa, PaginacaoParametroDto paginacaoParametro)
        {
            return await GetByExpression(paginacaoParametro,
                    c => c.Autor.ToLower().Contains(livroPesquisa.description.ToLower()), c => c.OrderBy(e => e.Autor), include);
        }

        public async Task<IList<Livro>> FindByAutorAndGenero(LivroPesquisa livroPesquisa, PaginacaoParametroDto paginacaoParametro)
        {
            return await GetByExpression(paginacaoParametro, c => c.Autor.ToLower().Contains(livroPesquisa.description.ToLower()) && c.Genero.Id == livroPesquisa.generoId,
                    c => c.OrderBy(e => e.Autor), include);
        }

        public async Task<IList<Livro>> FindByDescription(string description, PaginacaoParametroDto paginacaoParametro)
        {
            int.TryParse(description, out int result);

            var livros = await GetByExpression(paginacaoParametro, c => c.Titulo.ToLower().Contains(description.ToLower()) ||
                     c.Autor.ToLower().Contains(description.ToLower()) || (c.Genero != null && c.Genero.Id == result), null, include);
            return livros;
        }

        public async Task<IList<Livro>> FindByGenero(int generoId, PaginacaoParametroDto paginacaoParametro)
        {
            return await GetByExpression(paginacaoParametro, c => c.Genero.Id == generoId, c => c.OrderBy(e => e.Titulo), include);
        }

        public async Task<IList<Livro>> FindByGeneroAndDescription(int generoId, string description, PaginacaoParametroDto paginacaoParametro)
        {
            var livros = await GetByExpression(paginacaoParametro, c => c.Titulo.ToLower().Contains(description.ToLower()) ||
                     c.Autor.ToLower().Contains(description.ToLower()), null, include);

            return livros.Where(c => c.Genero.Id == generoId).ToList();
        }

        public async Task<IList<Livro>> FindByTitulo(LivroPesquisa livroPesquisa, PaginacaoParametroDto paginacaoParametro)
        {
            return await GetByExpression(paginacaoParametro, c => c.Titulo.ToLower().Contains(livroPesquisa.description.ToLower()), c => c.OrderBy(e => e.Titulo), include);
        }

        public async Task<IList<Livro>> FindByTituloAndGenero(LivroPesquisa livroPesquisa, PaginacaoParametroDto paginacaoParametro)
        {
            return await GetByExpression(paginacaoParametro, c => c.Titulo.ToLower().Contains(livroPesquisa.description.ToLower()) && c.Genero.Id == livroPesquisa.generoId,
                   c => c.OrderBy(e => e.Titulo), include);
        }

        public override async Task<IList<Livro>> GetAll(PaginacaoParametroDto paginacaoParametro = null, params Expression<Func<Livro, object>>[] includes)
        {
            return await base.GetAll(paginacaoParametro, include);
        }

        public override async Task<Livro> GetById(int id, params Expression<Func<Livro, object>>[] includes)
        {
            return await base.GetById(id, include);
        }

        public override async Task<Livro> Save(Livro entity)
        {
            entity.Genero = await _generoRepository.GetById(entity.Genero.Id);
            return await base.Save(entity);
        }
    }
}
