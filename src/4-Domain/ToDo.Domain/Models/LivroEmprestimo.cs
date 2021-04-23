namespace ToDo.Domain.Models
{
    public class LivroEmprestimo : BaseEntity
    {
        public Emprestimo Emprestimo { get; set; }
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
        public bool Pendente { get; set; }

        public LivroEmprestimo() { }

        public LivroEmprestimo(Emprestimo emprestimo, Livro livro, bool pendente)
        {
            Emprestimo = emprestimo;
            Livro = livro;
            Pendente = pendente;
        }

        public LivroEmprestimo(Emprestimo emprestimo, int livro, bool pendente)
        {
            Emprestimo = emprestimo;
            LivroId = livro;
            Pendente = pendente;
        }
    }
}
