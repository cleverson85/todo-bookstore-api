using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;
using static ToDo.Domain.Util.Endpoints;

namespace ToDo.Api.Controllers
{
    [AuthorizeAttribute]
    [ApiController]
    [Route("api/cliente/[action]")]
    public class ClienteController : BaseController<Cliente>
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService) : base(clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [Route(Route.DESCRIPTION)]
        public async Task<IActionResult> FindByName(string description, PaginacaoParametroDto paginacaoParametroDto)
        {           
            var result = await _clienteService.FindByName(description, paginacaoParametroDto);
            return Ok(new Resultado<Cliente>(result, result.Count));
        }

        [HttpGet]
        [Route(Route.DESCRIPTION)]
        public async Task<IActionResult> FindByCpf(string description)
        {
            var result = await _clienteService.FindByCpf(description);
            return Ok(result);
        }

        [HttpGet]
        [Route(Route.DESCRIPTION)]
        public async Task<IActionResult> FindByEmail(string description)
        {
            var result = await _clienteService.FindByEmail(description);
            return Ok(result);
        }
    }
}
