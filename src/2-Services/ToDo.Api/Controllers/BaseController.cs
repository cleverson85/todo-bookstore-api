using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;
using static ToDo.Domain.Util.Endpoints;

namespace ToDo.Api.Controllers
{
    [ApiController]
    public abstract class BaseController<Entity> : Controller where Entity : BaseEntity
    {
        private readonly IBaseService<Entity> _baseService;

        public BaseController(IBaseService<Entity> baseService)
        {
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
            var result = await _baseService.GetById(id, null);
            return Ok(result);
        }

        [HttpPost]
        [Route(Route.POST)]
        public virtual async Task<IActionResult> Save([FromBody] Entity entity)
        {
            await _baseService.Save(entity);
            return Ok(await GetAll(new PaginacaoParametroDto()));
        }

        [HttpDelete]
        [Route(Route.ID)]
        public async Task<IActionResult> Delete(int id)
        {
            await _baseService.Delete(id);
            return Ok();
        }
    }
}
