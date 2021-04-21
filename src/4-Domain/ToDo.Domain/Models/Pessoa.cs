using System.ComponentModel.DataAnnotations;

namespace ToDo.Domain.Models
{
    public class Pessoa : BaseEntity
    {

        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Pessoa() { }

        public Pessoa(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public Pessoa(Endereco endereco)
        {
            Endereco = endereco;
        }
    }
}
