using AutoMapper;
using ToDo.Application.ViewModels;
using ToDo.Domain.Models;

namespace ToDo.Application.Mappers
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<InstituicaoEnsino, InstitutoEnsinoViewModel>();
            CreateMap<Livro, LivroViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}
