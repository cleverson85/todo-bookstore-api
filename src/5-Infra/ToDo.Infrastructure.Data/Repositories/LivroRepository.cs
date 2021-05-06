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

        public LivroRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public async Task<IList<Livro>> FindByAutor(LivroPesquisa livroPesquisa)
        {
            return await GetByExpression(new PaginacaoParametroDto(),
                    c => c.Autor.ToLower().Contains(livroPesquisa.description.ToLower()), c => c.OrderBy(e => e.Autor), include);
        }

        public async Task<IList<Livro>> FindByAutorAndGenero(LivroPesquisa livroPesquisa)
        {
            return await GetByExpression(new PaginacaoParametroDto(), c => c.Autor.ToLower().Contains(livroPesquisa.description.ToLower()) && c.Genero.Id == livroPesquisa.generoId,
                    c => c.OrderBy(e => e.Autor), include);
        }

        public async Task<IList<Livro>> FindByDescription(string description, PaginacaoParametroDto paginacaoParametroDto)
        {
            int.TryParse(description, out int result);

            var livros = await GetByExpression(paginacaoParametroDto, c => c.Titulo.ToLower().Contains(description.ToLower()) ||
                     c.Autor.ToLower().Contains(description.ToLower()) || (c.Genero != null && c.Genero.Id == result), null, include);
            return livros;
        }

        public async Task<IList<Livro>> FindByGenero(int generoId)
        {
            return await GetByExpression(new PaginacaoParametroDto(), c => c.Genero.Id == generoId, c => c.OrderBy(e => e.Titulo), include);
        }

        public async Task<IList<Livro>> FindByTitulo(LivroPesquisa livroPesquisa)
        {
            return await GetByExpression(new PaginacaoParametroDto(), c => c.Titulo.ToLower().Contains(livroPesquisa.description.ToLower()), c => c.OrderBy(e => e.Titulo), include);
        }

        public async Task<IList<Livro>> FindByTituloAndGenero(LivroPesquisa livroPesquisa)
        {
            return await GetByExpression(new PaginacaoParametroDto(), c => c.Titulo.ToLower().Contains(livroPesquisa.description.ToLower()) && c.Genero.Id == livroPesquisa.generoId,
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
    }
}
