using System.ComponentModel.DataAnnotations;

namespace ToDo.Domain.Enum
{
    public enum SituacaoCliente
    {
        [Display(Name = "Ativo")]
        Ativo = 1,
        [Display(Name = "Bloqueado")]
        Bloqueado = 2,
    }
}
