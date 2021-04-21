namespace ToDo.Domain.Models
{
    public class LivroReserva : BaseEntity
    {
        public Cliente Cliente { get; set; }
        public Livro Livro { get; set; }
        public bool Reservado { get; set; }

        public LivroReserva() { }

        public LivroReserva(Cliente cliente, Livro livro, bool reservado)
        {
            Cliente = cliente;
            Livro = livro;
            Reservado = reservado;
        }
    }
}
