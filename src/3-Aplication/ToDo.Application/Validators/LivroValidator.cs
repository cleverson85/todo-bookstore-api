using FluentValidation;
using ToDo.Domain.Models;

namespace ToDo.Application.Validators
{
    public class LivroValidator : AbstractValidator<Livro>
    {
        public LivroValidator()
        {
            RuleFor(c => c.Titulo)
                .NotEmpty()
                .WithMessage("Informe o titulo do Livro.");

            RuleFor(c => c.Genero)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe o gênero do Livro.");

            RuleFor(c => c.Autor)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe o autor do Livro.");
        }
    }
}