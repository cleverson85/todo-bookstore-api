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
                .ForPath(c => c.Id, opt => opt.MapFrom(d => d.Id))
                .ForPath(c => c.Cpf, opt => opt.MapFrom(d => d.Cpf))
                .ForPath(c => c.Pessoa.Id, opt => opt.MapFrom(d => d.PessoaId))
                .ForPath(c => c.Pessoa.Endereco.Id, opt => opt.MapFrom(d => d.EnderecoId))
                .ForPath(c => c.Situacao, opt => opt.MapFrom(d => d.Situacao))
                .ForPath(c => c.Pessoa.Nome, opt => opt.MapFrom(d => d.Nome))
                .ForPath(c => c.Pessoa.Email, opt => opt.MapFrom(d => d.Email))
                .ForPath(c => c.Pessoa.Telefone, opt => opt.MapFrom(d => d.Telefone))
                .ForPath(c => c.Pessoa.Endereco.Cep, opt => opt.MapFrom(d => d.Cep))
                .ForPath(c => c.Pessoa.Endereco.Bairro, opt => opt.MapFrom(d => d.Bairro))
                .ForPath(c => c.Pessoa.Endereco.Logradouro, opt => opt.MapFrom(d => d.Logradouro))
                .ForPath(c => c.Pessoa.Endereco.Numero, opt => opt.MapFrom(d => d.Numero))
                .ForPath(c => c.Pessoa.Endereco.Complemento, opt => opt.MapFrom(d => d.Complemento))
                .ForPath(c => c.Pessoa.Endereco.Cidade, opt => opt.MapFrom(d => d.Cidade))
                .ForPath(c => c.Pessoa.Endereco.Estado, opt => opt.MapFrom(d => d.Estado))
                .ForPath(c => c.InstituicaoEnsino, opt => opt.MapFrom(d => d.InstituicaoEnsinoId)).ReverseMap();

            CreateMap<InstituicaoEnsinoViewModel, InstituicaoEnsino>()
                .ForPath(c => c.Id, opt => opt.MapFrom(d => d.Id))
                .ForPath(c => c.Cnpj, opt => opt.MapFrom(d => d.Cnpj))
                .ForPath(c => c.Pessoa.Id, opt => opt.MapFrom(d => d.PessoaId))
                .ForPath(c => c.Pessoa.Endereco.Id, opt => opt.MapFrom(d => d.EnderecoId))
                .ForPath(c => c.Pessoa.Nome, opt => opt.MapFrom(d => d.Nome))
                .ForPath(c => c.Pessoa.Email, opt => opt.MapFrom(d => d.Email))
                .ForPath(c => c.Pessoa.Telefone, opt => opt.MapFrom(d => d.Telefone))
                .ForPath(c => c.Pessoa.Endereco.Cep, opt => opt.MapFrom(d => d.Cep))
                .ForPath(c => c.Pessoa.Endereco.Bairro, opt => opt.MapFrom(d => d.Bairro))
                .ForPath(c => c.Pessoa.Endereco.Logradouro, opt => opt.MapFrom(d => d.Logradouro))
                .ForPath(c => c.Pessoa.Endereco.Numero, opt => opt.MapFrom(d => d.Numero))
                .ForPath(c => c.Pessoa.Endereco.Complemento, opt => opt.MapFrom(d => d.Complemento))
                .ForPath(c => c.Pessoa.Endereco.Cidade, opt => opt.MapFrom(d => d.Cidade))
                .ForPath(c => c.Pessoa.Endereco.Estado, opt => opt.MapFrom(d => d.Estado)).ReverseMap();

            CreateMap<Livro, LivroViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Emprestimo, EmprestimoViewModel>();
        }
    }
}
