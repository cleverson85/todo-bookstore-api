using AutoMapper;
using ToDo.Application.ViewModels;
using ToDo.Domain.Models;

namespace ToDo.Application.Mappers
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<InstitutoEnsinoViewModel, InstituicaoEnsino>();
            CreateMap<LivroViewModel, Livro>();
            CreateMap<UsuarioViewModel, Usuario>()
                .ForPath(c => c.Pessoa.Email, opt => opt.MapFrom(d => d.Email));
        }
    }
}
