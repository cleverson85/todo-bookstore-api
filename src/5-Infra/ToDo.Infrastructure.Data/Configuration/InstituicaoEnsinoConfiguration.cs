using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Models;

namespace ToDo.Infrastructure.Data.Configuration
{
    class InstituicaoEnsinoConfiguration : IEntityTypeConfiguration<InstituicaoEnsino>
    {
        public void Configure(EntityTypeBuilder<InstituicaoEnsino> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Cnpj)
                .HasMaxLength(20);
            builder.HasOne(c => c.Pessoa);
        }
    }
}
