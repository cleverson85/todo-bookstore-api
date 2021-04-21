using System.Collections.Generic;
using ToDo.Domain.Models;

namespace ToDo.Application.ViewModels
{
    public class InstitutoEnsinoViewModel : InstituicaoEnsino
    {
        public List<InstitutoEnsinoViewModel> InstitutoEnsino { get; set; }

        public InstitutoEnsinoViewModel()
        {
            InstitutoEnsino = new List<InstitutoEnsinoViewModel>();
        }
    }
}
