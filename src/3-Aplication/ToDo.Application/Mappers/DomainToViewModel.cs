using AutoMapper;
using ToDo.Application.ViewModels;
using ToDo.Domain.Models;

namespace ToDo.Application.Mappers
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<ClienteViewModel, Cliente>()
                .ForPath(dest  => dest .Id, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
                .ForPath(dest => dest.Pessoa.Id, opt => opt.MapFrom(src => src.PessoaId))
                .ForPath(dest => dest.Pessoa.Endereco.Id, opt => opt.MapFrom(src => src.EnderecoId))
                .ForPath(dest => dest.Situacao, opt => opt.MapFrom(src => src.Situacao))
                .ForPath(dest => dest.Pessoa.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForPath(dest => dest.Pessoa.Email, opt => opt.MapFrom(src => src.Email))
                .ForPath(dest => dest.Pessoa.Telefone, opt => opt.MapFrom(src => src.Telefone))
                .ForPath(dest => dest.Pessoa.Endereco.Cep, opt => opt.MapFrom(src => src.Cep))
                .ForPath(dest => dest.Pessoa.Endereco.Bairro, opt => opt.MapFrom(src => src.Bairro))
                .ForPath(dest => dest.Pessoa.Endereco.Logradouro, opt => opt.MapFrom(src => src.Logradouro))
                .ForPath(dest => dest.Pessoa.Endereco.Numero, opt => opt.MapFrom(src => src.Numero))
                .ForPath(dest => dest.Pessoa.Endereco.Complemento, opt => opt.MapFrom(src => src.Complemento))
                .ForPath(dest => dest.Pessoa.Endereco.Cidade, opt => opt.MapFrom(src => src.Cidade))
                .ForPath(dest => dest.Pessoa.Endereco.Estado, opt => opt.MapFrom(src => src.Estado))
                .ForPath(dest => dest.InstituicaoEnsino.Id, opt => opt.MapFrom(src => src.InstituicaoEnsinoId)).ReverseMap();

            CreateMap<InstituicaoEnsinoViewModel, InstituicaoEnsino>()
                .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj))
                .ForPath(dest => dest.Pessoa.Id, opt => opt.MapFrom(src => src.PessoaId))
                .ForPath(dest => dest.Pessoa.Endereco.Id, opt => opt.MapFrom(src => src.EnderecoId))
                .ForPath(dest => dest.Pessoa.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForPath(dest => dest.Pessoa.Email, opt => opt.MapFrom(src => src.Email))
                .ForPath(dest => dest.Pessoa.Telefone, opt => opt.MapFrom(src => src.Telefone))
                .ForPath(dest => dest.Pessoa.Endereco.Cep, opt => opt.MapFrom(src => src.Cep))
                .ForPath(dest => dest.Pessoa.Endereco.Bairro, opt => opt.MapFrom(src => src.Bairro))
                .ForPath(dest => dest.Pessoa.Endereco.Logradouro, opt => opt.MapFrom(src => src.Logradouro))
                .ForPath(dest => dest.Pessoa.Endereco.Numero, opt => opt.MapFrom(src => src.Numero))
                .ForPath(dest => dest.Pessoa.Endereco.Complemento, opt => opt.MapFrom(src => src.Complemento))
                .ForPath(dest => dest.Pessoa.Endereco.Cidade, opt => opt.MapFrom(src => src.Cidade))
                .ForPath(dest => dest.Pessoa.Endereco.Estado, opt => opt.MapFrom(src => src.Estado)).ReverseMap();

            CreateMap<Livro, LivroViewModel>()
                .ForPath(dest => dest.GeneroId, opt => opt.MapFrom(src => src.Genero.Id)).ReverseMap();

            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Emprestimo, EmprestimoViewModel>();
        }
    }
}
