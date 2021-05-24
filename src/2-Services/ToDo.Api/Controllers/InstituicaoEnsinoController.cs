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
    [Route(Recursos.Instituicao)]
    public class InstituicaoEnsinoController : BaseController<InstituicaoEnsino, InstituicaoEnsinoViewModel>
    {
        private readonly IInstituicaoEnsinoService _instituicaoEnsinoService;

        public InstituicaoEnsinoController(IInstituicaoEnsinoService instituicaoEnsinoService, IMapper mapper) : base(instituicaoEnsinoService, mapper)
        {
            _instituicaoEnsinoService = instituicaoEnsinoService;
        }

        [HttpGet]
        [Route(Route.NAME)]
        public async Task<IActionResult> FindInstituicaoByName(string description, [FromQuery] PaginacaoParametroDto paginacaoParametro)
        {
            var result = await _instituicaoEnsinoService.FindInstituicaoByName(description, paginacaoParametro);
            return Ok(result);
        }

        [HttpGet]
        [Route(Route.CNPJ)]
        public async Task<IActionResult> FindInstituicaoEnsinoByCnpj(string description)
        {
            var result = await _instituicaoEnsinoService.FindInstituicaoEnsinoByCnpj(description);
            return Ok(result);
        }

        [HttpGet]
        [Route(Route.DESCRIPTION)]
        public async Task<IActionResult> FindByDescription(string description, [FromQuery] PaginacaoParametroDto paginacaoParametro)
        {
            var result = await _instituicaoEnsinoService.FindByDescription(description, paginacaoParametro);
            return Ok(new Resultado<InstituicaoEnsino>(result, result.Count));
        }
    }
}
