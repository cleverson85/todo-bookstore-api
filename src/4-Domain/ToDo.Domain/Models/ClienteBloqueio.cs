using System;
using ToDo.Domain.Enum;

namespace ToDo.Domain.Models
{
    public class ClienteBloqueio : BaseEntity
    {
        public Cliente Cliente { get; set; }
        public SituacaoCliente Situacao { get; set; }
        public DateTime? BloqueadoAte { get; set; }

        public ClienteBloqueio() { }

        public ClienteBloqueio(Cliente cliente)
        {
            Cliente = cliente;
        }

        public void Bloquear()
        {
            Situacao = SituacaoCliente.Bloqueado;
            BloqueadoAte = DateTime.Now.AddDays(30);
        }

        public void DesBloquear()
        {
            Situacao = SituacaoCliente.Ativo;
            BloqueadoAte = null;
        }
    }
}
