using FluentValidation;
using ToDo.Domain.Models;

namespace ToDo.Application.Validators
{
    public class InstituicaoEnsinoValidator : AbstractValidator<InstituicaoEnsino>
    {
        public InstituicaoEnsinoValidator()
        {
            RuleFor(c => c.Pessoa.Nome)
                .NotEmpty()
                .WithMessage("Informe o nome da Instituição de Ensino.");

            RuleFor(c => c.Pessoa.Endereco)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe o endereço da Instituição de Ensino.");

            RuleFor(c => c.Cnpj)
                .NotEmpty()
                .WithMessage("Informe o cnpj da Instituição de Ensino.");

            RuleFor(c => c.Pessoa.Telefone)
                .NotEmpty()
                .WithMessage("Informe o telefone da Instituição de Ensino.");
        }
    }
}