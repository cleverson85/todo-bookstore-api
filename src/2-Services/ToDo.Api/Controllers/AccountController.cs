using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Models;
using static ToDo.Domain.Util.Endpoints;

namespace ToDo.Api.Controllers
{
    [ApiController]
    [Route("api/account/[action]")]
    public class AccountController : BaseController<Usuario>
    {
        private readonly IUsuarioService _usuarioService;

        public AccountController(IUsuarioService usuarioService) : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route(Route.POST)]
        public async Task<IActionResult> Register([FromBody] Usuario usuario)
        {
            var account = await _usuarioService.Register(usuario);
            return Ok(account);
        }
    }
}
