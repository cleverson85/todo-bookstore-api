using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Models;

namespace ToDo.Infrastructure.Data.Configuration
{
    public class LivroImagemConfiguration : IEntityTypeConfiguration<LivroImagem>
    {
        public void Configure(EntityTypeBuilder<LivroImagem> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ImagemCapa);

            builder.HasAlternateKey(c => c.Livro);
                //.WithOne(c => c.LivroImagem);
                   //.WithOne(c => c.LivroImagem);
        }
    }
}
