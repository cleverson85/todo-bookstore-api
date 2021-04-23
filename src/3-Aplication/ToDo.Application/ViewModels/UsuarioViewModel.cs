using ToDo.Domain.Models;

namespace ToDo.Application.ViewModels
{
    public class UsuarioViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
