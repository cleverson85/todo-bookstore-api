namespace ToDo.Domain.Models
{
    public class LivroImagem : BaseEntity
    {
        public Livro Livro { get; set; }
        public byte[] ImagemCapa { get; set; }

        public LivroImagem() { }

        public LivroImagem(Livro livro, byte[] imagemCapa)
        {
            Livro = livro;
            ImagemCapa = imagemCapa;
        }
    }
}
