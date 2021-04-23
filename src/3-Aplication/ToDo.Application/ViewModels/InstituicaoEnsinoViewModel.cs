using ToDo.Domain.Models;

namespace ToDo.Application.ViewModels
{
    public class InstituicaoEnsinoViewModel : BaseViewModel
    {
        public int InstituicaoEnsinoId { get; set; }
        public int PessoaId { get; set; }
        public int EnderecoId { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public string Logradouro { get; set; }
        public string Nome { get; set; }
        public int Numero { get; set; }
        public string Telefone { get; set; }
    }
}
