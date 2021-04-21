using System.Text.Json.Serialization;

namespace ToDo.Domain.Models
{
    public class Usuario : BaseEntity
    {
        public Pessoa Pessoa { get; set; }
        public virtual string Senha { get; set; }
    }
}
