using ToDo.Domain.Models;

namespace ToDo.Application.ViewModels
{
    public class LivroViewModel : BaseViewModel
    {
        public string Titulo { get; set; }
        public int GeneroId { get; set; }
        public string Autor { get; set; }
        public string Sinopse { get; set; }
        public byte[] ImagemCapa { get; set; }
        public bool Disponivel { get; set; } = true;
    }
}
