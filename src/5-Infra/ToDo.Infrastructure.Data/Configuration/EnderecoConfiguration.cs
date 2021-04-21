using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Models;

namespace ToDo.Infrastructure.Data.Configuration
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Cep);
            builder.Property(c => c.Bairro);
            builder.Property(c => c.Logradouro)
                .HasMaxLength(200);
            builder.Property(c => c.Complemento)
                .HasMaxLength(200); ;
            builder.Property(c => c.Numero);
            builder.Property(c => c.Estado);
            builder.Property(c => c.Cidade);
        }
    }
}
