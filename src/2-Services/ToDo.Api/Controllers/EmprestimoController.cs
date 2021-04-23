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
    [Route("api/emprestimo/[action]")]
    public class EmprestimoController : BaseController<Emprestimo, EmprestimoViewModel>
    {
        private readonly IEmprestimoService _emprestimoService;

        public EmprestimoController(IEmprestimoService emprestimoService, IMapper mapper) : base(emprestimoService, mapper)
        {
            _emprestimoService = emprestimoService;
        }

        [HttpPost]
        [Route(Route.ALL)]
        public override async Task<IActionResult> FindByDescription([FromBody] Pesquisa pesquisa)
        {
            var result = await _emprestimoService.FindByDescription(pesquisa.Description, new PaginacaoParametroDto());
            return Ok(new Resultado<Emprestimo>(result, result.Count));
        }
    }
}
