using FluentValidation;
using ToDo.Domain.Models;

namespace ToDo.Application.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.Pessoa.Nome)
                .NotEmpty()
                .WithMessage("Informe o nome do Cliente.");

            RuleFor(c => c.Cpf)
                .NotEmpty()
                .WithMessage("Informe o cpf do Cliente.");

            RuleFor(c => c.Pessoa.Email)
                .NotEmpty()
                .WithMessage("Informe o E-mail")
                .EmailAddress().WithMessage("Email inválido.");
        }
    }
}