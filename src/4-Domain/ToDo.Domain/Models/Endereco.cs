namespace ToDo.Domain.Models
{
    public class Endereco : BaseEntity
    {
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public int Numero { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }

        public Endereco() { }

        public Endereco(string cep, string bairro, string logradouro, string complemento, int numero, string estado, string cidade)
        {
            Cep = cep;
            Bairro = bairro;
            Logradouro = logradouro;
            Complemento = complemento;
            Numero = numero;
            Estado = estado;
            Cidade = cidade;
        }
    }
}
