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
    [Route("api/cliente/[action]")]
    public class ClienteController : BaseController<Cliente, ClienteViewModel>
    {   
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService, IMapper mapper) : base(clienteService, mapper)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [Route(Route.DESCRIPTION)]
        public async Task<IActionResult> FindByName(string description, [FromQuery] PaginacaoParametroDto paginacaoParametroDto)
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

        [HttpGet]
        [Route(Route.ID)]
        public override async Task<IActionResult> FindById(int id)
        {
            var result = await _clienteService.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        [Route(Route.ALL)]
        public override async Task<IActionResult> GetAll([FromQuery] PaginacaoParametroDto paginacaoParametro)
        {
            var result = await _clienteService.GetAll();
            return Ok(new Resultado<Cliente>(result, result.Count));
        }

        [HttpPost]
        [Route(Route.ALL)]
        public override async Task<IActionResult> FindByDescription([FromBody] Pesquisa pesquisa)
        {
            var result = await _clienteService.FindByDescription(pesquisa.Description, new PaginacaoParametroDto());
            return Ok(new Resultado<Cliente>(result, result.Count));
        }
    }
}
