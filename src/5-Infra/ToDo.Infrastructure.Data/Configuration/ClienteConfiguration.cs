using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Enum;
using ToDo.Domain.Models;

namespace ToDo.Infrastructure.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Cpf);
            builder.Property(c => c.Situacao)
                .HasDefaultValue(SituacaoCliente.Ativo);
            builder.HasOne(c => c.Pessoa);
            builder.HasOne(c => c.InstituicaoEnsino);
        }
    }
}
