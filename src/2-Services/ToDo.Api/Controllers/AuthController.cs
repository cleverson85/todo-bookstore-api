using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDo.Application.ViewModels;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Models;
using static ToDo.Domain.Util.Endpoints;

namespace ToDo.Api.Controllers
{
    [ApiController]
    [Route("api/auth/[action]")]
    public class AuthController : Controller
    {
        private readonly IAuthJwtService _authService;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public AuthController(IAuthJwtService authService, IUsuarioService usuarioService, IMapper mapper)
        {
            _authService = authService;
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route(Route.POST)]
        public async Task<IActionResult> Login([FromBody] UsuarioViewModel usuarioViewModel)
        {
            var usuario = _mapper.Map<Usuario>(usuarioViewModel);
            var userAuthenticated = await _usuarioService.Authenticate(usuario);

            if (userAuthenticated == null)
            {
                return BadRequest();
            }

            string token = await _authService.GenerateToken(userAuthenticated);

            return Ok(new AuthResponse { Token = token, IsAuthenticaded = true });
        }
    }
}
