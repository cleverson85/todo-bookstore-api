namespace ToDo.Domain.Models
{
    public class LivroEmprestimo : BaseEntity
    {
        public Emprestimo Emprestimo { get; set; }
        public Livro Livro { get; set; }
        public bool Pendente { get; set; }

        public LivroEmprestimo() { }

        public LivroEmprestimo(Emprestimo emprestimo, Livro livro, bool pendente, bool disponivel)
        {
            Emprestimo = emprestimo;
            Livro = livro;
            Pendente = pendente;
        }
    }
}
