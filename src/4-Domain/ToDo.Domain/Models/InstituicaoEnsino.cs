namespace ToDo.Domain.Models
{
    public class InstituicaoEnsino : BaseEntity
    {
        public Pessoa Pessoa { get; set; }
        public string Cnpj { get; set; }

        public InstituicaoEnsino() { }

        public InstituicaoEnsino(Pessoa pessoa, string cnpj)
        {
            Pessoa = pessoa;
            Cnpj = cnpj;
        }
    }
}
