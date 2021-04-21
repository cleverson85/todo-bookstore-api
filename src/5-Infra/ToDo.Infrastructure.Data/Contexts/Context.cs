using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToDo.Domain.Models;

namespace ToDo.Infrastructure.Data.Contexts
{
    public class Context : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<InstituicaoEnsino> InstituicaoEnsino { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }
        public DbSet<LivroEmprestimo> LivroEmprestimo { get; set; }
        public DbSet<LivroReserva> LivroReserva { get; set; }
        public DbSet<ClienteBloqueio> ClienteBloqueio { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
