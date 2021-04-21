using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Models;
using static ToDo.Domain.Util.Endpoints;

namespace ToDo.Api.Controllers
{
    [AuthorizeAttribute]
    [ApiController]
    [Route("api/instituicao/[action]")]
    public class InstituicaoEnsinoController : BaseController<InstituicaoEnsino>
    {
        private readonly IInstituicaoEnsinoService _instituicaoEnsinoService;

        public InstituicaoEnsinoController(IInstituicaoEnsinoService instituicaoEnsinoService) : base(instituicaoEnsinoService)
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
    }
}
