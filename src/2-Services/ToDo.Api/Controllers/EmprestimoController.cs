using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.ViewModels;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Models;
using static ToDo.Domain.Util.Endpoints;

namespace ToDo.Api.Controllers
{
    [Helpers.Authorize]
    [ApiController]
    [Route(Recursos.Emprestimo)]
    public class EmprestimoController : BaseController<Emprestimo, EmprestimoViewModel>
    {
        private readonly IEmprestimoService _emprestimoService;

        public EmprestimoController(IEmprestimoService emprestimoService, IMapper mapper) : base(emprestimoService, mapper)
        {
            _emprestimoService = emprestimoService;
        }
    }
}
