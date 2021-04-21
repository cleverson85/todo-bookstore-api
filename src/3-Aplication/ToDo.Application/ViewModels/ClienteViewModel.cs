using System.Collections.Generic;
using ToDo.Domain.Models;

namespace ToDo.Application.ViewModels
{
    public class ClienteViewModel : Cliente
    {
        public List<ClienteViewModel> Clientes { get; set; }

        public ClienteViewModel()
        {
            Clientes = new List<ClienteViewModel>();
        }
    }
}
