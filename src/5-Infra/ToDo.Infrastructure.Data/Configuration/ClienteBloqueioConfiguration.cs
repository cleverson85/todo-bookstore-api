using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using ToDo.Domain.Enum;
using ToDo.Domain.Models;

namespace ToDo.Infrastructure.Data.Configuration
{
    public class ClienteBloqueioConfiguration : IEntityTypeConfiguration<ClienteBloqueio>
    {
        public void Configure(EntityTypeBuilder<ClienteBloqueio> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Cliente);
            builder.Property(c => c.Situacao)
                .HasDefaultValue(SituacaoCliente.Bloqueado);
            builder.Property(c => c.BloqueadoAte)
                .HasDefaultValue(DateTime.Now.AddDays(30));
        }
    }
}
