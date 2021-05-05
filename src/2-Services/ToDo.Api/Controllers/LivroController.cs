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
        public async Task<IActionResult> FindByAutor(string description, int generoId)
        {
            var result = await _livroService.FindByAutor(new LivroPesquisa(description, generoId));
            return Ok(new Resultado<Livro>(result, result.Count));
        }

        [HttpGet]
        [Route(Route.DESCRIPTION)]
        public async Task<IActionResult> FindByTitulo(string description, int generoId)
        {
            var result = await _livroService.FindByTitulo(new LivroPesquisa(description, generoId));
            return Ok(new Resultado<Livro>(result, result.Count));
        }

        [HttpGet]
        [Route(Route.ID)]
        public async Task<IActionResult> FindByGenero(int id)
        {
            var result = await _livroService.FindByGenero(id);
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
        [Route(Route.DESCRIPTION)]
        public async Task<IActionResult> FindByDescription(string description)
        {
            var result = await _livroService.FindByDescription(description);
            return Ok(new Resultado<Livro>(result, result.Count));
        }
    }
}
