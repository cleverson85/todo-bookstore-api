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
    public abstract class BaseController<Entity, ViewModel> : ControllerBase
        where Entity : BaseEntity
        where ViewModel : BaseViewModel
    {
        private readonly IMapper _mapper;
        private readonly IBaseService<Entity> _baseService;

        public BaseController(IBaseService<Entity> baseService, IMapper mapper)
        {
            _mapper = mapper;
            _baseService = baseService;
        }

        [HttpGet]
        [Route(Route.ALL)]
        public virtual async Task<IActionResult> GetAll([FromQuery] PaginacaoParametroDto paginacaoParametro)
        {
            var result = await _baseService.GetAll(paginacaoParametro);
            var count = await _baseService.Count();
            return Ok(new Resultado<Entity>(result, count));
        }

        [HttpGet]
        [Route(Route.ID)]
        public virtual async Task<IActionResult> FindById(int id)
        {
            var result = await _baseService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route(Route.POST)]
        public virtual async Task<IActionResult> Save([FromBody] ViewModel viewModel)
        {
            var result = _mapper.Map<Entity>(viewModel);
            await _baseService.Save(result);
            return Ok(await GetAll(new PaginacaoParametroDto()));
        }

        [HttpDelete]
        [Route(Route.DELETE)]
        public async Task<IActionResult> Delete(int id)
        {
            await _baseService.Delete(id);
            return Ok(await GetAll(new PaginacaoParametroDto()));
        }
    }
}
