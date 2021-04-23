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
    [Route("api/instituicao/[action]")]
    public class InstituicaoEnsinoController : BaseController<InstituicaoEnsino, InstituicaoEnsinoViewModel>
    {
        private readonly IInstituicaoEnsinoService _instituicaoEnsinoService;

        public InstituicaoEnsinoController(IInstituicaoEnsinoService instituicaoEnsinoService, IMapper mapper) : base(instituicaoEnsinoService, mapper)
        {
            _instituicaoEnsinoService = instituicaoEnsinoService;
        }

        [HttpGet]
        [Route(Route.DESCRIPTION)]
        public async Task<IActionResult> FindInstituicaoByName(string description)
        {
            var result = await _instituicaoEnsinoService.FindInstituicaoByName(description);
            return Ok(result);
        }

        [HttpGet]
        [Route(Route.DESCRIPTION)]
        public async Task<IActionResult> FindInstituicaoEnsinoByCnpj(string description)
        {
            var result = await _instituicaoEnsinoService.FindInstituicaoEnsinoByCnpj(description);
            return Ok(result);
        }

        [HttpPost]
        [Route(Route.ALL)]
        public override async Task<IActionResult> FindByDescription([FromBody] Pesquisa pesquisa)
        {
            var result = await _instituicaoEnsinoService.FindByDescription(pesquisa.Description, new PaginacaoParametroDto());
            return Ok(new Resultado<InstituicaoEnsino>(result, result.Count));
        }

        [HttpGet]
        [Route(Route.ALL)]
        public override async Task<IActionResult> GetAll([FromQuery] PaginacaoParametroDto paginacaoParametro)
        {
            var result = await _instituicaoEnsinoService.GetAll();
            return Ok(new Resultado<InstituicaoEnsino>(result, result.Count));
        }

        [HttpGet]
        [Route(Route.ID)]
        public override async Task<IActionResult> FindById(int id)
        {
            var result = await _instituicaoEnsinoService.GetById(id);
            return Ok(result);
        }
    }
}
