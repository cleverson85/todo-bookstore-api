using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Models;

namespace ToDo.Infrastructure.Data.Configuration
{
    public class LivroReservaConfiguration : IEntityTypeConfiguration<LivroReserva>
    {
        public void Configure(EntityTypeBuilder<LivroReserva> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Cliente);
            builder.HasMany(c => c.Livros)
                    .WithOne()
                    .OnDelete(DeleteBehavior.Cascade);
            builder.Property(c => c.Reservado)
                .HasDefaultValue(true);
        }
    }
}
