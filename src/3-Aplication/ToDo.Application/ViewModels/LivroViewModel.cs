using System.Collections.Generic;
using ToDo.Domain.Models;

namespace ToDo.Application.ViewModels
{
    public class LivroViewModel : Livro
    {
        public List<LivroViewModel> Livros { get; set; }

        public LivroViewModel()
        {
            Livros = new List<LivroViewModel>();
        }
    }
}
