using System;
using System.Collections.Generic;
using ToDo.Domain.Enum;

namespace ToDo.Domain.Models
{
    public class Emprestimo : BaseEntity
    {
        public Cliente Cliente { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataDevolucao { get; set; }
        public SituacaoEmprestimo Situacao { get; set; }
        public IList<LivroEmprestimo> LivrosEmprestimo { get; set; }

        public Emprestimo()
        {
            LivrosEmprestimo = new List<LivroEmprestimo>();
        }

        public void AdicionarLivroEmprestimo(Cliente cliente, IList<Livro> livros)
        {
            Cliente = cliente;

            foreach (var livro in livros)
            {
                LivrosEmprestimo.Add(new LivroEmprestimo(this, livro, false, false));
            }
        }

        public void AlterarSituacaoEmprestimo(SituacaoEmprestimo situacao)
        {
            Situacao = situacao;
        }
    }
}
