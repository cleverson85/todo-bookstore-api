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
    [Route("api/livro/[action]")]
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
        [Route(Route.DESCRIPTION)]
        public async Task<IActionResult> FindByAutor(string description, int generoId, [FromQuery] PaginacaoParametroDto paginacaoParametro)
        {
            var result = await _livroService.FindByAutor(new LivroPesquisa(description, generoId), paginacaoParametro);
            return Ok(new Resultado<Livro>(result, result.Count));
        }

        [HttpGet]
        [Route(Route.DESCRIPTION)]
        public async Task<IActionResult> FindByTitulo(string description, int generoId, [FromQuery] PaginacaoParametroDto paginacaoParametro)
        {
            var result = await _livroService.FindByTitulo(new LivroPesquisa(description, generoId), paginacaoParametro);
            return Ok(new Resultado<Livro>(result, result.Count));
        }

        [HttpGet]
        [Route(Route.ID)]
        public async Task<IActionResult> FindByGenero(int id, [FromQuery] PaginacaoParametroDto paginacaoParametro)
        {
            var result = await _livroService.FindByGenero(id, paginacaoParametro);
            return Ok(new Resultado<Livro>(result, result.Count));
        }

        [HttpGet]
        [Route(Route.ALL)]
        public async Task<IActionResult> GetAllGeneros()
        {
            var result = await _generoService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route(Route.ID)]
        public override async Task<IActionResult> FindById(int id)
        {
            var result = await _livroService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route(Route.ALL)]
        public override async Task<IActionResult> FindByDescription([FromBody] Pesquisa pesquisa)
        {
            var result = await _livroService.FindByDescription(pesquisa.Description, new PaginacaoParametroDto());
            return Ok(new Resultado<Livro>(result, result.Count));
        }
    }
}
