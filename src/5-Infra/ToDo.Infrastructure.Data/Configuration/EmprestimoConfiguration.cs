using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using ToDo.Domain.Enum;
using ToDo.Domain.Models;

namespace ToDo.Infrastructure.Data.Configuration
{
    public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Cliente);
            builder.Property(c => c.DataInicio)
                .HasDefaultValue(DateTime.Now);
            builder.Property(c => c.DataDevolucao)
                .HasDefaultValue(DateTime.Now.AddDays(30));
            builder.Property(c => c.Situacao)
                .HasDefaultValue(SituacaoEmprestimo.Ativa);

            builder.HasMany(c => c.LivrosEmprestimo)
                .WithOne(c => c.Emprestimo)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
