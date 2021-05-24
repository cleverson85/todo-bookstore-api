using System.Collections.Generic;

namespace ToDo.Domain.Models
{
    public class LivroReserva : BaseEntity
    {
        public Cliente Cliente { get; set; }
        public IList<Livro> Livros { get; set; }
        public bool Reservado { get; set; }

        public LivroReserva() { }

        public LivroReserva(Cliente cliente, bool reservado)
        {
            Cliente = cliente;
            Reservado = reservado;
            Livros = new List<Livro>();
        }

        public void AdicionarLivro(Cliente cliente, IList<Livro> livros)
        {
            Cliente = cliente;
            foreach (var item in livros)
            {
                Livros.Add(item);
            }
        }
    }
}
