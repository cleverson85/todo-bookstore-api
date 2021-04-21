using System;
using ToDo.Domain.Enum;

namespace ToDo.Domain.Models
{
    public class Cliente : BaseEntity
    {
        public Pessoa Pessoa { get; set; }
        public InstituicaoEnsino InstituicaoEnsino { get; set; }
        public string Cpf { get; set; }
        public SituacaoCliente Situacao { get; set; }

        public Cliente() { }

        public Cliente(string cpf, bool bloqueado, DateTime bloqueadoAte)
        {
            Cpf = cpf;
        }

        public Cliente(Pessoa pessoa) 
        {
            Pessoa = pessoa;
        }

        public Cliente(InstituicaoEnsino instituicaoEnsino)
        {
            InstituicaoEnsino = instituicaoEnsino;
        }
    }
}
