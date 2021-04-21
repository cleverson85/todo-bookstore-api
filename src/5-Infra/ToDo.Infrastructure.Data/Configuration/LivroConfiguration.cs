using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Models;

namespace ToDo.Infrastructure.Data.Configuration
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Titulo)
                .IsRequired()
                .HasMaxLength(250);
            builder.HasOne(c => c.Genero);
            builder.Property(c => c.Autor)
                .IsRequired()
                .HasMaxLength(250); ;
            builder.Property(c => c.Sinopse)
                .HasMaxLength(2000);
            builder.Property(c => c.Disponivel)
                .HasDefaultValue(true);
            builder.Property(c => c.ImagemCapa);
        }
    }
}
