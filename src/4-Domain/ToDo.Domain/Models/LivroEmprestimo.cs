namespace ToDo.Domain.Models
{
    public class LivroEmprestimo : BaseEntity
    {
        public Livro Livro { get; set; }
        public bool Pendente { get; set; }

        public LivroEmprestimo() { }

        public LivroEmprestimo(Livro livro, bool pendente)
        {
            Livro = livro;
            Pendente = pendente;
        }
    }
}
