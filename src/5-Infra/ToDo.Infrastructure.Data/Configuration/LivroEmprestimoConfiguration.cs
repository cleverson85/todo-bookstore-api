using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Models;

namespace ToDo.Infrastructure.Data.Configuration
{
    public class LivroEmprestimoConfiguration : IEntityTypeConfiguration<LivroEmprestimo>
    {
        public void Configure(EntityTypeBuilder<LivroEmprestimo> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Emprestimo)
                .WithMany(c => c.LivrosEmprestimo);
            builder.HasOne(c => c.Livro);
            builder.Property(c => c.Pendente);
        }
    }
}
