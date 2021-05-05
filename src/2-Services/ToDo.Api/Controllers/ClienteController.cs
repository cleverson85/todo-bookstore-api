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
        public async Task<IActionResult> FindByName(string description)
        {           
            var result = await _clienteService.FindByName(description);
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
        [Route(Route.DESCRIPTION)]
        public async Task<IActionResult> FindByDescription(string description)
        {
            var result = await _clienteService.FindByDescription(description);
            return Ok(new Resultado<Cliente>(result, result.Count));
        }
    }
}
