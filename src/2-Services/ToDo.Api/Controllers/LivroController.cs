using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDo.Application.ViewModels;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;
using static ToDo.Domain.Util.Endpoints;

namespace ToDo.Api.Controllers
{
    [Helpers.Authorize]
    [ApiController]
    [Route(Recursos.Livro)]
    public class LivroController : BaseController<Livro, LivroViewModel>
    {
        private readonly ILivroService _livroService;
        private readonly IGeneroService _generoService;

        public LivroController(ILivroService livroService, IGeneroService generoService, IMapper mapper) : base(livroService, mapper)
        {
            _livroService = livroService;
            _generoService = generoService;
        }

        [HttpGet]
        [Route(Route.AUTOR)]
        public async Task<IActionResult> FindByAutor(string autor, [FromQuery] PaginacaoParametroDto paginacaoParametro)
        {
            var result = await _livroService.FindByAutor(new LivroPesquisa(autor, 0), paginacaoParametro);
            return Ok(new Resultado<Livro>(result, result.Count));
        }

        [HttpGet]
        [Route(Route.TITULO)]
        public async Task<IActionResult> FindByTitulo(string titulo, [FromQuery] PaginacaoParametroDto paginacaoParametro)
        {
            var result = await _livroService.FindByTitulo(new LivroPesquisa(titulo, 0), paginacaoParametro);
            return Ok(new Resultado<Livro>(result, result.Count));
        }

        [HttpGet]
        [Route(Route.GENERO_ID)]
        public async Task<IActionResult> FindByGenero(int id, [FromQuery] PaginacaoParametroDto paginacaoParametro)
        {
            var result = await _livroService.FindByGenero(id, paginacaoParametro);
            return Ok(new Resultado<Livro>(result, result.Count));
        }

        [HttpGet]
        [Route(Route.GENERO_ID_DESCRIPTION)]
        public async Task<IActionResult> FindByGeneroAndDescription(int id, string description, [FromQuery] PaginacaoParametroDto paginacaoParametro)
        {
            var result = await _livroService.FindByGeneroAndDescription(id, description, paginacaoParametro);
            return Ok(new Resultado<Livro>(result, result.Count));
        }

        [HttpGet]
        [Route(Route.GENEROS)]
        public async Task<IActionResult> GetAllGeneros()
        {
            var result = await _generoService.GetAll();
            return Ok(result);
        }


        [HttpGet]
        [Route(Route.DESCRIPTION)]
        public async Task<IActionResult> FindByDescription(string description, [FromQuery] PaginacaoParametroDto paginacaoParametro)
        {
            var result = await _livroService.FindByDescription(description, paginacaoParametro);
            return Ok(new Resultado<Livro>(result, result.Count));
        }
    }
}
