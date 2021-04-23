using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Models;

namespace ToDo.Infrastructure.Data.Configuration
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome)
                 .HasMaxLength(150);
            builder.HasOne(c => c.Endereco); 
            builder.Property(c => c.Email)
                 .HasMaxLength(150);
            builder.Property(c => c.Telefone)
                 .HasMaxLength(15);
        }
    }
}
