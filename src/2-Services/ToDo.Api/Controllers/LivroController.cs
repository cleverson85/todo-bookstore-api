using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Api.Helpers;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;
using static ToDo.Domain.Util.Endpoints;

namespace ToDo.Api.Controllers
{
    [AuthorizeAttribute]
    [ApiController]
    [Route("api/livro/[action]")]
    public class LivroController : BaseController<Livro>
    {
        private readonly ILivroService _livroService;
        private readonly IGeneroService _generoService;

        public LivroController(ILivroService livroService, IGeneroService generoService) : base(livroService)
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
        [Route(Route.POST)]
        public override async Task<IActionResult> Save([FromBody] Livro entity)
        {
            await _livroService.Save(entity);
            return Ok(await GetAll(new PaginacaoParametroDto()));
        }
    }
}
